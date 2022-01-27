using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    // Variables
    [SerializeField] private float spd;
    [SerializeField] private bool mRight;
    public float activeChange = 0f;
    public float directionChange = 0f;
    private SpriteRenderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        if (_renderer == null)
        {
            Debug.LogError("Player Sprite is missing a renderer");
        }

        activeChange = directionChange;
    }

    void Update()
    {
        

        // Check if enemy is set to move right, If it is then move right
        if (mRight)
        {
            transform.Translate(2 * Time.deltaTime * spd, 0, 0);
            //transform.localScale = new Vector2(-1, 1);
            _renderer.flipX = false;
        }
        // If it is not set to move right, move left
        else
        {
            transform.Translate(-2 * Time.deltaTime * spd, 0, 0);
            // transform.localScale = new Vector2(1, 1);
            _renderer.flipX = true;

        }

        activeChange -= Time.deltaTime;
        if (activeChange < 0)
        {
            mRight = !mRight;
            activeChange = directionChange;
        }

    }//End of update

}//End of class
