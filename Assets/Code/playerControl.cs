using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControl : MonoBehaviour
{
    public float maxSpeed;
    public float jumpForce;
    Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    //Character horizontal movement
    void Move()
    {
        //Move speed
        float h = Input.GetAxis("Horizontal"); //+ or -

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right max speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < -maxSpeed) //Left max speed
            rigid.velocity = new Vector2(-maxSpeed, rigid.velocity.y);
    }

    void Jump()
    {
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
