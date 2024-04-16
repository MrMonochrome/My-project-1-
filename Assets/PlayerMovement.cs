using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jump;
    private Rigidbody2D body;
    public bool jumping = false;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal")*speed, body.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) & !jumping)
        {
            body.velocity = new Vector2(body.velocity.x, jump);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Pressure Box")
        {
            jumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Pressure Box")
        {
            jumping = true;
        }
    }

}
