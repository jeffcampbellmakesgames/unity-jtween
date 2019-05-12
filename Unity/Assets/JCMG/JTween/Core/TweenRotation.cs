﻿using System;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;

namespace JCMG.JTween
{
	internal struct TweenRotation
	{
		public quaternion from;
		public quaternion to;
		public float angle;

		public quaternion GetRotation(float ease, bool isReversed, RotateMode rotateMode)
		{
			switch (rotateMode)
			{
				case RotateMode.XYZ:
					var currentTo = isReversed ? from : to;
					var currentFrom = isReversed ? to : from;
					return Quaternion.Lerp(currentFrom, currentTo, ease);
				case RotateMode.X:
					return Quaternion.Euler(ease * angle, from.value.y, from.value.z);
				case RotateMode.Y:
					return Quaternion.Euler(from.value.x, ease * angle, from.value.z);
				case RotateMode.Z:
					return Quaternion.Euler(from.value.x, from.value.y, ease * angle);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenRotation>();
		}
	}
}
