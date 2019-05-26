using Unity.Collections.LowLevel.Unsafe;
using Unity.Mathematics;

namespace JCMG.JTween
{
	internal struct TweenLifetime
	{
		public float duration;
		public float current;
		public short loopCount;
		public short originalLoopCount;
		public EaseType easeType;
		public LoopType loopType;
		public byte isReversed;

		private const byte TRUE = 1;
		private const byte FALSE = 0;
		private const short INFINITE_LOOP = -1;

		public void Update(float deltaTime)
		{
			current = math.min(current + deltaTime, duration);
			if (loopType == LoopType.None || GetProgress() < 1)
			{
				return;
			}

			if (loopCount == INFINITE_LOOP || loopCount > 0)
			{
				current = 0f;
				if (loopType == LoopType.Restart)
				{
					if (loopCount > 0)
					{
						--loopCount;
					}
				}
				else if (loopType == LoopType.PingPong)
				{
					isReversed = isReversed == TRUE ? FALSE : TRUE;
					if (isReversed == TRUE && loopCount > 0)
					{
						--loopCount;
					}
				}
			}
		}

		public float GetProgress()
		{
			if (FastApproximately(current, 0, 0.00001f))
			{
				return 0f;
			}

			return math.min(current / duration, 1f);
		}

		public void Restart()
		{
			current = 0;
			loopCount = originalLoopCount;
			isReversed = FALSE;
		}

		public static long SizeOf()
		{
			return UnsafeUtility.SizeOf<TweenLifetime>();
		}

		public float GetEase()
		{
			switch (easeType)
			{
				case EaseType.Linear:
					return EaseNone(current, duration);

				case EaseType.BackIn:
					return EaseInBack(current, duration);
				case EaseType.BackOut:
					return EaseOutBack(current, duration);
				case EaseType.BackInOut:
					return EaseInOutBack(current, duration);

				case EaseType.BounceIn:
					return EaseInBounce(current, duration);
				case EaseType.BounceOut:
					return EaseOutBounce(current, duration);
				case EaseType.BounceInOut:
					return EaseInOutBounce(current, duration);

				case EaseType.CircIn:
					return EaseInCircular(current, duration);
				case EaseType.CircOut:
					return EaseOutCircular(current, duration);
				case EaseType.CircInOut:
					return EaseInOutCircular(current, duration);

				case EaseType.CubicIn:
					return EaseInCubic(current, duration);
				case EaseType.CubicOut:
					return EaseOutCubic(current, duration);
				case EaseType.CubicInOut:
					return EaseInOutCubic(current, duration);

				case EaseType.ElasticIn:
					return EaseInElastic(current, duration);
				case EaseType.ElasticOut:
					return EaseOutElastic(current, duration);
				case EaseType.ElasticInOut:
					return EaseInOutElastic(current, duration);
				case EaseType.Punch:
					return Punch2Elastic(current, duration);

				case EaseType.ExpoIn:
					return EaseInExponential(current, duration);
				case EaseType.ExpoOut:
					return EaseOutExponential(current, duration);
				case EaseType.ExpoInOut:
					return EaseInOutExponential(current, duration);

				case EaseType.QuadIn:
					return EaseInQuadratic(current, duration);
				case EaseType.QuadOut:
					return EaseOutQuadratic(current, duration);
				case EaseType.QuadInOut:
					return EaseInOutQuadratic(current, duration);

				case EaseType.QuartIn:
					return EaseInQuart(current, duration);
				case EaseType.QuartOut:
					return EaseOutQuart(current, duration);
				case EaseType.QuartInOut:
					return EaseInOutQuart(current, duration);

				case EaseType.QuintIn:
					return EaseInQuint(current, duration);
				case EaseType.QuintOut:
					return EaseOutQuint(current, duration);
				case EaseType.QuintInOut:
					return EaseInOutQuint(current, duration);

				case EaseType.SineIn:
					return EaseInSinusoidal(current, duration);
				case EaseType.SineOut:
					return EaseOutSinusoidal(current, duration);
				case EaseType.SineInOut:
					return EaseInOutSinusoidal(current, duration);

				default:
					return EaseNone(current, duration);
			}
		}

