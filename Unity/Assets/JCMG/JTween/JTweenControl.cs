
using UnityEngine;

namespace JCMG.JTween
{
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

			_singleTransformTweener = GetComponent<SingleTransformTweener>();
			_batchTransformTweener = GetComponent<BatchTransformTweener>();
		}
	}
}
