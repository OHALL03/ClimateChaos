using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingDrone : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public float speed;

    int directon = 1;

    private void Update()
    {
        Vector2 target = currentMovementTarget();

        platform.position = Vector2.Lerp(platform.position, target, speed * Time.deltaTime);

        float distance = (target - (Vector2)platform.position).magnitude;

        if (distance <= 0.1f)
        {
            directon *= -1;
        }
    }

    Vector2 currentMovementTarget()
    {
        if(directon == 1)
        {
            return startPoint.position;
        }
        else
        {
            return endPoint.position;
        }
    }

    private void OnDrawGizmos()
    {
        if (platform!=null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);

        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"));
    //    {
    //        collision.transform.SetParent(transform);
    //        Debug.Log("hi");
    //    }
        
    //}
    //private void OnCollisionExit2D(Collision2D collision)
    //{
    //    collision.transform.SetParent(null);
    //}

}
