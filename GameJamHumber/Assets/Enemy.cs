using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Variables
    public int health;
    private Animator anim;
    public float destroyDelay = .7f;
    private Animation deathEffect;
    //public Transform Player;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetTrigger("Death");
            destroyDelay -= Time.deltaTime;
            GetComponent<EnemyTracking>().enabled = false;

            if (destroyDelay <= 0)
            {
                Debug.Log("DestroyTime = " + destroyDelay);
                Destroy(gameObject);
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE TAKEN, Health left = " + health);
    }

    public void Death()
    { 
        Destroy(this);
        destroyDelay -= Time.deltaTime*2;
        if (destroyDelay <= 0)
        {
            Debug.Log("DestroyTime = " + destroyDelay);
            Destroy(gameObject);
        }
    }
}//End of class
