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

		protected override void Awake()
		{
			base.Awake();

			_waitWhileTweensComplete = new WaitForSeconds(_duration * ( _loopCount + 1) + 0.1f);
		}

		protected override void CreateLargeNumberOfTransformTweens()
		{
			base.CreateLargeNumberOfTransformTweens();

			StartCoroutine(TestCapacityOfTweens());
		}

		private IEnumerator TestCapacityOfTweens()
		{
			yield return _delayWaitToStartTween;

			for (var i = 0; i < trs.Count; i++)
			{
				JTweenControl.Instance.Move(
					trs[i],
					trs[i].position,
					new Vector3(0, 0) + Vector3.forward * 100f,
					_duration,
					SpaceType.Local,
					_easeType,
					_loopType,
					_loopCount);
			}
		}

		protected override void CreateIntermittentTransformTweens()
		{
			base.CreateIntermittentTransformTweens();

			StartCoroutine(SpawnTweensIntermittently());
		}

		private IEnumerator SpawnTweensIntermittently()
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

			for (var i = 0; i < trs.Count; i++)
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

				JTweenControl.Instance.RotateY(
					tr,
					360,
					_duration,
					_easeType,
					_loopType,
					_loopCount);
			}

			yield return _waitWhileTweensComplete;
		}
	}
}
