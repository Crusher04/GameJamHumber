using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Variables
    public Text timeText;
    public Text bloodText;
    int bld = 0;
    public Text healthText;
    public double health = 100;
    public bool dead = false;
    public bool hit = false;
    public float timeRemaining = 179;
    public bool timerIsRunning = true;

    // Draws Health to screen at the start of the game
    void Start()
    {
        health = 100;
        healthText.text = "Health:" + health.ToString();
        timerIsRunning = true;
    }

    // If health equals 0 then the player is dead
    public void Update()
    {
        if (health == 0 || health <= 0)
        {
            dead = true;
        }

        
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
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

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("Sunrise Inbound: {0:00}:{1:00}", minutes, seconds);
    }

}
