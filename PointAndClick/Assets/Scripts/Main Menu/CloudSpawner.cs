using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class CloudSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject cloudPrefab = null;
        [SerializeField, Header("Minimum value of 1")] private float maxSpawnTimer = 5f;
        [SerializeField] private float minSpawnTimer = 2f;
        private float timer = 0f;

        private void Start()
        {
            timer = Random.Range(1f, maxSpawnTimer);
        }

        private void Update()
        {
            if (timer > 0f)
            {
                timer -= Time.deltaTime; // count down time
            }
            else
            {
                SpawnCloud();
                timer = Random.Range(minSpawnTimer, maxSpawnTimer);
            }
        }
        void SpawnCloud()
        {
            Instantiate(cloudPrefab, new Vector3(transform.position.x , transform.position.y + Random.Range(-1f, 1f),
                transform.position.z), Quaternion.identity);
        }
    }
}
