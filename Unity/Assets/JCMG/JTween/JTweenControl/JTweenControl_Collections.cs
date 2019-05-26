namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		/// <summary>
		/// Creates a new instance of <see cref="ITweenSet"/>.
		/// </summary>
		/// <returns></returns>
		public ITweenSet NewSet()
		{
			return new TweenSet();
		}

		/// <summary>
		/// Creates a new instance of <see cref="ITweenSequence"/>.
		/// </summary>
		/// <returns></returns>
		public ITweenSequence NewSequence()
		{
			return new TweenSequence();
		}
	}
}
