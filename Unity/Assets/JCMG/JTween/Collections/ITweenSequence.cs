using System;

namespace JCMG.JTween
{
	public interface ITweenSequence : ITweenCollection
	{
		void AddOnStep(Action onStep);
	}
}
