using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class ShakeInteractionHint : MonoBehaviour
    {
        [SerializeField] private GameObject floatyText = null;
        [SerializeField] private float shakeAmount = 1f;
        [SerializeField] private float shakeSpeed = 1f;
        private Transform startPos;
        private bool activated = false;

        private void OnEnable()
        {
            startPos = transform;
        }
        //private void OnTriggerEnter(Collider other)
        //{
        //    GiveHint();
        //    activated = true;
        //}

        private void OnMouseEnter()
        {
            GiveHint();
            activated = true;
        }

        public void GiveHint()
        {
            if (floatyText == null) { Debug.Log("Where floaty boi?!"); } // where mah floaty boi at? 

            if (floatyText != null && activated == false)
            {
                //spawn floaty boi text
                Instantiate(floatyText, new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z), Quaternion.identity);
            }
        }

        //private void OnTriggerStay(Collider other)
        //{
        //    //ruh roh shaggy
        //    transform.position += new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * Time.deltaTime, 0, 0);
        //}
        private void OnMouseOver()
        {
            //ruh roh shaggy
            transform.position += new Vector3(Mathf.Sin(Time.time * shakeSpeed) * shakeAmount * Time.deltaTime, 0, 0);
        }

        //private void OnTriggerExit(Collider other)
        //{
        //    transform.position = startPos.position; // reset position
        //    activated = false;
        //}

        private void OnMouseExit()
        {
            transform.position = startPos.position; // reset position
            activated = false;
        }
    }
}
