using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteDroidController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        foreach (var device in Microphone.devices)
    {
        Debug.Log("Name: " + device);
    }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void pressButton(string buttonName)
    {
        Debug.Log(buttonName);
    }
}
