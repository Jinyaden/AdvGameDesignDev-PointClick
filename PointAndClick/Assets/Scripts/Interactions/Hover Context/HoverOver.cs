using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HoverOver : MonoBehaviour
{
    [SerializeField] private GameObject hoverTextPrefab = null;
    [SerializeField] string messageToDisplay = "";
    [SerializeField] float heightOffsetAmount = 1f;
    private Vector3 heightOffset;
    private GameObject prefab;
    private void OnMouseEnter() // when moused over
    {
        heightOffset = this.transform.position + new Vector3(0, heightOffsetAmount, 0);
        if (hoverTextPrefab != null)
        {
            prefab = Instantiate(hoverTextPrefab, heightOffset, Quaternion.identity);
            prefab.GetComponent<TextMeshPro>().text = messageToDisplay;
        }
        else
        {
            Debug.Log("hoverTextPrefab is empty, please add the prefab to object: " + this.name);
        }
    }

    private void OnMouseExit() // when mouse isnt on this object
    {
        if(prefab != null) Destroy(prefab);
    }
}