		private static float EaseNone(float t, float d)
		{
			return t / d;
		}

		private static float EaseInQuadratic(float t, float d)
		{
			return ( t /= d ) * t;
		}

		private static float EaseOutQuadratic(float t, float d)
		{
			return -1 * ( t /= d ) * ( t - 2 );
		}

		private static float EaseInOutQuadratic(float t, float d)
		{
			if (( t /= d / 2 ) < 1)
			{
				return 0.5f * t * t;
			}

			return -0.5f * ( --t * ( t - 2 ) - 1 );
		}

		private static float EaseInBack(float t, float d)
		{
			return ( t /= d ) * t * ( ( 1.70158f + 1 ) * t - 1.70158f );
		}

		private static float EaseOutBack(float t, float d)
		{
			return ( t = t / d - 1 ) * t * ( ( 1.70158f + 1 ) * t + 1.70158f ) + 1;
		}

		private static float EaseInOutBack(float t, float d)
		{
			float s = 1.70158f;
			if (( t /= d / 2 ) < 1)
			{
				return 0.5f * ( t * t * ( ( ( s *= 1.525f ) + 1 ) * t - s ) );
			}

			return 0.5f * ( ( t -= 2 ) * t * ( ( ( s *= 1.525f ) + 1 ) * t + s ) + 2 );
		}

		private static float EaseOutBounce(float t, float d)
		{
			if (( t /= d ) < 1 / 2.75)
			{
				return 7.5625f * t * t;
			}

			if (t < 2 / 2.75)
			{
				return 7.5625f * ( t -= 1.5f / 2.75f ) * t + .75f;
			}

			if (t < 2.5 / 2.75)
			{
				return 7.5625f * ( t -= 2.25f / 2.75f ) * t + .9375f;
			}

			return 7.5625f * ( t -= 2.625f / 2.75f ) * t + .984375f;
		}

		private static float EaseInBounce(float t, float d)
		{
			return 1 - EaseOutBounce(d - t, d);
		}

		private static float EaseInOutBounce(float t, float d)
		{
			if (t < d / 2)
			{
				return EaseInBounce(t * 2, d) * 0.5f;
			}

			return EaseOutBounce(t * 2 - d, d) * .5f + 1 * 0.5f;
		}

		private static float EaseInCircular(float t, float d)
		{
			return -( math.sqrt(1 - ( t /= d ) * t) - 1 );
		}

		private static float EaseOutCircular(float t, float d)
		{
			return math.sqrt(1 - ( t = t / d - 1 ) * t);
		}

		private static float EaseInOutCircular(float t, float d)
		{
			if (( t /= d / 2 ) < 1)
			{
				return -0.5f * ( math.sqrt(1 - t * t) - 1 );
			}

			return 0.5f * ( math.sqrt(1 - ( t -= 2 ) * t) + 1 );
		}

		private static float EaseInCubic(float t, float d)
		{
			return ( t /= d ) * t * t;
		}

		private static float EaseOutCubic(float t, float d)
		{
			return ( t = t / d - 1 ) * t * t + 1;
		}

		private static float EaseInOutCubic(float t, float d)
		{
			if (( t /= d / 2 ) < 1)
			{
				return 0.5f * t * t * t;
			}

			return 0.5f * ( ( t -= 2 ) * t * t + 2 );
		}

		private static float EaseInElastic(float t, float d)
		{
			if (t == 0)
			{
				return 0;
			}

			if (( t /= d ) == 1)
			{
				return 1;
			}

			float p = d * .3f;
			float s = p / 4;
			return -( 1 * math.pow(2, 10 * ( t -= 1 )) * math.sin(( t * d - s ) * ( 2 * math.PI ) / p) );
		}

