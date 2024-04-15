using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour
{
    public Transform warpTarget;
    public Transform Player;
    public Transform officeWarp;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CharacterController cc = Player.GetComponent<CharacterController>();
        if (Input.GetKeyDown(KeyCode.V))
        {
            cc.enabled = false;
            Player.transform.position = warpTarget.position;
            Debug.Log("Teleport!");
            cc.enabled = true;
        }
        if (Input.GetKeyUp(KeyCode.B))
        {
            cc.enabled = false;
            Player.transform.position = officeWarp.position;
            Debug.Log("TeleportBACK!");
            cc.enabled = true;
        }
    }
}
