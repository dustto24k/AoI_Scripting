using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IInteractible
{
    public void Interact();
}

public class Interactor : MonoBehaviour
{
    public Transform InteractorSource;
    public float InteractRange;

    void Start()
    {
        //Managers.Input.KeyAction -= InteractorInput;
        //Managers.Input.KeyAction += InteractorInput;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
                {
                    interactObj.Interact();
                }
            }
        }
    }

    //void InteractorInput()
    //{
    //    if (Input.GetKeyDown(KeyCode.E))
    //    {
    //        Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
    //        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
    //        {
    //            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractible interactObj))
    //            {
    //                interactObj.Interact();
    //            }
    //        }
    //    }
    //}
}
