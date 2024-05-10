using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UItrigger : MonoBehaviour
{
    public UnityEvent Enter, Toggled, Untoggled, OtherInput, Exit;

    [Header("Assign Intereact button, PlayerMovement Reference")]
    public KeyCode Interact;
    public bool Active = false;
    public PlayerMovement PM;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Enter.Invoke();
            Debug.Log("Entered");
        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Active == false)
            {
                if (Input.GetKeyDown(Interact))
                {
                    Active = true;
                    Cursor.lockState = CursorLockMode.None;
                    Cursor.visible = true;
                    PM.canMove = false;
                    Toggled.Invoke();
                    Debug.Log("Toggled");
                }
            }
           
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                Active = false;
                Debug.Log("Active == false");
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                PM.canMove = true;
                Untoggled.Invoke();
                Debug.Log("Untoggled");
            }

            //This will act as a void Update to if statements in other scripts
            //Example if(Input.GetKeyDown(KeyCode.Enter){}, this will be checking for when the enter key is pressed
            OtherInput.Invoke();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Exit.Invoke();
            Debug.Log("Exited");
        }
    }

}
