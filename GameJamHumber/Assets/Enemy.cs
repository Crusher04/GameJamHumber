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
    public GameObject blood;
    private GameObject player;
    Vector3 deathPos;
    public AudioSource hurtSound;
    public AudioSource hurtSound2;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("Attack", false);
        body = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        deathPos = this.gameObject.transform.position;

        if (GetComponent<torchguyAttack>() != null)
        {
            anim.Play("torchguy_idle");

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            anim.SetBool("Attack", false);
            anim.SetTrigger("Death");
            destroyDelay -= Time.deltaTime;
            

            if (GetComponent<EnemyTracking>() != null)
            {
                GetComponent<EnemyTracking>().enabled = false;
            }
           
            if (GetComponent<torchguyAttack>() != null)
            {
                GetComponent<torchguyAttack>().enabled = false;
            }

            if (destroyDelay <= 0)
            {
                Debug.Log("DestroyTime = " + destroyDelay);
                Instantiate(blood, deathPos, Quaternion.identity);
                Death();
                
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("DAMAGE TAKEN, Health left = " + health);
        int r = Random.Range(0, 1);

        if (r == 1)
        {
            hurtSound.Play();
        }
        else
            hurtSound2.Play();
    }

    public void Death()
    {
        Destroy(gameObject);
 
    }
}//End of class
