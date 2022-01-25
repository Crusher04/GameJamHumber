using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Transform blood;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Y))
        {
            Destroy(gameObject);
            Instantiate(blood, body.position, transform.rotation);
        }
    }
}
