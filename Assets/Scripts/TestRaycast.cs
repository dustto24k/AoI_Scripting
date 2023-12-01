using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRaycast : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
            Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, Camera.main.nearClipPlane));
            Vector3 dir = center - Camera.main.transform.position;
            dir = dir.normalized;

            Debug.DrawRay(Camera.main.transform.position, dir, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
    }
}
