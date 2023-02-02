using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed;

    private Rigidbody rigidBody;

    public float jumpForce;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        Jump();
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            CheckJumpForce();
        }
    }

    void Move()
    {
        //Get our inputs
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;
        dir.y = rigidBody.velocity.y;
        rigidBody.velocity = dir;

        Vector3 facingDir = new Vector3(xInput, 0, zInput);

        if (facingDir.magnitude > 0)
        {
            transform.forward = facingDir;
        }
    }

    void CheckJumpForce()
    {
        rigidBody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
