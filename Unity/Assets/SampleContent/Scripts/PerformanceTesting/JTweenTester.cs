using System;
using System.Collections;
using System.Collections.Generic;
using JCMG.JTween;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SampleContent
{
	internal sealed class JTweenTester : TweenTesterBase
	{
		[SerializeField]
		private EaseType _easeType;

		[SerializeField]
		private LoopType _loopType;

		private Vector3[] _from;
		private Vector3[] _to;

		protected override void Awake()
		{
			base.Awake();

			_waitWhileTweensComplete = new WaitForSeconds(_duration * ( _loopCount + 1) + 0.1f);
		}

		protected override void CreateLargeNumberOfSingleTransformTweens()
		{
			base.CreateLargeNumberOfSingleTransformTweens();

			StartCoroutine(TestSingleBatchCapacityOfTweens());
		}

		protected override void CreateLargeNumberOfBatchTransformTweens()
		{
			base.CreateLargeNumberOfBatchTransformTweens();

			StartCoroutine(TestBatchCapacityOfTweens());
		}

		private IEnumerator TestSingleBatchCapacityOfTweens()
		{
			yield return _delayWaitToStartTween;

			for (var i = 0; i < trs.Length; i++)
			{
				JTweenControl.Instance.Move(
					trs[i],
					trs[i].position,
					trs[i].position + Vector3.forward * 100f,
					_duration,
					SpaceType.World,
					_easeType,
					_loopType,
					_loopCount);
			}
		}

		private IEnumerator TestBatchCapacityOfTweens()
		{
			yield return _delayWaitToStartTween;

			_from = new Vector3[trs.Length];
			_from.PopulatePositionArray(trs, SpaceType.World);

			_to = new Vector3[trs.Length];
			Array.Copy(_from, _to, _from.Length);
			for (var i = 0; i < _to.Length; i++)
			{
				_to[i] += Vector3.forward * 100f;
			}

			JTweenControl.Instance.BatchMove(
				trs,
				_from,
				_to,
				_duration,
				SpaceType.Local,
				_easeType,
				_loopType,
				_loopCount);
		}

		protected override void CreateIntermittentSingleTransformTweens()
		{
			base.CreateIntermittentSingleTransformTweens();

			StartCoroutine(SpawnSingleTweensIntermittently());
		}

		private IEnumerator SpawnSingleTweensIntermittently()
		{
			var queue = new Queue<Transform>(trs);
			yield return _delayWaitToStartTween;

			while (queue.Count > 0)
			{
				var randomSpawnAmount = Mathf.Min(Random.Range(_minSpawn, _maxSpawn), queue.Count);
				while (randomSpawnAmount > 0)
				{
					var tr = queue.Dequeue();
					JTweenControl.Instance.Move(
						tr,
						tr.position,
						tr.position + Vector3.forward * 100f,
						_duration,
						SpaceType.World,
						_easeType,
						_loopType,
						_loopCount);

					randomSpawnAmount--;
				}
				yield return new WaitForSeconds(_tweenSpawnInterval);
			}

			yield return _waitWhileTweensComplete;

			CompleteTweenTest();
		}

		protected override void CreateIntermittentBatchTransformTweens()
		{
			base.CreateIntermittentBatchTransformTweens();

			StartCoroutine(SpawnBatchTweensIntermittently());
		}

		private IEnumerator SpawnBatchTweensIntermittently()
		{
			_from = new Vector3[trs.Length];
			_from.PopulatePositionArray(trs, SpaceType.World);

			_to = new Vector3[trs.Length];
			Array.Copy(_from, _to, _from.Length);
			for (var i = 0; i < _to.Length; i++)
			{
				_to[i] += Vector3.forward * 100f;
			}

			yield return _delayWaitToStartTween;

			var currentCount = 0;
			while (currentCount < trs.Length - 1)
			{
				var numberOfItemsRemaining = trs.Length - currentCount;
				var randomSpawnAmount = Mathf.Min(Random.Range(_minSpawn, _maxSpawn), numberOfItemsRemaining);
				JTweenControl.Instance.BatchMove(
					trs,
					_from,
					_to,
					currentCount,
					randomSpawnAmount,
					_duration,
					SpaceType.World,
					_easeType,
					_loopType,
					_loopCount);
				currentCount += randomSpawnAmount;
				yield return new WaitForSeconds(_tweenSpawnInterval);
			}

			yield return _waitWhileTweensComplete;

			CompleteTweenTest();
		}

		protected override void CreateSingleAndBatchTweens()
		{
			base.CreateSingleAndBatchTweens();

			StartCoroutine(SpawnSingleAndBatchTweens());
		}

		private IEnumerator SpawnSingleAndBatchTweens()
		{
			_from = new Vector3[trs.Length];
			_from.PopulatePositionArray(trs, SpaceType.World);

			_to = new Vector3[trs.Length];
			Array.Copy(_from, _to, _from.Length);
			for (var i = 0; i < _to.Length; i++)
			{
				_to[i] += Vector3.forward * 100f;
			}

			yield return _delayWaitToStartTween;

			var doTweenSingles = true;
			for (var i = 0; i < trs.Length;)
			{
				if (doTweenSingles)
				{
					var numberOfItemsRemaining = trs.Length - i;
					var randomSpawnAmount = Mathf.Min(Random.Range(_minSpawn, _maxSpawn), numberOfItemsRemaining);
					for (var j = i; j < i + randomSpawnAmount; j++)
					{
						var tr = trs[j];
						JTweenControl.Instance.Move(
							tr,
							_from[j],
							_to[j],
							_duration,
							SpaceType.World,
							_easeType,
							_loopType,
							_loopCount);
					}

					doTweenSingles = false;

					i += randomSpawnAmount;

					yield return null;
				}
				else
				{
					var numberOfItemsRemaining = trs.Length - i;
					var randomSpawnAmount = Mathf.Min(Random.Range(_minSpawn, _maxSpawn), numberOfItemsRemaining);

					JTweenControl.Instance.BatchMove(
						trs,
						_from,
						_to,
						i,
						randomSpawnAmount,
						_duration,
						SpaceType.World,
						_easeType,
						_loopType,
						_loopCount);

					doTweenSingles = true;

					i += randomSpawnAmount;

					yield return null;
				}
			}
		}

		protected override void CreateMultipleTargetedTweens()
		{
			base.CreateMultipleTargetedTweens();

			StartCoroutine(SpawnMultipleTargetedTween());
		}

		private IEnumerator SpawnMultipleTargetedTween()
		{
			yield return _delayWaitToStartTween;

			var tr = trs[0];
			JTweenControl.Instance.Move(
				tr,
				tr.position,
				tr.position + Vector3.forward * 100f,
				_duration,
				SpaceType.World,
				_easeType,
				_loopType,
				_loopCount);

			JTweenControl.Instance.Scale(
				tr,
				tr.localScale,
				tr.localScale * 10,
				_duration,
				_easeType,
				_loopType,
				_loopCount);

			JTweenControl.Instance.Rotate(
				tr,
				Quaternion.identity,
				Quaternion.Euler(Random.Range(0, 180), Random.Range(0, 180), Random.Range(0, 180)),
				_duration,
				SpaceType.World,
				_easeType,
				_loopType,
				_loopCount);

			yield return _waitWhileTweensComplete;
		}

		protected override void CreateMultipleTweensInConcert()
		{
			base.CreateMultipleTweensInConcert();

			StartCoroutine(CreateConcertTweens());
		}

		private IEnumerator CreateConcertTweens()
		{
			yield return _delayWaitToStartTween;

			for (var i = 0; i < trs.Length; i++)
			{
				var tr = trs[i];
				JTweenControl.Instance.Move(
					tr,
					tr.position,
					Vector3.zero,
					_duration,
					SpaceType.World,
					_easeType,
					_loopType,
					_loopCount);

				JTweenControl.Instance.Scale(
					tr,
					tr.localScale,
					tr.localScale * .75f,
					_duration,
					_easeType,
					_loopType,
					_loopCount);

				JTweenControl.Instance.RotateOnAxis(
					tr,
					360,
					_duration,
					RotateMode.Y,
					SpaceType.World,
					_easeType,
					_loopType,
					_loopCount);
			}

			yield return _waitWhileTweensComplete;
		}
	}
}
