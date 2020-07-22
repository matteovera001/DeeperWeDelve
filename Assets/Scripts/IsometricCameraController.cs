//Created by Robinduckett
// RPG Top Down / Isometric Camera Controller

// Tested on Unity 2018.3.0f1

// While using the setup suggested by 
// https://answers.unity.com/questions/12027/how-to-do-a-camera-that-is-top-downisometric.html
// I found no off the shelf camera controllers that worked as I would have liked
// This is for basic mouse control (Rotate, Pan, Zoom)

// Improvement suggestions left as exercise for the reader:
//
// * Replacing magic numbers with serialised floats
//   that could be modified in the editor
// * Include keyboard controls
// * Add tilting

// Attach this script to any GameeObject
// Make sure the Camera is tagged as "Main Camera" in the inspector

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCameraController : MonoBehaviour
{
    public float maxZoom = 5f;
    public float minZoom = 50f;
    public float zoomSpeed =2f;
    public float movementSpeed = 5;
    public float movementSpeedScroll = 5;

    //private bool isRotating;
    //private bool isPanning;
    private float velocity;
    private float zoomVelocity;

    private float deltaX = 0f;
    private float deltaY = 0f;

    void Update()
    {
        /*if (Input.GetMouseButton(1))
        {
            isRotating = true;
            velocity = 0f;
        }
        else
        {
            isRotating = false;
        }*/

        
        /*
        if (Input.GetMouseButton(2))
        {
            isPanning = true;
            deltaX = 0f;
            deltaY = 0f;
        }
        else
        {
            isPanning = false;
            
            
        }*/

        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        if (Movement.magnitude >= .02)
        {
            Camera.main.transform.parent.Translate(Movement * (Time.fixedDeltaTime*(movementSpeed * Camera.main.orthographicSize * (-1))));
        }

        /*
        if (isRotating == true)
        {
            RotateCameraTarget();
        }
        else if (isPanning == true)
        {
            PanCameraTarget();
        }*/

        //CalculateRotation();
        CalculateZoom();
        //CalculatePan();
    }

    /*
    void CalculateRotation()
    {
        Vector3 rot = Camera.main.transform.parent.eulerAngles;
        rot.y += velocity;
        Camera.main.transform.parent.eulerAngles = rot;
        velocity = Mathf.Lerp(velocity, 0f, Time.deltaTime * 5f);
    }*/

    void CalculateZoom()
    {
        if (Camera.main.orthographicSize < maxZoom)
        {
            Camera.main.orthographicSize = maxZoom;
            zoomVelocity = 0f;
            return;
        }

        if (Camera.main.orthographicSize > minZoom)
        {
            Camera.main.orthographicSize = minZoom;
            zoomVelocity = 0f;
            return;
        }

        if (
            Camera.main.orthographicSize + zoomVelocity >= maxZoom &&
            Camera.main.orthographicSize + zoomVelocity <= minZoom
        )
        {
            Camera.main.orthographicSize += zoomVelocity;
        }

        zoomVelocity -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        zoomVelocity = Mathf.Lerp(zoomVelocity, 0f, Time.fixedDeltaTime * 5f);
    }

    /*
    void CalculatePan()
    {
        if (deltaX < 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, deltaX);
        }

        if (deltaX > 0)
        {
            Camera.main.transform.parent.Translate(-deltaX, 0, deltaX);
        }

        if (deltaY < 0)
        {
            Camera.main.transform.parent.Translate(-deltaY, 0, -deltaY);
        }

        if (deltaY > 0)
        {
            Camera.main.transform.parent.Translate(-deltaY, 0, -deltaY);
        }

        deltaY = Mathf.Lerp(deltaY, 0f, Time.deltaTime * movementSpeedScroll);
        deltaX = Mathf.Lerp(deltaX, 0f, Time.deltaTime * movementSpeedScroll);
    }*/

    void RotateCameraTarget()
    {
        velocity += Input.GetAxis("Mouse X") * 3f;
    }

    void PanCameraTarget()
    {
        deltaX = Input.GetAxisRaw("Mouse X") * 3f;
        deltaY = Input.GetAxisRaw("Mouse Y") * 3f;
    }
}