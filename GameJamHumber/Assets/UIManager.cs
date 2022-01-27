using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variables
    public Text bloodText;
    int bld = 0;
    public Text healthText;
    public double health = 100;
    public bool dead = false;
    public bool hit = false;

    // Draws Health to screen at the start of the game
    void Start()
    {
        health = 100;
        healthText.text = "Health:" + health.ToString();
    }

    // If health equals 0 then the player is dead
    public void Update()
    {
        if (health == 0 || health <= 0)
        {
            dead = true;
        }
    }

    // Function that adds blood to total blood when it is picked up
    public void AddBlood()
    {
        bld += 10;
        bloodText.text = "Blood:" + bld.ToString();

    }
    
    // Function that subtracts health when player is attacked
    public void LoseHealth_()
    {
        health -= 1;
        healthText.text = "Health:" + health.ToString();
        

    }
  
}
