using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionFriction : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pressure Box")
        {
            gameObject.transform.parent = collision.gameObject.transform;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pressure Box")
        {
            gameObject.transform.parent = null;
        }
    }

    void OnApplicationQuit()
    {
        gameObject.transform.parent = null;
    }
}
