using UnityEngine;
using UnityEngine.UI;

public static class UITool {
	private static GameObject _dynamicCanvas = null;
	private static GameObject _staticCanvas = null;
	public static void ReleaseCanvas() {
		_dynamicCanvas = null;
	}

	public static GameObject FindUIGameObject(CanvasType canvasType, string uiName) {
		switch(canvasType) {
			case CanvasType.Dynamic:
				if(_dynamicCanvas == null)
					_dynamicCanvas = UnityTool.FindGameObject("DynamicCanvas");
				if(_dynamicCanvas == null)
					return null;
				return UnityTool.FindChildGameObject(_dynamicCanvas, uiName);
			case CanvasType.Static:
				if(_staticCanvas == null)
					_staticCanvas = UnityTool.FindGameObject("StaticCanvas");
				if(_staticCanvas == null)
					return null;
				return UnityTool.FindChildGameObject(_staticCanvas, uiName);
			default:
				return null;
		}
	}
	public static T GetUIComponent<T>(GameObject container, string uiName) where T : UnityEngine.Component {
		GameObject childGameObject = UnityTool.FindChildGameObject(container, uiName);
		if(childGameObject == null)
			return null;
		T tempObject = childGameObject.GetComponent<T>();
		if(tempObject == null) {
			Debug.LogWarning("元件[" + uiName + "]不是[" + typeof(T) + "]");
			return null;
		}
		return tempObject;
	}
	public static Button GetButton(string buttonName) {
		GameObject uiRoot = UnityTool.FindGameObject("DynamicCanvas");
		if(uiRoot == null) {
			Debug.LogWarning("場景上沒有DynamicCanvas");
			return null;
		}
		Transform[] children = uiRoot.GetComponentsInChildren<Transform>();
		foreach(Transform child in children) {
			if(child.name == buttonName) {
				Button tempButton = child.gameObject.GetComponent<Button>();
				if(tempButton == null)
					Debug.LogWarning("UI元件[" + buttonName + "]不是Button");
				return tempButton;
			}
		}
		Debug.LogWarning("DynamicCanvas中沒有Button[" + buttonName + "]存在");
		return null;
	}
	public static T GetUIComponent<T>(string uiName) where T : UnityEngine.Component {
		GameObject uiRoot = UnityTool.FindGameObject("DynamicCanvas");
		if(uiRoot == null) {
			Debug.LogWarning("場景上沒有DynamicCanvas");
			return null;
		}
		return GetUIComponent<T>(uiRoot, uiName);
	}
}
public enum CanvasType {
	Dynamic,
	Static
}
