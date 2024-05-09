using UnityEngine;
using TMPro;

public class TitleGlitch : MonoBehaviour
{
    public GameObject title1;
    public GameObject title2;

    public GameObject option1;
    public GameObject option2;

    public float glitchInterval = 0.5f; 

    private void Start()
    {
        InvokeRepeating("Glitch", 0f, glitchInterval);
        InvokeRepeating("OptionsGlitch", 0f, glitchInterval);
    }

    private void Glitch()
    {
        bool showTitle1 = Random.Range(0, 2) == 0;

        title1.gameObject.SetActive(showTitle1);
        title2.gameObject.SetActive(!showTitle1);
    }

    private void OptionsGlitch()
    {
        bool showOption1 = Random.Range(0, 2) == 0;

        option1.gameObject.SetActive(showOption1);
        option2.gameObject.SetActive(!showOption1);
    }
}
