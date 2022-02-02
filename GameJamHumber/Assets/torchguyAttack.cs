using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torchguyAttack : MonoBehaviour
{
    public GameObject target;
    public GameObject torch;
    private Animator anim;
    public float range;
    public float timeBtwAttacks;
    public float startAttackTimer;
    private bool FacingRight = false;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Distance from Enemy to Player
        float dist = Vector2.Distance(transform.position, target.transform.position);
        timeBtwAttacks -= Time.deltaTime;

        if (dist < range)
        {
            if (timeBtwAttacks <= 0)
            {
                anim.SetBool("Attack", true);
                Instantiate(torch, transform.position, transform.rotation);
                timeBtwAttacks = startAttackTimer;
            }
            
        }

        if (Vector3.Distance(target.transform.position, transform.position) < 20)
        {

            
            if (target.transform.position.x > transform.position.x && !FacingRight) //if the target is to the right of enemy and the enemy is not facing right
                Flip();
            if (target.transform.position.x < transform.position.x && FacingRight)
                Flip();
        }

    }


    void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
        FacingRight = !FacingRight;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
