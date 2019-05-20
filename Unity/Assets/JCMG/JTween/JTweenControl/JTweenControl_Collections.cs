namespace JCMG.JTween
{
	public sealed partial class JTweenControl
	{
		public ITweenSet NewSet()
		{
			return new TweenSet();
		}

		public ITweenSequence NewSequence()
		{
			return new TweenSequence();
		}
	}
}
