using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUp : MonoBehaviour
{
    // Variables

    public Transform blood;
    private Rigidbody2D body;
    public UIManager bloodManager;
    

    // Get body component
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Player Picking up blood
    void Update()
    {
        // Distance is equal to the difference between player position and blood position
        float dist = Vector2.Distance(transform.position, blood.position);

        // If the distance is less than 1 and the "T" key is pressed than the function will be called
        if (dist < 1 && Input.GetKey(KeyCode.T))
        {
      
            bloodManager.AddBlood();
            
        }
    }
}
