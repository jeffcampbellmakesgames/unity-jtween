
using UnityEngine;

namespace JCMG.JTween
{
	/// <summary>
	/// The global instance for JTween to interact with tweens, tween systems.
	/// </summary>
	[RequireComponent(
		typeof(SingleTransformTweener),
		typeof(BatchTransformTweener))]
	public sealed partial class JTweenControl : Singleton<JTweenControl>
	{
		// Job Runners
		private SingleTransformTweener _singleTransformTweener;
		private BatchTransformTweener _batchTransformTweener;

		// Constants
		private ITweenHandle _invalidTweenHandle;

		protected override void Awake()
		{
			base.Awake();

			EnsureDependencies();
		}

		private void EnsureDependencies()
		{
			_singleTransformTweener = gameObject.FindOrCreate<SingleTransformTweener>();
			_batchTransformTweener = gameObject.FindOrCreate<BatchTransformTweener>();
		}

		#if UNITY_EDITOR

		private void OnValidate()
		{
			EnsureDependencies();
		}

		#endif
	}
}
