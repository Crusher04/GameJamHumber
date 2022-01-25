using UnityEngine;


/// Basic Player movement system, will not be used in the final project

public class PlayerMovement : MonoBehaviour
{
    // Variables
    [SerializeField] private float speed;
    private Rigidbody2D body;
   
    // Get body component
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Player movement based on keyboard checks
    private void Update()
    {
        // Built-in Unity function that checks if "A" or "D" are pressed, if they are, move left or move right
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        // If "Space" key is pressed than change Player's y position and allow him to jump
        if (Input.GetKey(KeyCode.Space))
        { 
            body.velocity = new Vector2(body.velocity.x, speed); 
        }
    }
}
