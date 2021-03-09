using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/***********************************************************************

    Simple Script to Flip the Sprite based on the Player's Position

***********************************************************************/

public class SpriteTurnaround : MonoBehaviour
{
    public GameObject playerPosition;
    public bool SpriteIsFacingRight = false;

    private Vector3 npcPosition;
    private float npcScaleLeft;
    private float npcScaleRight;
    

    // Start is called before the first frame update
    void Start()
    {
        if ( SpriteIsFacingRight == false )
        {
            npcScaleLeft = transform.localScale.x;
            npcScaleRight = -transform.localScale.x;
        }
        else
        {
            npcScaleLeft = -transform.localScale.x;
            npcScaleRight = transform.localScale.x;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 npcScale = transform.localScale;
        Vector3 npcPosition = transform.position;
        
        // Check to see if the Player's X Position is Greater than NPC's X Position
        // If yes, then Flip the Sprite
        if ( playerPosition.transform.position.x > npcPosition.x )
        {
            npcScale.x = npcScaleRight;
        }
        else
        {
            npcScale.x = npcScaleLeft;
        }

        transform.localScale = npcScale;
    }
}
