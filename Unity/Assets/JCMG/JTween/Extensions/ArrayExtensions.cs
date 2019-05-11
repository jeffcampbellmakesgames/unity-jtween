using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace JCMG.JTween
{
	public static class ArrayExtensions
	{
		public static void Populate<T>(this T[] array, T value)
		{
			for (var i = 0; i < array.Length; i++)
			{
				array[i] = value;
			}
		}

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

		public static void PopulateRotationArray(this Quaternion[] rotationArray, Transform[] transformList, SpaceType spaceType)
		{
			Assert.AreEqual(rotationArray.Length, transformList.Length);

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

		public static void PopulateScaleArray(this Vector3[] positionArray, Transform[] transformArray)
		{
			Assert.AreEqual(positionArray.Length, transformArray.Length);

			for (var i = 0; i < positionArray.Length; i++)
			{
				positionArray[i] = transformArray[i].localScale;
			}
		}

		public static void PopulateScaleArray(this Vector3[] positionArray, IList<Transform> transformList)
		{
			Assert.AreEqual(positionArray.Length, transformList.Count);

			for (var i = 0; i < positionArray.Length; i++)
			{
				positionArray[i] = transformList[i].localScale;
			}
		}
	}
}
