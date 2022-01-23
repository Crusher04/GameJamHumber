using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField]private float speed, jumpspeed, dashDistance;

    public LayerMask Ground;
    public Transform groundCheck;
    public Rigidbody2D rb;
    private PlayerController playerControl;
    Vector2 move = Vector2.zero;
    private float activeSpeed = 1f;
    public float dashSpeed;
    public float dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    private void Awake()
    {
        playerControl = new PlayerController();
    }
    private void OnEnable()
    {
        playerControl.Enable();
    }
    private void OnDisable()
    {
        playerControl.Disable();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void dash()
    {
        if (dashCoolCounter <= 0 && dashCounter <= 0)
        {
            activeSpeed = dashSpeed;
            dashCounter = dashDistance;
            Physics2D.IgnoreLayerCollision(3, 7, true);
        }

    }
    public void jump()
    {
        if (isGround())
        {
            rb.AddForce(new Vector2(0, jumpspeed), ForceMode2D.Impulse);
            
        }
    }

    private bool isGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, Ground);
    }

    // Update is called once per frame
    void Update()
    {
        move = playerControl.Player.Move.ReadValue<Vector2>();
        if (playerControl.Player.Jump.triggered)
        {
            jump();
        }
        if (playerControl.Player.Dash.triggered)
        {
            dash();
        }
        if (dashCounter > 0)
        {
            dashCounter -= Time.deltaTime;

            if (dashCounter <= 0)
            {
                activeSpeed = 1f;
                dashCoolCounter = dashCooldown;
                Physics2D.IgnoreLayerCollision(3, 7, false);
            }
        }
        if (dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
       
    }
   
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(move.x * speed * activeSpeed, rb.velocity.y);
        
    }
}
