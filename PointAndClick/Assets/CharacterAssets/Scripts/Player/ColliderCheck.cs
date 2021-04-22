using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: This Script should be attached to 'PlayerContainer' Game Object.

public class ColliderCheck : MonoBehaviour
{
    public bool isTouching = false;

    void OnCollisionEnter( Collision other )
    {
        if ( other.collider.tag != "Ground" )
        {
            isTouching = true;
        }
    }

    void OnCollisionExit( Collision other )
    {
        if ( other.collider.tag != "Ground" )
        {
            isTouching = false;
        }
    }
}
