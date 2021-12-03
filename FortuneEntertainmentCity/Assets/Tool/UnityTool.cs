using UnityEngine;
public static class UnityTool {
    public static void Attach(GameObject parentObject, GameObject childObject, Vector3 position) {
        childObject.transform.parent = parentObject.transform;
        childObject.transform.localPosition = position;
    }
    public static void AttachToRefPosition(GameObject parentObject, GameObject childObject, string refPointName, Vector3 position) {
        bool isFound = false;
        Transform[] children = parentObject.transform.GetComponentsInChildren<Transform>();
        Transform refTransform = null;
        foreach(Transform child in children) {
            if(child.name == refPointName) {
                if(isFound) {
                    Debug.LogWarning("物件[" + parentObject.transform.name + "]內有兩個以上的參考點[" + refPointName + "]");
                    continue;
                }
                isFound = true;
                refTransform = child;
            }
        }
        if(!isFound) {
            Debug.LogWarning("物件[" + parentObject.transform.name + "]內沒有參考點[" + refPointName + "]");
            Attach(parentObject, childObject, position);
            return;
        }

        childObject.transform.parent = refTransform;
        childObject.transform.localPosition = position;
        childObject.transform.localScale = Vector3.one;
        childObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
    }
    public static GameObject FindGameObject(string objectName) {
        GameObject tempGameObject = GameObject.Find(objectName);
        if(tempGameObject == null) {
            Debug.LogWarning("場景中找不到GameObject[" + objectName + "]物件");
            return null;
        }
        return tempGameObject;
    }
    public static GameObject FindChildGameObject(GameObject container, string objectName) {
        if(container == null) {
            Debug.LogError("UnityTool.FindChildGameObject : Container = null");
            return null;
        }
        Transform objectTransform = null;
        if(container.name == objectName) {
            objectTransform = container.transform;
        }
        else {
            Transform[] Children = container.transform.GetComponentsInChildren<Transform>();
            foreach(Transform child in Children) {
                if(child.name == objectName) {
                    if(objectTransform == null) 
                        objectTransform = child;
                    else 
                        Debug.LogWarning("Container[" + container.name + "]找到重複的元件名稱[" + objectName + "]");
                }
            }
        }
        if(objectTransform == null) {
            Debug.LogError("元件[" + container.name + "]找不到子元件[" + objectName + "]");
            return null;
        }
        return objectTransform.gameObject;
    }
}