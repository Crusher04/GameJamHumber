using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blood : MonoBehaviour
{
    // Variables
    public Transform player;
    public UIManager bloodManager;

    // // Function that destroys the blood once it is picked up
    void Update()     
    {   
        // Distance is equal to the difference between player position and blood position
        float dist = Vector2.Distance(transform.position, player.position);

        // If the distance is less than 1 and the "T" key is pressed then the blood is destroyed!
        if (dist < 1 && Input.GetKey(KeyCode.T))
        {
            Destroy(gameObject);
            bloodManager.AddBlood();
        }
    }
}
