using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{

    public Transform pointA, pointB;
    public float speed;
    public bool moveUp;

    private Transform originalParent;

    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveUp == true)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (transform.position.y <= pointB.position.y)
        {
            moveUp = true;
        }
        if (transform.position.y >= pointA.position.y)
        {
            moveUp = false;
        }
    }

    public void SetParent(Transform newParent)
    {
        originalParent = transform.parent;
        transform.parent = newParent;
    }

    public void ResetParent()
    {
        transform.parent = originalParent;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        var platformMovement = other.collider.GetComponent<VerticalPlatform>();
        if (platformMovement != null)
        {
            platformMovement.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var platformMovement = other.collider.GetComponent<VerticalPlatform>();
        if (platformMovement != null)
        {
            platformMovement.ResetParent();
        }
    }
}
