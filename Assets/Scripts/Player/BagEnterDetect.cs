using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagEnterDetect : MonoBehaviour
{
    private Camera _playerCam;
    private Camera _bagCam;
    private Vector3 _playerPos;

    private void Start()
    {
        _playerCam = Camera.main;
        _bagCam = GameObject.Find("BagCamera").transform.GetChild(transform.GetSiblingIndex()).GetComponent<Camera>();

        Managers.GetInput.KeyAction -= StandUpInput;
        Managers.GetInput.KeyAction += StandUpInput;
    }

    private void OnTriggerEnter(Collider other)
    {
        Managers.UI.ShowSceneUI<UI_BagStandUp>();
    }

    private void OnTriggerStay(Collider other)
    {
        _bagCam.gameObject.SetActive(true);
        _bagCam.enabled = true;
        _playerCam.enabled = false;
    }

    private void OnTriggerExit(Collider other)
    {
        _playerCam.enabled = true;
        _bagCam.enabled = false;
        _bagCam.gameObject.SetActive(false);
    }

    private void StandUpInput()
    {
        _playerPos = GameObject.Find("Player").transform.position;
        if (Input.GetKeyDown(KeyCode.X) && _bagCam.enabled)
        {
            _playerPos.x += 0.5f; _playerPos.z += 1.5f;
            GameObject.Find("Player").transform.position = _playerPos;
        }
    }
}