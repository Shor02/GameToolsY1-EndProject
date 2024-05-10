using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NpcDialogueManager : MonoBehaviour
{
    [SerializeField] TMP_Text Dialogue;

    [SerializeField] TMP_Text Name;

    [SerializeField] GameObject GlitchNPC;


    public string[] firstDialogue;

    public string[] secondDialogue;

    public string[] thirdDialogue;

    public string[] finalDialogue;

    public string[] names = new string [4];

    // index will select what sentence we want from a dialogue
    int index = 0;
    //Display is the string that will be put out to the Dialogue TMP text
    string Display;
    //This tells us what Dialogue has been selected
    int DialogueIndex;

    bool canPress = true;


    private void Start()
    {
        index = 0;
        GlitchNPC.SetActive(false);
    }
    public void FirstDialogue()
    {
        Name.text = names[0];
        DialogueIndex = 0;
        Display = firstDialogue[index];
        StartCoroutine(TextDelay());
       

    }

    public void SecondDialogue()
    {
        Name.text = names[1];
        DialogueIndex = 1;
        Display = secondDialogue[index];
        StartCoroutine(TextDelay());
    }

    public void ThirdDialogue()
    {
        Name.text = names[2];
        DialogueIndex = 1;
        Display = thirdDialogue[index];
        StartCoroutine(TextDelay());
    }

    public void FinalDialogue()
    {
        GlitchNPC.SetActive(true);
        Name.text = names[3];
        DialogueIndex = 1;
        Display = finalDialogue[index];
        StartCoroutine(TextDelay());
    }

    public void IndexValue()
    {
        if (canPress == true)
        {

            if (Input.GetKeyDown(KeyCode.Mouse0) || (Input.GetKeyDown(KeyCode.KeypadEnter)))
            {
                StartCoroutine(PressDelay());

                if (index < 2)
                {
                    
                    index++;

                    if (DialogueIndex == 0)
                    {
                        FirstDialogue();
                    }
                    else if (DialogueIndex == 1)
                    {
                        SecondDialogue();
                    }
                    else if (DialogueIndex == 2)
                    {
                        ThirdDialogue();
                    }
                    else if (DialogueIndex == 3)
                    {
                        FinalDialogue();
                    }

                }
                else if (index == 2)
                {
                    Dialogue.text = "They've told you everthing";

                }


            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                StartCoroutine(PressDelay());

                if (index > 0)
                {
                    index--;

                    switch (DialogueIndex)
                    {
                        case 0:
                            FirstDialogue();
                            break;
                        case 1:
                            SecondDialogue();
                            break;
                        case 2:
                            ThirdDialogue();
                            break;
                        case 3:
                            FinalDialogue();
                            break;
                    }
                }
            }
            else if (Input.GetKeyDown(KeyCode.R))
            {
                ResetIndex();
            }
        }

    }
    
    IEnumerator TextDelay()
    {
        Dialogue.text = string.Empty;

        for(int i = 0; i < Display.Length; i++)
        {
            Dialogue.text += Display[i];
            yield return new WaitForSeconds(0.005f);
            Debug.Log(i);
        }
        yield return null;
    }

    IEnumerator PressDelay()
    {
        canPress = false;
        yield return new WaitForSeconds(1f);
        canPress = true;
    }

    public void ResetIndex() 
    {
        index = 0;
        GlitchNPC.SetActive(false);
    }
}
   


