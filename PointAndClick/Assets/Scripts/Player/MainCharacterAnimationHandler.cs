using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimationHandler : MonoBehaviour
{
    private Animator animator;

    public GameObject playerPosition;
    private Vector3 newPosition;
    private Vector3 oldPosition;

    private Vector3 mainCharacterScale;
    private float scaleLeft;
    private float scaleRight;

    public bool fixSpriteLeftGlitch = true;
    private bool spriteLeftGlitchFixed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        mainCharacterScale = transform.localScale;

        scaleLeft = -transform.localScale.x;
        scaleRight = transform.localScale.x;

        spriteLeftGlitchFixed = false;
    }

    // Update is called once per frame
    void Update()
    {
        oldPosition = playerPosition.transform.position;


        if ( oldPosition != newPosition )
        {
            animator.SetBool("isWalking", true);

            if ( oldPosition.x < newPosition.x )
            {
                mainCharacterScale.x = scaleLeft;
            }
            else
            {
                mainCharacterScale.x = scaleRight;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }


        if (fixSpriteLeftGlitch && !spriteLeftGlitchFixed)
        {
            mainCharacterScale.x = scaleRight;
            spriteLeftGlitchFixed = true;
        }


        newPosition = playerPosition.transform.position;
        transform.localScale = mainCharacterScale;
    }
}
