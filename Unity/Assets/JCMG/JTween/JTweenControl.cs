
using UnityEngine;

namespace JCMG.JTween
{
	[RequireComponent(
		typeof(SingleTransformTweener),
		typeof(BatchTransformTweener))]
	public sealed partial class JTweenControl : Singleton<JTweenControl>
	{
		// Constants
		private const byte TRUE = 1;
		private const byte FALSE = 0;
		private const short INFINITE_LOOP = -1;

		private SingleTransformTweener _singleTransformTweener;
		private BatchTransformTweener _batchTransformTweener;

		protected override void Awake()
		{
			base.Awake();

			_singleTransformTweener = GetComponent<SingleTransformTweener>();
			_batchTransformTweener = GetComponent<BatchTransformTweener>();
		}
	}
}
