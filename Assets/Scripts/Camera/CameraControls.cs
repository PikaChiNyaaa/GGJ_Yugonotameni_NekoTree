using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraControls : MonoBehaviour
{
    /* Camera Control:
     * Keeps track of where the camera is looking at
     * Moves the camera depending on which direction the player wants to go
     * 
     * Script by: PikaChiNyaaa
     * Date: 3 Feb 2023
     */

    public enum DIRECTIONS
    {
        UP = 0,
        DOWN,
        LEFT,
        RIGHT
    }

    [SerializeField] CinemachineVirtualCamera _camera;
    [SerializeField] GameObject btnParent;
    [SerializeField] CameraPoint[] cameraPoints;

    bool controlsUpdated;
    CameraPoint currPt;

    private void Start()
    {
        controlsUpdated = false;
        currPt = cameraPoints[0];
    }

    private void Update()
    {
        if (!controlsUpdated)
        {
            controlsUpdated = true;

            if (currPt.roomDir.Up != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.UP).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.UP).gameObject.SetActive(false);
            }

            if (currPt.roomDir.Down != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.DOWN).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.DOWN).gameObject.SetActive(false);
            }

            if (currPt.roomDir.Left != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.LEFT).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.LEFT).gameObject.SetActive(false);
            }

            if (currPt.roomDir.Right != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.RIGHT).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.RIGHT).gameObject.SetActive(false);
            }
        }
    }

    public void MoveToCameraPoint(int dir)
    {
        controlsUpdated = false;
        switch ((DIRECTIONS)dir)
        {
            case DIRECTIONS.UP:
                _camera.Follow = currPt.roomDir.Up.transform;
                currPt = GetCameraPoint(currPt.roomDir.Up.name);
                break;
            case DIRECTIONS.DOWN:
                _camera.Follow = currPt.roomDir.Down.transform;
                currPt = GetCameraPoint(currPt.roomDir.Down.name);
                break;
            case DIRECTIONS.LEFT:
                _camera.Follow = currPt.roomDir.Left.transform;
                currPt = GetCameraPoint(currPt.roomDir.Left.name);
                break;
            case DIRECTIONS.RIGHT:
                _camera.Follow = currPt.roomDir.Right.transform;
                currPt = GetCameraPoint(currPt.roomDir.Right.name);
                break;
        }
    }

    private CameraPoint GetCameraPoint(string name)
    {
        foreach (CameraPoint cp in cameraPoints)
        {
            if (cp.cameraPoint.name == name)
                return cp;
        }
        return null;
    }
}

[System.Serializable]
public class CameraPoint
{
    public GameObject cameraPoint;
    public RoomDirectory roomDir;
}

[System.Serializable]
public struct RoomDirectory
{
    [Tooltip("Camera Point above")]
    public GameObject Up;
    [Tooltip("Camera Point below")]
    public GameObject Down;
    [Tooltip("Camera Point on the left")]
    public GameObject Left;
    [Tooltip("Camera Point on the right")]
    public GameObject Right;
}
