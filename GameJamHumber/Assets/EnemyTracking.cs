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

    // Get the body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        GetComponent<EnemyTracking>().enabled = true;
        
    }


    void Update()
    {
        // Distance from Enemy to Player
        float dist = Vector2.Distance(transform.position, Player.position);

        // If the distance from the Enemy to the player is less than the range distance, execute the function
        if (dist < range)
        {
            //Track player
            Track();

            //Disabling Patrolling..
            GetComponent<EnemyPatrol>().enabled = false;
           
        }
    }

    // Function for the enemy to track the player based on player position
    void Track()
    {
        //Variables 
     

        // If Player is to the right of the enemy, move right towards the Player
        if (transform.position.x < Player.position.x)
        {
            body.velocity = new Vector2(hSpeed, 0);
        }
        // If not then move left towards the Player
        else
        {
            body.velocity = new Vector2(-hSpeed, 0);
            
        }

        //Flip sprite to face player
        if(body.velocity.x < 0 && FacingRight)
        {
            
            Flip();
        }
        
        if(body.velocity.x > 0 && !FacingRight)
        {
            Flip();
        }


    }//End of Track()


    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        FacingRight = !FacingRight;

    }
}//End of class
