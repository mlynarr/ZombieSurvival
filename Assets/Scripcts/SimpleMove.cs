using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class SimpleMove : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float turnSpeed = 200f;
    public float jumpforce = 8f;

    private Rigidbody rb;
    private Vector3 movement;
    private bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        float horizontalRotation = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;

        movement = transform.right * horizontalInput + transform.forward * verticalInput;
        movement = movement.normalized * movementSpeed;

        transform.Rotate(0, horizontalRotation, 0);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }
    }

    void FixedUpdate()
    {
        if(movement != Vector3.zero)
        {
            rb.MovePosition(rb.position + movement * Time.fixedDeltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void onCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
