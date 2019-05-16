using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

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

		public FastList() { }

		public FastList(int capacity)
		{
			SetCapacity(capacity);
		}

		public void SetCapacity(int capacity)
		{
			if (buffer == null)
			{
				buffer = new T[capacity];
			}
			else if (capacity > buffer.Length)
			{
				if (buffer != null && capacity == buffer.Length)
				{
					return;
				}

				var objArray = new T[capacity];
				Array.Copy(buffer, 0, objArray, 0, _length);
				_length = Mathf.Min(_length, capacity);

				buffer = objArray;
			}
			else if(capacity <= 0)
			{
				Release();
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

		public void Trim()
		{
			SetCapacity(_length);
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

		public T PopLast()
		{
			T result;
			if (_length == 0)
			{
				result = default(T);
			}
			else
			{
				result = buffer[_length - 1];
				_length--;
			}

			return result;
		}

		public void Remove(T item)
		{
			if (buffer == null)
			{
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
		}

		public int IndexOf(T item)
		{
			var equalityComparer = EqualityComparer<T>.Default;
			for (var i = 0; i < _length; ++i)
			{
				if (!equalityComparer.Equals(buffer[i], item))
				{
					continue;
				}

				return i;
			}

			return -1;
		}

		public void RemoveAt(int index)
		{
			--_length;

			if (_length != index)
			{
				ResortArray(index);
			}
		}

		private void ResortArray(int index)
		{
			var newLength = _length - index;
			Array.Copy(buffer, index + 1, buffer, index, newLength);
		}

		public void AddRange(T[] array)
		{
			if (buffer == null || _length + array.Length > buffer.Length)
			{
				SetCapacity(buffer != null ? Mathf.Max(buffer.Length << 1, array.Length) : array.Length);
			}

			Array.Copy(array, 0, buffer, _length, array.Length);
			_length += array.Length;
		}

		public void AddRange(T[] array, int startIndex, int length)
		{
			if (buffer == null || _length + length > buffer.Length)
			{
				SetCapacity(buffer != null ? Mathf.Max(buffer.Length << 1, length) : length);
			}

			Array.Copy(array, startIndex, buffer, _length, length);
			_length += length;
		}

		public void RemoveRange(int index, int length)
		{
			Assert.IsNotNull(buffer);
			Assert.IsFalse(index + length > buffer.Length);

			var copyLength = _length - length;
			Array.Copy(buffer, index + length, buffer, index, copyLength);
			_length -= length;
		}
	}
}
