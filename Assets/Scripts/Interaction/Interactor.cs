using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    private Vector3 dir;
    private Transform highlight;
    private RaycastHit hit;

    void Start()
    {
        Managers.Input.KeyAction -= InteractorInput;
        Managers.Input.KeyAction += InteractorInput;
    }

    void Update()
    {
        Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, Camera.main.nearClipPlane));
        dir = center - Camera.main.transform.position;
        dir = dir.normalized;
        // Debug.DrawRay(Camera.main.transform.position, dir, Color.red, 1.0f);

        if (highlight != null)
        {
            highlight.gameObject.GetComponent<Outline>().enabled = false;
            highlight = null;
        }

        if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
        {
            if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                highlight = hit.transform;

                if (highlight.gameObject.GetComponent<Outline>() != null)
                {
                    highlight.gameObject.GetComponent<Outline>().enabled = true;
                }
                else
                {
                    Outline outline = highlight.gameObject.AddComponent<Outline>();
                    outline.enabled = true;
                }

                // Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
            }
        }
    }

    void InteractorInput()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            {
                if (hit.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }
}