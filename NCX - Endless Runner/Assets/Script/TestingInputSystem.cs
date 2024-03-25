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
        //float verticalInput = Input.GetAxis("Vertical");

        /*if ((transform.position.x + verticalInput > 4.50f || transform.position.x + verticalInput < -4.50f))
        {
            verticalInput = 0;
        }*/

        if ((transform.position.z - horizontalInput < -4.45f || transform.position.z - horizontalInput > 3.65f))
        {
            horizontalInput = 0;
        }


        Vector3 movement = new Vector3(0f, 0f, -horizontalInput) * moveSpeed * Time.deltaTime;
        characterRigidbody.MovePosition(transform.position + movement);
        //characterRigidbody.MovePosition(Vector3.Lerp(transform.position, transform.position + movement, 1));

    }

    private void OnTriggerEnter(Collider other)
    {
        canJump = true;
    }
}
