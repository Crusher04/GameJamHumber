using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    // Variables
    public float health = 10f;
    private Rigidbody2D body;
    public UIManager healthManager;

    // Get body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // If the player dies, destroy the player object
    public void Update()
    {
      if (healthManager.dead == true)
        {
            Destroy(gameObject);
        }

    }
}
