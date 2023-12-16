using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    static public bool pActive;
    private float moveSpeed = 2.5f;
    private Transform orientation;
    float horizontalInput;
    float verticalInput;
    Vector3 moveDirection;
    Rigidbody rb;

    private void Start()
    {
        orientation = GameObject.Find("Orientation").transform;
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        Managers.GetInput.FixedKeyAction -= PlayerInput;
        Managers.GetInput.FixedKeyAction += PlayerInput;
    }

    private void FixedUpdate()
    {
        PlayerInput();
        SpeedControl();
    }

    private void PlayerInput()
    {
        if (pActive)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
            rb.AddForce(moveDirection.normalized * moveSpeed * 6.0f, ForceMode.Force);
        }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}