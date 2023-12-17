using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    static public bool cActive;
    private float sensX = 200;
    private float sensY = 200;
    private Transform orientation;

    float xRotation = -3f;
    float yRotation = 90f;

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

            if (transform.position.y > 5.2f)
            {
                xRotation -= mouseY;
                xRotation = Mathf.Clamp(xRotation, -40f, 40f);
            }
            else xRotation = -3f;

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
            orientation.rotation = Quaternion.Euler(0, yRotation, 0);
        }
    }
}
