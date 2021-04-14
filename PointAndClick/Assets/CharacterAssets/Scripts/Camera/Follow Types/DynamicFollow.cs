using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class DynamicFollow : MonoBehaviour, ICamera
    {
        private GameObject target;
        [SerializeField, Range(1f, 10f)] float FollowSpeed = 1f;
        [SerializeField] float xPos = 0f, yPos = 3f, zPos = -15f;
        [SerializeField] float xRot = 0f, yRot = 0f;

        private void Awake()
        {
            target = GameObject.FindGameObjectWithTag("Player");
        }

        public void CameraFollow()
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position + new Vector3(xPos, yPos, zPos), FollowSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(xRot, yRot, 0);
        }
    }
}
