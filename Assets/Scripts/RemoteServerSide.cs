using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteServerSide : MonoBehaviour
{
    public string lastInput;
    public bool isConsumed = true;
    public Vector3 accelerometter;
    public Vector3 gravity;
    public Quaternion attitude;

    public bool isConnected = false;
    public string name = "Disconnected Player";
}
