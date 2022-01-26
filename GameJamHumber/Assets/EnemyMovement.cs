using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float spd;
    [SerializeField] private bool mRight;

    
    void Update()
    {
        // Check if enemy is set to move right, If it is then move right
        if (mRight)
        {
            transform.Translate(2 * Time.deltaTime * spd, 0, 0);
        }
        // If it is not set to move right, move left
        else
        {
            transform.Translate(-2 * Time.deltaTime * spd, 0, 0);
        }
    }

    // A switch that changes the move direction for the enemy
    void OnTriggerEnter2D(Collider2D trigger)
    {
        //If enemy collides with the switch, change direction
        if (trigger.gameObject.CompareTag("switch"))
        {
            if (mRight)
            {
                mRight = false;
            }
            else
            {
                mRight = true;
            }
        }
    }


}
