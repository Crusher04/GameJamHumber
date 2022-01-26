using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float spd;
    [SerializeField] private bool mRight;
    
    void Update()
    {

    }
    void OnCollisionEnter2D (Collision2D trigger)
    {
        Debug.Log("switch");
        //If enemy collides with the switch, change direction
        if(trigger.gameObject.layer == 7)
        {
            mRight = !mRight;
        }
    }
    public void Movement()
    {
        // Check if enemy is set to move right, If it is then move right
        if (mRight)
        {
            transform.Translate(2 * Time.deltaTime * spd, 0, 0);
        }
        // If it is not set to move right, move left
        if (!mRight)
        {
            transform.Translate(-2 * Time.deltaTime * spd, 0, 0);
        }
        
    }

    // A switch that changes the move direction for the enemy


}
