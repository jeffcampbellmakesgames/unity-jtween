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

		[MenuItem(EditorConstants.MENU_ITEM_HELP_ROOT + "Open Github Page")]
		public static void OpenBrowserToGithub()
		{
			Application.OpenURL(EditorConstants.GITHUB_MASTER_URL);
		}

		[MenuItem(EditorConstants.MENU_ITEM_HELP_ROOT + "Open Online Manual")]
		public static void OpenBrowserToOnlineManual()
		{
			Application.OpenURL(EditorConstants.GITHUB_DOCUMENTATION_URL);
		}

		[MenuItem(EditorConstants.MENU_ITEM_HELP_ROOT + "Open Local Manual")]
		public static void OpenLocalManual()
		{
			var assetPath = AssetDatabase.GUIDToAssetPath(EditorConstants.HELP_PDF_GUID);
			var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
			AssetDatabase.OpenAsset(asset);
		}

		[MenuItem(EditorConstants.MENU_ITEM_HELP_ROOT + "Open Local API Reference")]
		public static void OpenLocalAPIReference()
		{
			var assetPath = AssetDatabase.GUIDToAssetPath(EditorConstants.API_PDF_GUID);
			var asset = AssetDatabase.LoadAssetAtPath<Object>(assetPath);
			AssetDatabase.OpenAsset(asset);
		}

		[MenuItem(EditorConstants.MENU_ITEM_HELP_ROOT + "Donate")]
		public static void OpenDonateCoffeePage()
		{
			Application.OpenURL(EditorConstants.DONATE_COFFEE_URL);
		}
	}
}
