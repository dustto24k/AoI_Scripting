using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractable { public void Interact(); }

public class PlayerInteractor : MonoBehaviour
{
    static public bool iActive;

    private Vector3 dir;
    private Transform highlight;
    private GameObject UItext;
    private RaycastHit hit;

    void Start()
    {
        Managers.Input.KeyAction -= InteractorInput;
        Managers.Input.KeyAction += InteractorInput;
    }

    void Update()
    {
        if (iActive)
        {
            Vector3 center = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width * 0.5f, Screen.height * 0.5f, Camera.main.nearClipPlane));
            dir = center - Camera.main.transform.position;
            dir = dir.normalized;

            if (highlight != null)
            {
                highlight.gameObject.GetComponent<Outline>().enabled = false;
                highlight = null;
            }

            if (UItext != null)
            {
                UItext.SetActive(false);
                UItext = null;
            }

            if (Physics.Raycast(Camera.main.transform.position, dir, out hit))
            {
                Transform foundUI = hit.collider.gameObject.transform.Find("UI_PropText");

                if (foundUI != null)
                {
                    highlight = hit.transform;
                    UItext = foundUI.gameObject;
                    UItext.SetActive(true);

                    UItext.transform.position = UItext.transform.parent.position - dir * 1.2f;
                    UItext.transform.rotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y, 0f);

                    if (highlight.gameObject.GetComponent<Outline>() != null)
                    {
                        highlight.gameObject.GetComponent<Outline>().enabled = true;
                    }
                    else
                    {
                        Outline outline = highlight.gameObject.AddComponent<Outline>();
                        outline.enabled = true;
                    }
                }
            }
        }
    }

    void InteractorInput()
    {
        if (iActive)
        {
            if (Physics.Raycast(Camera.main.transform.position, dir, out hit) && Input.GetMouseButtonDown(0))
            {
                Transform foundUI = hit.collider.gameObject.transform.Find("UI_PropText");

                if (foundUI != null)
                {
                    IInteractable interactObj = foundUI.GetComponent<IInteractable>();
                    interactObj.Interact();
                }
            }
        }
    }
}