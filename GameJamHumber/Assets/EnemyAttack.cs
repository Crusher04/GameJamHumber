using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Variables
    public Transform Player;
    private Rigidbody2D body;
    public PlayerDeath playerDeath;
    public UIManager healthManager;

    // Get body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Basic enemy attack
    void Update()
    {

        // Distance between the enemy and player
        float dist = Vector2.Distance(transform.position, Player.position);

        // If the distance is less than 1 the enemy attacks and the player loses health
        if (dist < 1)
        {
            
            
            healthManager.LoseHealth_();
        
        }
    }
}
