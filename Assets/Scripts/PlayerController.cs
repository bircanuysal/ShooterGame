using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;
    Vector3 velocity;
    bool isGrounded;
    public Transform ground;
    public float distance = 0.3f;

    public LayerMask mask;
    public float speed;
    public float jumpHeight;
    public float gravity;
    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * speed * Time.deltaTime);

        //jump
        if (Input.GetKeyDown(KeyCode.Space) &&isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -80.0f * gravity);
        }

        //gravity
        isGrounded = Physics.CheckSphere(ground.position, distance, mask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }
}
