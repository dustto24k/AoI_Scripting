using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    static public bool cActive;
    private float sensX = 400;
    private float sensY = 400;
    private Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        orientation = GameObject.Find("Orientation").transform;
    }

    private void FixedUpdate()
    {
        if (cActive)
        {
            float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
            float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

            yRotation += mouseX;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -40f, 40f);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
