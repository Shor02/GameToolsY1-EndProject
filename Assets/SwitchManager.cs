using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class SwitchManager : MonoBehaviour
{

// variables for movement
public float speed = 5f; // movement speed
    private Rigidbody rb; // rb component of the player

    // variables for switching
    public Transform player1; // first player
    public Transform player2; // second player
    private bool isPlayer1Active = true; // flag for active player

    // variables for camera
    public Camera playerCamera; // camera following the player
    private Vector3 cameraOffset; // offset of camera from player

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // get the rb component
        cameraOffset = playerCamera.transform.position - transform.position; // calculate camera offset
    }

    // Update is called once per frame
    void Update()
    {
        // get input from horizontal and vertical axes
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // create movement vector based on input and speed
        Vector3 movement = new Vector3(horizontal, 0f, vertical) * speed * Time.deltaTime;

        // add the movement vector to the player's position
        rb.MovePosition(transform.position + movement);

        // switch between players when Space key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPlayers();
        }

        // update camera position to follow active player
        if (isPlayer1Active)
        {
            playerCamera.transform.position = player1.position + cameraOffset;
        }
        else
        {
            playerCamera.transform.position = player2.position + cameraOffset;
        }

    }

    // method to switch between players
    void SwitchPlayers()
    {
        // check which player is currently active
        if (isPlayer1Active)
        {
            // deactivate first player and activate second player
            player1.gameObject.SetActive(false);
            player2.gameObject.SetActive(true);
            isPlayer1Active = false;
        }
        else
        {
            // deactivate second player and activate first player
            player2.gameObject.SetActive(false);
            player1.gameObject.SetActive(true);
            isPlayer1Active = true;
        }
    }
}