		private static float EaseOutElastic(float t, float d)
		{
			if (t == 0)
			{
				return 0;
			}

			if (( t /= d ) == 1)
			{
				return 1;
			}

			float p = d * .3f;
			float s = p / 4;
			return 1 * math.pow(2, -10 * t) * math.sin(( t * d - s ) * ( 2 * math.PI ) / p) + 1;
		}

		private static float EaseInOutElastic(float t, float d)
		{
			if (t == 0)
			{
				return 0;
			}

			if (( t /= d / 2 ) == 2)
			{
				return 1;
			}

			float p = d * ( .3f * 1.5f );
			float s = p / 4;

			if (t < 1)
			{
				return -.5f * ( math.pow(2, 10 * ( t -= 1 )) * math.sin(( t * d - s ) * ( 2 * math.PI ) / p) );
			}

			return math.pow(2f, -10f * ( t -= 1f )) * math.sin(( t * d - s ) * ( 2 * math.PI ) / p) * 0.5f + 1f;
		}

		private static float PunchElastic(float t, float d)
		{
			const float p = 0.3f;
			return math.pow(2, -10 * t) * math.sin(t * ( 2 * math.PI ) / p);
		}

		private static float Punch2Elastic(float t, float d)
		{
			if (t == 0)
			{
				return 0;
			}

			const float p = 0.3f;
			return math.pow(2, -10 * t) * math.sin(t * ( 2 * math.PI ) / p);
		}

		private static float EaseInExponential(float t, float d)
		{
			return t == 0 ? 0 : math.pow(2, 10 * ( t / d - 1 ));
		}

		private static float EaseOutExponential(float t, float d)
		{
			return t == d ? 1 : -math.pow(2, -10 * t / d) + 1;
		}

		private static float EaseInOutExponential(float t, float d)
		{
			if (t == 0)
			{
				return 0;
			}

			if (t == d)
			{
				return 1;
			}

			if (( t /= d / 2 ) < 1)
			{
				return 0.5f * math.pow(2, 10 * ( t - 1 ));
			}

			return 0.5f * ( -math.pow(2, -10 * --t) + 2 );
		}

		private static float EaseInQuart(float t, float d)
		{
			return ( t /= d ) * t * t * t;
		}

		private static float EaseOutQuart(float t, float d)
		{
			return -1 * ( ( t = t / d - 1 ) * t * t * t - 1 );
		}

		private static float EaseInOutQuart(float t, float d)
		{
			t /= d / 2;
			if (t < 1)
			{
				return 0.5f * t * t * t * t;
			}

			t -= 2;
			return -0.5f * ( t * t * t * t - 2 );
		}

		private static float EaseInQuint(float t, float d)
		{
			return ( t /= d ) * t * t * t * t;
		}

		private static float EaseOutQuint(float t, float d)
		{
			return ( t = t / d - 1 ) * t * t * t * t + 1;
		}

		private static float EaseInOutQuint(float t, float d)
		{
			if (( t /= d / 2 ) < 1)
			{
				return 0.5f * t * t * t * t * t;
			}

			return 0.5f * ( ( t -= 2 ) * t * t * t * t + 2 );
		}

		private static float EaseInSinusoidal(float t, float d)
		{
			return -1 * math.cos(t / d * ( math.PI / 2 )) + 1f;
		}

		private static float EaseOutSinusoidal(float t, float d)
		{
			return math.sin(t / d * ( math.PI / 2 ));
		}

		private static float EaseInOutSinusoidal(float t, float d)
		{
			return -0.5f * ( math.cos(math.PI * t / d) - 1 );
		}

		public static bool FastApproximately(float a, float b, float threshold)
		{
			return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= threshold;
		}

		public static bool FastApproximately(float a, float b)
		{
			return ((a - b) < 0 ? ((a - b) * -1) : (a - b)) <= 0.00001f;
		}
	}
}
