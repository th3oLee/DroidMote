using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RemoteDroid : MonoBehaviour
{

    TCPTestClient tcp;
    // Start is called before the first frame update
    void Start()
    {
        tcp = new TCPTestClient();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 acc = Input.acceleration;
        string message = acc.x.ToString() + ";" + acc.y.ToString() + ";" + acc.z.ToString();
        //Debug.Log(message);
        //tcp.SendMessage("(" + Input.acceleration.x.ToString() + ";" + Input.acceleration.y.ToString() + ")");
    }

    public void clickOnButton(string buttonName)
    {
        Debug.Log("CLICK" + name + ";" + buttonName);
        tcp.SendMessage("201" + ";" + buttonName);
    }




}
