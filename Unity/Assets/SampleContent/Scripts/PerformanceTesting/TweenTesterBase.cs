using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SampleContent
{
	public abstract class TweenTesterBase : MonoBehaviour
	{
		[Serializable]
		private enum TestingMode
		{
			Capacity,
			Intermittent,
			MultipleTargetedTransform,
			VisuallyInteresting
		}

		[Header("Prefab")]
		[SerializeField]
		private GameObject _moveGameObject;

		[Header("Layout")]
		[SerializeField]
		protected int _startX = 1;

		[SerializeField]
		private int _startY = 1;

		[SerializeField]
		protected float _spacing = 5f;

		[Header("Animation")]
		[Min(0)]
		[SerializeField]
		protected float _duration;

		[Min(0)]
		[SerializeField]
		protected int _loopCount;

		[Header("Data (Large Capacity Testing Mode)")]
		[SerializeField]
		protected int _rowColumnLength = 100;

		[Header("Data (Intermittent Testing Mode)")]
		[Min(0)]
		[SerializeField]
		protected int _capacity = 100;

		[Range(0f, 10f)]
		[SerializeField]
		protected float _tweenSpawnInterval = 1f;

		[Range(0f, 1000f)]
		[SerializeField]
		protected int _minSpawn = 1;

		[Range(0f, 1000f)]
		[SerializeField]
		protected int _maxSpawn = 10;

		[Header("Data (Visually Interesting Mode)")]
		[Min(0)]
		[SerializeField]
		protected float _ySpacing;

		[SerializeField]
		protected AnimationCurve _sphereCurve;

		[Min(0)]
		[SerializeField]
		protected int _numberOfLevels;

		[Min(0)]
		[SerializeField]
		protected int _maxItemsPerLevel;

		[Min(0)]
		[SerializeField]
		protected float _radius;

		[Header("Testing Mode")]
		[SerializeField]
		private TestingMode _mode;

		[Min(0f)]
		[SerializeField]
		protected float _delay = 5f;

		protected List<Transform> trs;

		protected WaitForSeconds _waitWhileTweensComplete;
		protected WaitForSeconds _delayWaitToStartTween;

		protected virtual void Awake()
		{
			_waitWhileTweensComplete = new WaitForSeconds(_duration * ( _loopCount + 1 ) + 0.1f);
			_delayWaitToStartTween = new WaitForSeconds(_delay);
		}

		private void Start()
		{
			switch (_mode)
			{
				case TestingMode.Capacity:
					CreateLargeNumberOfTransformTweens();
					break;
				case TestingMode.Intermittent:
					CreateIntermittentTransformTweens();
					break;
				case TestingMode.MultipleTargetedTransform:
					CreateMultipleTargetedTweens();
					break;
				case TestingMode.VisuallyInteresting:
					CreateMultipleTweensInConcert();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		protected virtual void CreateMultipleTargetedTweens()
		{
			trs = new List<Transform>();
			var obj = Instantiate(_moveGameObject, Vector3.zero, Quaternion.identity);
			trs.Add(obj.transform);
		}

		protected virtual void CreateLargeNumberOfTransformTweens()
		{
			trs = new List<Transform>(_rowColumnLength * _rowColumnLength);
			for (var i = 0; i < _rowColumnLength; i++)
			{
				for (var j = 0; j < _rowColumnLength; j++)
				{
					var position = new Vector3(_startX + i * _spacing, _startY + j * _spacing);
					var obj = Instantiate(_moveGameObject, position, Quaternion.identity);
					trs.Add(obj.transform);
				}
			}
		}

		protected void CompleteTweenTest()
		{
			Debug.Log("Completed Tweens!");
			#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPaused = true;
			#endif
		}

		protected virtual void CreateIntermittentTransformTweens()
		{
			trs = new List<Transform>(_capacity);
			for (var i = 0; i < _capacity; i++)
			{
				var position = new Vector3(_startX + i * _spacing, 0f);
				var obj = Instantiate(_moveGameObject, position, Quaternion.identity);
				trs.Add(obj.transform);
			}
		}

		protected virtual void CreateMultipleTweensInConcert()
		{
			trs = new List<Transform>();
			var numberOfLevelsToSpawn = _numberOfLevels * 2;
			for (var i = 0; i <= numberOfLevelsToSpawn; i++)
			{
				var y = i - _numberOfLevels;
				var angleFactor = (( i - (float)numberOfLevelsToSpawn ) / _numberOfLevels + 1 ) / 1;
				var normalizedFactor = Mathf.Abs(Mathf.Abs(angleFactor) - 1);
				var radiusFactor = _sphereCurve.Evaluate(normalizedFactor);
				var radiusLevel = _radius * radiusFactor;
				var numberOfItemsToSpawn = (int)(normalizedFactor * _maxItemsPerLevel);

				if (numberOfItemsToSpawn == 0)
				{
					continue;
				}

				var angle = 360f / numberOfItemsToSpawn;
				var currentAngle = 0f;

				while (currentAngle <= 360)
				{
					var pos = GetCirclePos(new Vector3(0, y * _ySpacing, 0), currentAngle, radiusLevel);
					var obj = Instantiate(_moveGameObject, pos, Quaternion.identity);
					obj.transform.LookAt(Vector3.zero);
					trs.Add(obj.transform);

					currentAngle += angle;
				}
			}
		}

		private Vector3 GetCirclePos(Vector3 center, float angle, float radius)
		{
			Vector3 pos;
			pos.x = center.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
			pos.y = center.y;
			pos.z = center.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);
			return pos;
		}

		protected Vector3 GetRandomScale()
		{
			return new Vector3(Random.Range(.75f, 1.5f), Random.Range(.75f, 1.5f), Random.Range(.75f, 1.5f));
		}

		protected Quaternion GetRandomRotation()
		{
			return Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180));
		}
	}
}
