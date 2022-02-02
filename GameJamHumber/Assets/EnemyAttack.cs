using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public Transform attackPos;
    public float attackRange;
    public LayerMask isPlayer;
    private Animator anim;
    public float damage;
    public float timeBtwAttacks;
    public float startAttackTimer;
    private bool attacked = false;
    bool firstAttack = true;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
        timeBtwAttacks = startAttackTimer;
    }

    // Update is called once per frame
    void Update()
    {
        /* if(attacked)
         {
             timeBtwAttacks -= Time.deltaTime;
         }

         if(timeBtwAttacks <= 0)
         {
             attacked = false;
         }*/

        timeBtwAttacks -= Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        attack();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        attack();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        anim.SetBool("Attack", false);
    }

    private void attack()
    {

        /* if(firstAttack)
         {
             firstAttack = false;
             anim.SetBool("Attack", true);
             Collider2D[] playersToD = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isPlayer);
             for (int i = 0; i < playersToD.Length; i++)
             {
                 playersToD[i].GetComponent<Health>().TakeDamage(damage);
             }
         }

         if(timeBtwAttacks <= 0)
         {
             anim.SetBool("Attack", true);
             Collider2D[] playersToD = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isPlayer);
             for (int i = 0; i < playersToD.Length; i++)
             {
                 playersToD[i].GetComponent<Health>().TakeDamage(damage);
             }

             timeBtwAttacks = startAttackTimer;
             attacked = true;
         }*/

        if(timeBtwAttacks <= 0)
        {
            anim.SetBool("Attack", true);
            Collider2D[] playersToD = Physics2D.OverlapCircleAll(attackPos.position, attackRange, isPlayer);
            for (int i = 0; i < playersToD.Length; i++)
            {
                playersToD[i].GetComponent<Health>().TakeDamage(damage);
            }
            timeBtwAttacks = startAttackTimer;
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
