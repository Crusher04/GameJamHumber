using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Variables
    public Transform Player;
    [SerializeField] float range;
    [SerializeField] float hSpeed;
    private Rigidbody2D body;
    private bool FacingRight = false;
    private Animator anim;

    // Get the body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GetComponent<EnemyTracking>().enabled = true;
    }


    void Update()
    {
        // Distance from Enemy to Player
        float dist = Vector2.Distance(transform.position, Player.position);
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetBool("run", horizontalInput != 0);

        // If the distance from the Enemy to the player is less than the range distance, execute the function
        if (dist < range)
        {

            //Track player
            if (transform.position.x < Player.position.x)
            {
                body.velocity = new Vector2(hSpeed, 0);
                anim.Play("walking");
            }
            // If not then move left towards the Player
            else if (transform.position.x > Player.position.x)
            {
                body.velocity = new Vector2(-hSpeed, 0);
                
            }

            //Flip sprite to face player
            if (body.velocity.x >= 0.01f && !FacingRight) //body.velocity.x < 0 && FacingRight
            {
                Flip();
            }

            if (body.velocity.x <= 0.01f && FacingRight) //body.velocity.x > 0 && !FacingRight
            {
                Flip();
            };

            //Disabling Patrolling..
            GetComponent<EnemyPatrol>().enabled = false;
           
        }
        else
        {
            //anim.Play("idle");
        }
    }


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        FacingRight = !FacingRight;

    }
}//End of class
