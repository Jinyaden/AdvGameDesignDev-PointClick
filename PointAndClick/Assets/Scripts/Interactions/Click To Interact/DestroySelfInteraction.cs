using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfInteraction : MonoBehaviour, IInteractor
{
    public void Interact()
    {
        Destroy(gameObject);
    }
}
