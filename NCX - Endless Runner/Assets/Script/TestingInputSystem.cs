using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody characterRigidbody;
    public float moveSpeed = 5f;
    public bool canJump;

    private void Update()
    {
        Move();
    }

    private void Awake()
    {
        characterRigidbody = GetComponent<Rigidbody>();

    }
    public void Jump()
    {
        if (canJump)
        {
            characterRigidbody.AddForce(Vector3.up * 25f, ForceMode.Impulse);
            canJump = false;

        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if(!(transform.position.x + verticalInput > -0.35 || transform.position.x + verticalInput < 0.35))
        {
            verticalInput = 0;
            
        }

        if (!(transform.position.y + horizontalInput > -0.6 || transform.position.y + horizontalInput < 0.6))
        {
            horizontalInput = 0;

        }

        Vector3 movement = new Vector3(verticalInput, 0f, -horizontalInput) * moveSpeed * Time.deltaTime;
        characterRigidbody.MovePosition(transform.position + movement);

    }

    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }
}
