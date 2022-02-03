using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterDeath : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject deathScreen
        ;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
