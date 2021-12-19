using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            //SceneSwitchController.Instance.SwitchScene("ExampleScene").GetAwaiter();
            SceneSwitchController.Instance.AddScene("ExampleScene").GetAwaiter();
        }
        if(Input.GetKeyDown(KeyCode.A)) {
            //SceneSwitchController.Instance.SwitchScene("ExampleScene").GetAwaiter();
            SceneSwitchController.Instance.UnloadScene("ExampleScene").GetAwaiter();
        }
        if(Input.GetKeyDown(KeyCode.B)) {
            //SceneSwitchController.Instance.SwitchScene("ExampleScene").GetAwaiter();
            SceneSwitchController.Instance.UnloadAllScene().GetAwaiter();
        }
    }
}
