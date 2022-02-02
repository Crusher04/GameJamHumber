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
                anim.SetTrigger("Attack");
                Instantiate(torch, transform.position, transform.rotation);
                timeBtwAttacks = startAttackTimer;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
