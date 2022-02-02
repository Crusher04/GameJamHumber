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
        anim.SetBool("isWalking", horizontalInput != 0);

        // If the distance from the Enemy to the player is less than the range distance, execute the function
        if (dist < range)
        {

            /*//Track player
            if (transform.position.x < Player.position.x)
            {
                body.velocity = new Vector2(hSpeed, 0);
            }
            // If not then move left towards the Player
            else if (transform.position.x > Player.position.x)
            {
                body.velocity = new Vector2(-hSpeed, 0);
                
            }*/

            if (Vector3.Distance(Player.position, transform.position) < 20)
            {

                transform.position = Vector2.MoveTowards(transform.position, Player.position, hSpeed * Time.deltaTime);
                if (Player.position.x > transform.position.x && !FacingRight) //if the target is to the right of enemy and the enemy is not facing right
                    Flip();
                if (Player.position.x < transform.position.x && FacingRight)
                    Flip();
            }
           

            //Disabling Patrolling..
            GetComponent<EnemyPatrol>().enabled = false;
           
        }
    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        FacingRight = !FacingRight;
    }
}//End of class
