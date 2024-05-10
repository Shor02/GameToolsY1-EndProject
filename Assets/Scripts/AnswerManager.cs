using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AnswerManager : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    [SerializeField] Image result;
    [SerializeField] TMP_Text QuestionText;
    public GameObject QuizUi;
    
    public string[] Questions = new string[5];
    public string[] Answers = new string[5];
    
    public int i = 0;
    public float Delay;
    public float DisableDelay;

    private void Start()
    {
        QuestionText.text = Questions[i];
    }
   
    public void CheckAnswer()
    {
        

        string input = inputField.text;
        if (input.ToUpper() == Answers[i].ToUpper())
        {
            result.color = Color.green;

            StartCoroutine(textreset());

            if (i < Questions.Length-1)
            {
              i++;
              QuestionText.text = Questions[i];
            }
            
            inputField.text = null;
        }
        else
        {
            result.color = Color.red;
            StartCoroutine(textreset());
            inputField.text = null;
         
            
        } 

        IEnumerator textreset()
        {
            yield return new WaitForSeconds(Delay);
            result.color = Color.grey;
          
        }

    }
}
