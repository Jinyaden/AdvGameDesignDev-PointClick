using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class CameraController : MonoBehaviour
    {
        private ICamera myCam;

        private void Awake()
        {
            myCam = GetComponentInChildren<ICamera>();
        }

        private void Update()
        {
            myCam.CameraFollow();
        }
    }
}
