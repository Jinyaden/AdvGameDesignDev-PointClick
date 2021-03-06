using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatyText : MonoBehaviour
{
    [SerializeField] private string displayText = null;
    TextMeshPro tmpText = null;

    [SerializeField] float floatAmount = 1f;
    [SerializeField] float deathTimer = 3f;

    private void Awake()
    {
        tmpText = GetComponentInChildren<TextMeshPro>();
    }
    private void Start()
    {
        tmpText.text = displayText;
    }

    private void FixedUpdate()
    {
        // float up mah boi
        transform.position += new Vector3(0, floatAmount * Time.deltaTime, 0);
        Destroy(gameObject, deathTimer);
    }
}
