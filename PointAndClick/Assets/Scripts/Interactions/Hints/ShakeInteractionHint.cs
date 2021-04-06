using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace COMP1288.PointClick.Jin
{
    public class ShakeInteractionHint : MonoBehaviour, IInteractor
    {
        //[SerializeField] private GameObject floatyText = null;
        //[SerializeField] private string message = "";
        [SerializeField] private float shakeDistance = 1f;
        [SerializeField] private float shakeSpeed = 1f;
        [SerializeField] private float timer = 2f;
        private float startTime;
        //private Transform startPos;
        private bool activated = false;

        //private void OnEnable()
        //{
        //    startPos = transform;
        //}
        //private void OnTriggerEnter(Collider other)
        //{
        //    GiveHint();
        //    activated = true;
        //}

        //private void OnMouseEnter()
        //{
        //    GiveHint();
        //    activated = true;
        //}

        //public void GiveHint()
        //{
        //    if (floatyText == null) { Debug.Log("Where floaty boi?!"); } // where mah floaty boi at? 

        //    if (floatyText != null && activated == false)
        //    {
        //        //spawn floaty boi text
        //        Instantiate(floatyText, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
        //        floatyText.GetComponent<TextMeshPro>().text = message;
        //    }
        //}

        //private void OnTriggerStay(Collider other)
        //{
        //    //ruh roh shaggy
        //    transform.position += new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * Time.deltaTime, 0, 0);
        //}
        //private void OnMouseOver()
        //{
        //    //ruh roh shaggy
        //    transform.position += new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * Time.deltaTime, 0, 0);
        //}

        //private void OnTriggerExit(Collider other)
        //{
        //    transform.position = startPos.position; // reset position
        //    activated = false;
        //}

        //private void OnMouseExit()
        //{
        //    transform.position = startPos.position; // reset position
        //    activated = false;
        //}
        private void Awake()
        {
            startTime = timer;
        }
        private void Update()
        {
            if (activated)
            {
                if (timer > 0)
                {
                    transform.position += new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeDistance * Time.deltaTime, 0, 0);
                    timer -= Time.deltaTime;
                }
                else
                {
                    activated = false;
                }
            }
        }
        public void Interact()
        {
            //Shake tree
            //ruh roh shaggy
            activated = !activated;
            timer = startTime;
        }

        //IEnumerator Shake()
        //{
        //    while (timer > 0)
        //    {
        //    }
        //    timer -= Time.deltaTime;
        //    yield return null;
        //}
    }
}
