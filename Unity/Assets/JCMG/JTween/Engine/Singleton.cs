using UnityEngine;

namespace JCMG.JTween
{
	public abstract class Singleton<T> : MonoBehaviour where T : Component
	{
		private static bool _applicationIsQuitting;

		private static T _instance;

		public static T Instance
		{
			get
			{
				if (!Exists && !_applicationIsQuitting)
				{
					_instance = FindObjectOfType<T>();

					if (!Exists)
					{
						_instance = new GameObject(typeof(T).Name).AddComponent<T>();
					}

					DontDestroyOnLoad(_instance);
				}

				return _instance;
			}
		}

		public static bool Exists
		{
			get { return _instance != null; }
		}

		protected virtual void Awake()
		{
			if (!Exists)
			{
				_instance = this as T;
				DontDestroyOnLoad(gameObject);
			}
			else if (_instance != this)
			{
				Destroy(gameObject);
			}
		}

		protected virtual void OnApplicationQuit()
		{
			_instance = null;
			Destroy(gameObject);
			_applicationIsQuitting = true;
		}
	}
}
