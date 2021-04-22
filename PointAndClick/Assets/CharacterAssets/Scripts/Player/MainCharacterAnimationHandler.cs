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



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        mainCharacterScale = transform.localScale;

        scaleLeft = -transform.localScale.x;
        scaleRight = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        newPosition = playerPosition.transform.position;


        // If the two "Position" doesn't match, then the character has been moved
        if ( newPosition != oldPosition )
        {
            animator.SetBool("isWalking", true);    // Set the character's animation to "Walking"


            // Facing Left
            if ( mainCharacterScale.x == scaleRight && newPosition.x < oldPosition.x && playerPosition.GetComponent<ColliderCheck>().isTouching == false )
            {
                mainCharacterScale.x = scaleLeft;
            }
            // Facing Right
            if ( mainCharacterScale.x == scaleLeft && newPosition.x > oldPosition.x && playerPosition.GetComponent<ColliderCheck>().isTouching == false )
            {
                mainCharacterScale.x = scaleRight;
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
            // Set the character's animation to NOT "Walking"
            // This will automatically change the character's animation back to "Idle" by default
        }



        //************************************************
        // DEBUG --- Testing Stuff
        //************************************************
        // Testing Different Animations
        if (Input.GetKey ("0")) {
            resetAnimation();
        }
        if (Input.GetKey ("1")) {
            resetAnimation();
            animator.SetBool("isWalking", true);
        }
        if (Input.GetKey ("2")) {
            resetAnimation();
            animator.Play("INTERACT", -1, 0f);
        }
        if (Input.GetKey ("3")) {
            resetAnimation();
            animator.Play("GROUND_PICKUP", -1, 0f);
        }
        if (Input.GetKey ("4")) {
            resetAnimation();
            animator.SetBool("isClimbing", true);
        }
        if (Input.GetKey ("5")) {
            resetAnimation();
            animator.Play("SWING_SWORD", -1, 0f);
        }
        if (Input.GetKey ("6")) {
            resetAnimation();
            animator.Play("SWING_HAMMER", -1, 0f);
        }
        if (Input.GetKey ("7")) {
            resetAnimation();
            animator.SetBool("isFainting", true);
        }




        oldPosition = playerPosition.transform.position;

        transform.localScale = mainCharacterScale;
    }



    void resetAnimation()
    {
        animator.SetBool("isWalking",           false);
        animator.SetBool("isClimbing",          false);
        animator.SetBool("isFainting",          false);
    }
}
