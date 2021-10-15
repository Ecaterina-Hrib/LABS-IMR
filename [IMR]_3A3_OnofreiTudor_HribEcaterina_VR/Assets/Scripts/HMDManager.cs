using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDManager : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Is Device Active: " + XRSettings.isDeviceActive);
        Debug.Log("Device Name is: " + XRSettings.loadedDeviceName);
    }

    void Update()
    {
        
    }
}
