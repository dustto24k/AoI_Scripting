using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldCamera : MonoBehaviour
{
    private Transform cameraPosition;

    private void Start()
    {
        cameraPosition = GameObject.Find("CameraPos").transform;
    }

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}