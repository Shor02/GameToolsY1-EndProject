using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMananger : MonoBehaviour
{
    public GameObject[] UI = new GameObject[3];

    public bool Active = false;
    public void Awake()
    {
        for (int index = 0; index < 3; index++)
        {
            UI[index].SetActive(false);
        }
    }
    public void ToggleMainUI()
    {
            UI[0].SetActive(true);
            Debug.Log("Computer UI active");
            Active = true;
        
    }

    public void ToggleNPCUI()
    {
        UI[1].SetActive(true);
        Debug.Log("NPC Dialogue active");
        
    }

    public void ToggleSecretUI()
    {
        UI[2].SetActive(true);
        Debug.Log("Secret UI active");
    }

    public void ToggleOff()
    {
        for (int index = 0; index < 3; index++)
        {
            UI[index].SetActive(false);
        }
    }
}
