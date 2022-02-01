using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    //Variables
    public int health;
    public Animator anim;
    public float destroyDelay = .7f;
    public Animation deathEffect;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
