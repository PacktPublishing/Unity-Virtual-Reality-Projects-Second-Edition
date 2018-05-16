using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisablePositionalTracking : MonoBehaviour
{
    void Start()
    {
        UnityEngine.XR.InputTracking.disablePositionalTracking = true;
    }
}
