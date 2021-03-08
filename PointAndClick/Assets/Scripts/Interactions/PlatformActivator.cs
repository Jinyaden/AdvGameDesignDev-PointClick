using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class PlatformActivator : MonoBehaviour
    {
        [SerializeField] private GameObject objToHide = null;

        private void OnTriggerEnter(Collider other)
        {
            if (objToHide != null)
                objToHide.SetActive(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (objToHide != null)
                objToHide.SetActive(false);
        }
    }
}
