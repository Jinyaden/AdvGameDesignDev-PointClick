using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMenu : MonoBehaviour
{
    [SerializeField] GameObject contextMenu = null;
    IInteractor interactionType = null;

    private void Awake()
    {
        //interationType = GetComponent<IInteractor>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // if right clicked
        {
            //get interationType from the object hit
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100)) // this was a bad idea...
            {
                if (hit.transform.gameObject.GetComponent<IInteractor>() != null)
                {
                    interactionType = hit.transform.gameObject.GetComponent<IInteractor>();
                    contextMenu.SetActive(true);
                    transform.position = hit.transform.position + new Vector3(0, 0, -1f);
                    Debug.Log("Got Interactor!");
                }
                else if (interactionType != null)
                {
                    contextMenu.SetActive(true);
                }
            }
        }
    }

    private void OnMouseExit() // when the player mouses out of this menu
    {
        CloseMenu();
    }

    public void InteractWithObject()
    {
        if (interactionType != null)
        { 
            interactionType.Interact();
        }
        contextMenu.SetActive(false);
    }

    public void CloseMenu()
    {
        contextMenu.SetActive(false);
    }


}
