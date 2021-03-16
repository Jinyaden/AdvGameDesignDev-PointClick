using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class DestroySelfInteraction : MonoBehaviour, IInteractor
    {
        public void Interact()
        {
            Destroy(gameObject);
        }
    }
}
