using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{

    public Transform pointA, pointB;
    public float speed;
    public bool moveRight;

    private Transform originalParent;

    // Start is called before the first frame update
    void Start()
    {
        originalParent = transform.parent;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveRight == true)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        }
        else
        {
            transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
        }
        if (transform.position.x <= pointB.position.x)
        {
            moveRight = true;
        }
        if (transform.position.x >= pointA.position.x)
        {
            moveRight = false;
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
        var platformMovement = other.collider.GetComponent<HorizontalPlatform>();
        if (platformMovement != null)
        {
            platformMovement.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        var platformMovement = other.collider.GetComponent<HorizontalPlatform>();
        if (platformMovement != null)
        {
            platformMovement.ResetParent();
        }
    }
}
