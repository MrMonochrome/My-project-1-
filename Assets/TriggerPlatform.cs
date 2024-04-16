using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlatform : MonoBehaviour
{
    public Transform platform;
    public Transform startPoint;
    public Transform endPoint;
    public Transform player;
    public float speed = 1.5f;
    public int direction = 0;
    private bool triggered = false;

    private void Update()
    {

        if (triggered)
        {
            Debug.Log("Triggered");
            Vector2 target = endPoint.position;
            platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
        }
        else
        {
            Debug.Log("Not Triggered");
            Vector2 target = startPoint.position;
            platform.position = Vector2.MoveTowards(platform.position, target, speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Entered");
            triggered = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Debug.Log("Exited");
            triggered = false;
        }
    }
}