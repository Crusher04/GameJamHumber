using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    public GameObject Player;
    private Rigidbody2D body;
    private bool falling = true;
    public Collider2D coll;
    public Collider2D trigger;
    [SerializeField] private AudioClip pickupSound; 
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        body = GetComponent<Rigidbody2D>(); ;
    }

    // Update is called once per frame
    void Update()
    {
        if(body.velocity.y <= 0 && !falling)
        {
            falling = false;
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collided with blood");
        body.isKinematic = true;
        
        if (Player.GetComponent<Health>().currentHealth < 5 && collision.gameObject.tag != "ground")
        {

            coll.enabled = true;
            Player.GetComponent<Health>().AddHealth(.5f);
            Destroy(gameObject);
            SoundManager.instance.PlaySound(pickupSound);
        }
        else if(collision.gameObject.tag != "ground")
        {
            coll.enabled = false;
        }

    }
 
}
