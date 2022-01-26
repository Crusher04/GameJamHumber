using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Variables
    public Transform Player;
    public Collider2D col;
    public Rigidbody2D body;
    public TypeEnemy enemy;
    //public PlayerDeath playerDeath;
    //public UIManager healthManager;
    //public TypeEnemy enemy;

    // Get body component
    void Start()
    {
        col.enabled = false;
        
    }

    // Basic enemy attack
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.position);
        if (dist > enemy.range)
        {
            col.enabled = false;
            body.isKinematic = false;
        }
    }
    public void Active()
    {
        col.enabled = true;
        body.isKinematic = true;
    }
}
