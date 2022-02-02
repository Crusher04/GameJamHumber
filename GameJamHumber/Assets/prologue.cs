using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prologue : MonoBehaviour
{
    public float timer = 15;
    private AudioSource soundtrack;
    private float fadeTime = 10f;

    // Start is called before the first frame update
    void Start()
    {
        soundtrack = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
            //AudioSource.Destroy();
        }

        if (timer <= 5)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
        }

        if (timer < 5)
        {
            StartCoroutine(FadeOut(soundtrack, fadeTime));
        }
    }

    public static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
            yield return null;
        }
        audioSource.Stop();
    }
}
