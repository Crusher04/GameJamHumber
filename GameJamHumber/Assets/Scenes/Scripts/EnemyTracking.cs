using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTracking : MonoBehaviour
{
    // Variables
    public Transform Player;
    public TypeEnemy enemy;
    private Rigidbody2D body;

    // Get the body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        
    }

    // Function for the enemy to track the player based on player position
    public void Track()
    {
        // If Player is to the right of the enemy, move right towards the Player
        if (transform.position.x < Player.position.x)
        {
            body.velocity = new Vector2(enemy.speed, 0);
        }
        // If not then move left towards the Player
        else
        {
            body.velocity = new Vector2(-enemy.speed, 0);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, enemy.range);
    }
}