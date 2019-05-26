using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace JCMG.JTween
{
	/// <summary>
	/// Extension methods for arrays
	/// </summary>
	public static class ArrayExtensions
	{
		/// <summary>
		/// Assigns the <typeparamref name="T"/> <paramref name="value"/> to all elements in this
		/// array.
		/// </summary>
		public static void Populate<T>(this T[] array, T value)
		{
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

		/// <summary>
		/// Populates the <see cref="Vector3"/> <paramref name="positionArray"/> with the appropriate position
		/// from <see cref="Transform"/> <paramref name="transformArray"/> based on the passed
		/// <see cref="SpaceType"/> <paramref name="spaceType"/>. The <paramref name="positionArray"/> and
		/// <paramref name="transformArray"/> must be of equal length.
		/// </summary>
		/// <param name="positionArray">The array of <see cref="Vector3"/>s positions will be assigned to.</param>
		/// <param name="transformArray">The array of <see cref="Transform"/>s positions will be assigned from.</param>
		/// <param name="spaceType">Whether or not the position assigned should be in world or local space.</param>
		public static void PopulatePositionArray(this Vector3[] positionArray, Transform[] transformArray, SpaceType spaceType)
		{
			Assert.AreEqual(positionArray.Length, transformArray.Length);

			if (spaceType == SpaceType.Local)
			{
				for (var i = 0; i < positionArray.Length; i++)
				{
					positionArray[i] = transformArray[i].localPosition;
				}
			}
			else
			{
				for (var i = 0; i < positionArray.Length; i++)
				{
					positionArray[i] = transformArray[i].position;
				}
			}
		}

		/// <summary>
		/// Populates the <see cref="Vector3"/> <paramref name="positionArray"/> with the appropriate position
		/// from IList <paramref name="transformList"/> based on the passed
		/// <see cref="SpaceType"/> <paramref name="spaceType"/>. The <paramref name="positionArray"/> and
		/// <paramref name="transformList"/> must be of equal length.
		/// </summary>
		/// <param name="positionArray">The array of <see cref="Vector3"/>s positions will be assigned to.</param>
		/// <param name="transformList">The IList of <see cref="Transform"/>s positions will be assigned from.</param>
		/// <param name="spaceType">Whether or not the position assigned should be in world or local space.</param>
		public static void PopulatePositionArray(this Vector3[] positionArray, IList<Transform> transformList, SpaceType spaceType)
		{
			Assert.AreEqual(positionArray.Length, transformList.Count);

			if (spaceType == SpaceType.Local)
			{
				for (var i = 0; i < positionArray.Length; i++)
				{
					positionArray[i] = transformList[i].localPosition;
				}
			}
			else
			{
				for (var i = 0; i < positionArray.Length; i++)
				{
					positionArray[i] = transformList[i].position;
				}
			}
		}

		/// <summary>
		/// Populates the <see cref="Quaternion"/> <paramref name="rotationArray"/> with the appropriate rotation
		/// from <see cref="Transform"/> <paramref name="transformArray"/> based on the passed
		/// <see cref="SpaceType"/> <paramref name="spaceType"/>. The <paramref name="rotationArray"/> and
		/// <paramref name="transformArray"/> must be of equal length.
		/// </summary>
		/// <param name="rotationArray">The array of <see cref="Quaternion"/>s rotations will be assigned to.</param>
		/// <param name="transformArray">The array of <see cref="Transform"/>s rotations will be assigned from.</param>
		/// <param name="spaceType">Whether or not the rotation assigned should be in world or local space.</param>
		public static void PopulateRotationArray(this Quaternion[] rotationArray, Transform[] transformArray, SpaceType spaceType)
		{
			Assert.AreEqual(rotationArray.Length, transformArray.Length);

			if (spaceType == SpaceType.Local)
			{
				for (var i = 0; i < rotationArray.Length; i++)
				{
					rotationArray[i] = transformArray[i].localRotation;
				}
			}
			else
			{
				for (var i = 0; i < rotationArray.Length; i++)
				{
					rotationArray[i] = transformArray[i].rotation;
				}
			}
		}

		/// <summary>
		/// Populates the <see cref="Quaternion"/> <paramref name="rotationArray"/> with the appropriate rotation
		/// from IList <paramref name="transformList"/> based on the passed
		/// <see cref="SpaceType"/> <paramref name="spaceType"/>. The <paramref name="rotationArray"/> and
		/// <paramref name="transformList"/> must be of equal length.
		/// </summary>
		/// <param name="rotationArray">The array of <see cref="Quaternion"/>s rotations will be assigned to.</param>
		/// <param name="transformList">The IList of <see cref="Transform"/>s rotations will be assigned from.</param>
		/// <param name="spaceType">Whether or not the rotation assigned should be in world or local space.</param>
		public static void PopulateRotationArray(this Quaternion[] rotationArray, IList<Transform> transformList, SpaceType spaceType)
		{
			Assert.AreEqual(rotationArray.Length, transformList.Count);

			if (spaceType == SpaceType.Local)
			{
				for (var i = 0; i < rotationArray.Length; i++)
				{
					rotationArray[i] = transformList[i].localRotation;
				}
			}
			else
			{
				for (var i = 0; i < rotationArray.Length; i++)
				{
					rotationArray[i] = transformList[i].rotation;
				}
			}
		}

		/// <summary>
		/// Populates the <see cref="Vector3"/> <paramref name="scaleArray"/> with the scale from
		/// array <see cref="Transform"/> <paramref name="transformArray"/>. The <paramref name="scaleArray"/> and
		/// <paramref name="transformArray"/> must be of equal length.
		/// </summary>
		/// <param name="scaleArray">The array of <see cref="Vector3"/>s scale will be assigned to.</param>
		/// <param name="transformArray">The array of <see cref="Transform"/>s scale will be assigned from.</param>
		public static void PopulateScaleArray(this Vector3[] scaleArray, Transform[] transformArray)
		{
			Assert.AreEqual(scaleArray.Length, transformArray.Length);

			for (var i = 0; i < scaleArray.Length; i++)
			{
				scaleArray[i] = transformArray[i].localScale;
			}
		}

		/// <summary>
		/// Populates the <see cref="Vector3"/> <paramref name="scaleArray"/> with the scale from
		/// IList <see cref="Transform"/> <paramref name="transformList"/>. The <paramref name="scaleArray"/> and
		/// <paramref name="transformList"/> must be of equal length.
		/// </summary>
		/// <param name="scaleArray">The array of <see cref="Vector3"/>s scale will be assigned to.</param>
		/// <param name="transformList">The IList of <see cref="Transform"/>s scale will be assigned from.</param>
		public static void PopulateScaleArray(this Vector3[] scaleArray, IList<Transform> transformList)
		{
			Assert.AreEqual(scaleArray.Length, transformList.Count);

			for (var i = 0; i < scaleArray.Length; i++)
			{
				scaleArray[i] = transformList[i].localScale;
			}
		}
	}
}
