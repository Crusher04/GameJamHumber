using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    public Transform blood;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Die()
    {
            Destroy(gameObject);
            Instantiate(blood, transform.position, transform.rotation);
    }

}
