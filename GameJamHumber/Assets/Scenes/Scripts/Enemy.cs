using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public TypeEnemy enemy;
    float currentHealth;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = enemy.health;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GetComponent<EnemyDeath>().Die();
        }
    }
    // Update is called once per frame
    void Update()
    {
        float dist = Vector2.Distance(transform.position, Player.position);
        if (dist < enemy.range)
        {
            GetComponent<EnemyAttack>().Active();
        }
        else
        {
            GetComponent<EnemyMovement>().Movement();
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (gameObject.transform.position == null) return;

        Gizmos.DrawWireSphere(gameObject.transform.position, enemy.range);
    }
}
