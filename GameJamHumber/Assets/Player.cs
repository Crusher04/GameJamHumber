using UnityEngine;

public class Player : MonoBehaviour
{

    //Variables
    [SerializeField] private float speed;
    private Rigidbody2D body;
    public Animator anim;

    private bool grounded;
    private bool FacingRight = false;

    //Attack Variables
    private bool attack = false;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemies;
    public int damage;
    Vector3 mousePos;

    private float torchDamage = 1f;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        //Movement Code
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);

        //Jump Code
        if (Input.GetKey(KeyCode.Space) && grounded)
            jump();

        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded);

        //Flip sprite to face player
        if (body.velocity.x > 0 && FacingRight)
        {

            Flip();
        }

        if (body.velocity.x < 0 && !FacingRight)
        {
            Flip();
        }


        //Attack Code
        //Attack enemy
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
           // mousePos.z = transform.position.z;

            anim.SetTrigger("attack");
            Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
            for(int i = 0; i < enemiesToDamage.Length; i++)
            {
                enemiesToDamage[i].GetComponent<Enemy>().TakeDamage(damage);
            }
        }

    }//End of update

    //Controls jumping for player
    private void jump()
    {
        body.velocity = new Vector2(body.velocity.x, speed + 2f);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
            grounded = true;

        if (collision.gameObject.tag == "torch")
            GetComponent<Health>().TakeDamage(.25f);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        FacingRight = !FacingRight;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

}
