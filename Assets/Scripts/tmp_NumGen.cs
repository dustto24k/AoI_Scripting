using UnityEngine;

public class tmp_NumGen : MonoBehaviour, IInteractible
{
    public void Interact()
    {
        Debug.Log(Random.Range(0, 100));
    }
}
