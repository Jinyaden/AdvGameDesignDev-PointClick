﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFaceCam : MonoBehaviour
{

    private void Update()
    {
		//LOL WHATS THE POINT
        transform.rotation = Quaternion.Euler(0, Camera.main.transform.rotation.y, 0);
    }
}
