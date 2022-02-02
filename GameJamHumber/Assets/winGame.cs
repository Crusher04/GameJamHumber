using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winGame : MonoBehaviour
{

    public GameObject winScreen;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        winScreen.SetActive(true);
        Time.timeScale = 0f;
    }
}
