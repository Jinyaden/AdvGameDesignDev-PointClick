using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCharacterAnimationHandler : MonoBehaviour
{
    private Animator animator;

    public GameObject playerPosition;
    public Vector3 newPosition;
    public Vector3 oldPosition;

    public Vector3 mainCharacterScale;
    public float scaleLeft;
    public float scaleRight;

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
        newPosition = playerPosition.transform.position;


        if ( newPosition != oldPosition )
        {
            animator.SetBool("isWalking", true);

            if ( newPosition.x < oldPosition.x )
            {
                mainCharacterScale.x = scaleLeft;
            }
            if ( newPosition.x > oldPosition.x )
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


        oldPosition = playerPosition.transform.position;
        transform.localScale = mainCharacterScale;
    }
}
