using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace COMP1288.PointClick.Jin
{
    public class SpriteFaceCam : MonoBehaviour
    {
        private void Update()
        {
            transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.y, 0);
        }
    }
}
