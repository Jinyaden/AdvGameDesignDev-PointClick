using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class StaticFollow : MonoBehaviour, ICamera
    {
        private GameObject target;
        [SerializeField] float x = 0f, y = 2f, z = -5f;

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public void CameraFollow()
        {
            Camera.main.transform.position = new Vector3(target.transform.position.x + x, target.transform.position.y + y, z);
        }
    }
}
