using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rigidBody;
    public float jumpForce;

    GameData gameData = new GameData();
    private GameObject player;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        /*gameData.score = 100;
        gameData.level = 5;
        gameData.playerPosition = player.transform.position;

        SaveLoadManager saveLoadManager = GetComponent<SaveLoadManager>();
        saveLoadManager.SaveGame(gameData);*/
    }

    void Update()
    {
        Move();
        Jump();
    }

    public virtual void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CheckJumpForce();
        }
    }

    public virtual void Move()
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