using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestAttack : MonoBehaviour
{
    // Variables
    public Transform Player;
    public Collider2D col;
    public Rigidbody2D body;
    public Animator animate;
    public float range;

    // Get body component
    void Start()
    {
        col.enabled = false;
        
    }

    // Basic enemy attack
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.position);
        if (dist > range)
        {

            animate.SetBool("PlayerSeen", false);
            col.enabled = false;
            body.isKinematic = false;
            //GetComponent<EnemyPatrol>().enabled = true;
        }
        else Active();
    }
    public void Active()
    {
        animate.SetBool("PlayerSeen", true);
        col.enabled = true;
        body.isKinematic = true;
        //GetComponent<EnemyPatrol>().enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}