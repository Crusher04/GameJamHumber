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
    
    // Get the body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        // Distance from Enemy to Player
        float dist = Vector2.Distance(transform.position, Player.position);

        // If the distance from the Enemy to the player is less than the range distance, execute the function
        if (dist < range)
        {
            Track();
        }
    }

    // Function for the enemy to track the player based on player position
    void Track()
        {
            // If Player is to the right of the enemy, move right towards the Player
            if (transform.position.x < Player.position.x)
            {
                body.velocity = new Vector2(hSpeed, 0);
                //transform.localScale = new Vector2(1, 1);
            }
            // If not then move left towards the Player
            else
            {
                body.velocity = new Vector2(-hSpeed, 0);
                //transform.localScale = new Vector2(-1, 1);
            }
        }

}
