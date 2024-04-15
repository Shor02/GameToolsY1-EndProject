using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private Rigidbody rb;
    private Transform objectGrabPointTransform;
    [SerializeField] private float speed = 10f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            Vector3 targetDestination = objectGrabPointTransform.position - rb.position;

            rb.velocity = new Vector3(targetDestination.x, targetDestination.y, targetDestination.z) * speed; //This way the object moves at a velocity instead of changing position contantly;
            rb.useGravity = false;
        }
    }

    public void Grab(Transform objectGrabPointTransform)
    {
        this.objectGrabPointTransform = objectGrabPointTransform;
        rb.useGravity = false;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        rb.useGravity = true;
    }

    public void Throw(Vector3 position, float throwPow)
    {
        objectGrabPointTransform = null;
        rb.useGravity = true;
        rb.AddForce(position * throwPow, ForceMode.Impulse);
    }

}
