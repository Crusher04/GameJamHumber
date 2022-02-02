using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriestAttack : MonoBehaviour
{
    // Variables
    public Transform Player;
    public Collider2D col;
    public Rigidbody2D body;
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
            col.enabled = false;
            body.isKinematic = false;
            GetComponent<EnemyMovement>().enabled = true;
        }
        else Active();
    }
    public void Active()
    {
        col.enabled = true;
        body.isKinematic = true;
        GetComponent<EnemyMovement>().enabled = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
