using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class CameraControls : MonoBehaviour
{
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

            if (currPt.Up != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.UP).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.UP).gameObject.SetActive(false);
            }

            if (currPt.Down != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.DOWN).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.DOWN).gameObject.SetActive(false);
            }

            if (currPt.Left != null)
            {
                btnParent.transform.GetChild((int)DIRECTIONS.LEFT).gameObject.SetActive(true);
            }
            else
            {
                btnParent.transform.GetChild((int)DIRECTIONS.LEFT).gameObject.SetActive(false);
            }

            if (currPt.Right != null)
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
                _camera.Follow = currPt.Up.transform;
                currPt = GetCameraPoint(currPt.Up.name);
                break;
            case DIRECTIONS.DOWN:
                _camera.Follow = currPt.Down.transform;
                currPt = GetCameraPoint(currPt.Down.name);
                break;
            case DIRECTIONS.LEFT:
                _camera.Follow = currPt.Left.transform;
                currPt = GetCameraPoint(currPt.Left.name);
                break;
            case DIRECTIONS.RIGHT:
                _camera.Follow = currPt.Right.transform;
                currPt = GetCameraPoint(currPt.Right.name);
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
