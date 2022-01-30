using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float DieTime, Damage;
    public GameObject diePEFFECT;
    void Start()
    {
        StartCoroutine(CountDownTimer());
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Die();
    }


    void Update()
    {
        
    }
    IEnumerator CountDownTimer()
    {
        yield return new WaitForSeconds(DieTime);

        Die();
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
