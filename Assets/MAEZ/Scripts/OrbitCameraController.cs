using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OrbitCameraController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public string mouseXInputName = "Mouse X";
    public float sensitivity = 1f;
    public bool rightMouseMovement = true;

    private bool isRightMouseButtonDown = false;

    void Update()
    {
        // Check if the right mouse button is down
        if (Input.GetMouseButtonDown(1))
        {
            isRightMouseButtonDown = true;
        }
        if (Input.GetMouseButtonUp(1))
        {
            isRightMouseButtonDown = false;
        }

        // If right mouse button is held down, move the camera
        if (rightMouseMovement && isRightMouseButtonDown)
        {
            float mouseX = Input.GetAxis(mouseXInputName) * sensitivity;
            freeLookCamera.m_XAxis.Value += mouseX;
        }
    }
}
