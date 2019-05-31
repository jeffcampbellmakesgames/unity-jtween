namespace JCMG.JTween
{
	internal static class RuntimeConstants
	{
		// Pooling
		public const int DEFAULT_FAST_LIST_SIZE = 10000;

		public const int DEFAULT_RECYCLE_AMOUNT_PER_FRAME = 500;

		// Warnings
		public const string HANDLE_NOT_FOUND =
			"[JTween] Tween not found for this handle, please remove local reference";

		public const string HANDLE_BATCH_NOT_FOUND =
			"[JTween] Tween Batch not found for this handle, please remove local reference";

		public const string INVALID_ROTATE_MODE =
			"[JTween] RotateMode.XYZ should not be used when rotating on a single axis.";
	}
}
