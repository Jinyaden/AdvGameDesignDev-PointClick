using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class Cloud : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1f;
        [SerializeField] private float deathTimer = 3f;

        private void Update()
        {
            deathTimer -= Time.deltaTime;
            transform.position = transform.position + new Vector3(-moveSpeed, 0, 0) * Time.deltaTime;

            if (deathTimer <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
