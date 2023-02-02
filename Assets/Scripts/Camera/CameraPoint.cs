using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CameraPoint
{
    public GameObject cameraPoint;

    [Tooltip("Camera Point above")]
    public GameObject Up;
    [Tooltip("Camera Point below")]
    public GameObject Down;
    [Tooltip("Camera Point on the left")]
    public GameObject Left;
    [Tooltip("Camera Point on the right")]
    public GameObject Right;
}
