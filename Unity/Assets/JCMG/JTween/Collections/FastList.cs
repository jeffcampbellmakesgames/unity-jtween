using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

namespace JCMG.JTween
{
	/// <summary>
	/// A dynamically sized array with fast access and removal operations
	/// </summary>
	internal class FastList<T>
	{
		/// <summary>
		/// The size of the list based on its contents.
		/// </summary>
		public int Length => _length;

		/// <summary>
		/// The capacity of the list based on its backing array buffer
		/// </summary>
		public int Capacity => buffer.Length;

		public T[] buffer;

		private int _length;

		public FastList(int capacity)
		{
			SetCapacity(capacity);
		}

		public T this[int i] {
			get { return buffer[i]; }
			set { buffer[i] = value; }
		}

		public void Trim()
		{
			SetCapacity(_length);
		}

		public void EnsureCapacity(int capacity)
		{
			if (capacity <= 0 || buffer != null && capacity <= buffer.Length)
			{
				return;
			}

			_length = Mathf.Min(_length, capacity);
			var objArray = new T[capacity];
			for (var index = 0; index < _length; ++index)
			{
				objArray[index] = buffer[index];
			}

			buffer = objArray;
		}

		public void SetCapacity(int capacity)
		{
			if (capacity > 0)
			{
				if (buffer != null && capacity == buffer.Length)
				{
					return;
				}

				_length = Mathf.Min(_length, capacity);
				var objArray = new T[capacity];
				for (var index = 0; index < _length; ++index)
				{
					objArray[index] = buffer[index];
				}

				buffer = objArray;
			}
			else
			{
				buffer = null;
			}
		}

		public bool Contains(T item)
		{
			if (buffer == null)
			{
				return false;
			}

			var found = false;
			var equalityComparer = EqualityComparer<T>.Default;
			for (var i = 0; i < _length; ++i)
			{
				if (!equalityComparer.Equals(buffer[i], item))
				{
					continue;
				}

				found = true;
				break;
			}

			return found;
		}

		public void Clear()
		{
			_length = 0;
		}

		public void Release()
		{
			_length = 0;
			buffer = null;
		}

		public void Add(T item)
		{
			if (buffer == null || _length == buffer.Length)
			{
				SetCapacity(buffer != null ? Mathf.Max(buffer.Length << 1, 32) : 32);
			}

			buffer[_length++] = item;
		}

		public void Remove(T item)
		{
			const string PROFILE_REMOVE_NAME = "FastList.Remove";
			Profiler.BeginSample(PROFILE_REMOVE_NAME);
			if (buffer == null)
			{
				Profiler.EndSample();
				return;
			}

			var equalityComparer = EqualityComparer<T>.Default;
			for (var i = 0; i < _length; ++i)
			{
				if (!equalityComparer.Equals(buffer[i], item))
				{
					continue;
				}

				--_length;
				ResortArray(i);
				break;
			}
			Profiler.EndSample();
		}

		public void RemoveAt(int index)
		{
			const string PROFILE_REMOVE_NAME = "FastList.RemoveAt";
			Profiler.BeginSample(PROFILE_REMOVE_NAME);

			--_length;

			if (_length != index)
			{
				ResortArray(index);
			}
			Profiler.EndSample();
		}

		private void ResortArray(int index)
		{
			var newLength = _length - index;
			Array.Copy(buffer, index + 1, buffer, index, newLength);
		}
	}
}
