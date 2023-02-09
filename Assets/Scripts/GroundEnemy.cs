using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEnemy : Movement
{
    public override void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CheckJumpForce();
        }
    }

    public override void Move()
    {
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        Vector3 dir = new Vector3(xInput, 0, zInput) * moveSpeed;

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
