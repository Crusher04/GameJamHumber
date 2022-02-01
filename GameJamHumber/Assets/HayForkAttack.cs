using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HayForkAttack : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange;
    public float damge;
    private Transform player;
    private bool IsAttack;
    public LayerMask layPlayer;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<EnemyTracking>().Player;
    }

    // Update is called once per frame
    void Update()
    {
        
        IsAttack = Physics2D.OverlapCircle(attackPoint.position, attackRange, layPlayer);
        if (IsAttack)
        {
            Attack();

        }

        else GetComponent<EnemyTracking>().enabled = true;
    }
    void Attack()
    {
        GetComponent<EnemyTracking>().enabled = false;
        GetComponent<EnemyTracking>().body.velocity = Vector2.zero;
        Debug.Log("Enemy Attacked");
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
