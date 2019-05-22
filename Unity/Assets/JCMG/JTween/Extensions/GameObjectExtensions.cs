using UnityEngine;

namespace JCMG.JTween
{
	public static class GameObjectExtensions
	{
		/// <summary>
		/// Finds or creates <typeparamref name="T"/> component instance on this <see cref="GameObject"/>
		/// instance.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="gameObject"></param>
		/// <returns></returns>
		internal static T FindOrCreate<T>(this GameObject gameObject) where T : Component
		{
			var component = gameObject.GetComponent<T>();
			if (component == null)
			{
				component = gameObject.AddComponent<T>();
			}

			return component;
		}
	}
}
