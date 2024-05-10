using UnityEngine;
using TMPro;

public class TitleGlitch : MonoBehaviour
{
    public GameObject title1;
    public GameObject title2;

    public GameObject option1;
    public GameObject option2;

    public GameObject optionsPanel;

    public float glitchInterval = 0.5f;
    public AudioClip glitchSound; 
    public AudioSource audioSource; 
    private bool previousTitleState;
    private bool previousOptionState;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>(); 
        InvokeRepeating("Glitch", 0f, glitchInterval);
        InvokeRepeating("OptionsGlitch", 0f, glitchInterval);
        optionsPanel.SetActive(false);
        previousTitleState = false;
        previousOptionState = false;
    }

    private void Glitch()
    {
        bool showTitle1 = Random.Range(0, 2) == 0;

        title1.SetActive(showTitle1);
        title2.SetActive(!showTitle1);

        if (showTitle1 != previousTitleState)
        {
            if (glitchSound != null)
            {
                audioSource.PlayOneShot(glitchSound);
            }
            previousTitleState = showTitle1;
        }
    }

    private void OptionsGlitch()
    {
        bool showOption1 = Random.Range(0, 2) == 0;

        option1.SetActive(showOption1);
        option2.SetActive(!showOption1);

        if (showOption1 != previousOptionState)
        {
            if (glitchSound != null)
            {
                audioSource.PlayOneShot(glitchSound);
            }
            previousOptionState = showOption1;
        }
    }
}
