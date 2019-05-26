using UnityEditor;
using UnityEngine;

namespace JCMG.JTween.Editor
{
	internal static class MenuItems
	{
		private const string ALREADY_EXISTS_WARNING =
			"[JTween] JTweenControl is already present in the current scene.";

		[MenuItem(EditorConstants.MENU_ITEM_ROOT + "Add JTweenControl to Scene")]
		public static void AddJTweenControlToScene()
		{
			var jTweenControl = Object.FindObjectOfType<JTweenControl>();
			if (jTweenControl == null)
			{
				var newGameObject = new GameObject(typeof(JTweenControl).Name);
				jTweenControl = newGameObject.AddComponent<JTweenControl>();
				jTweenControl.EnsureDependencies();
			}
			else
			{
				Debug.Log(ALREADY_EXISTS_WARNING, jTweenControl.gameObject);
			}

			EditorGUIUtility.PingObject(jTweenControl.gameObject);
		}
	}
}
