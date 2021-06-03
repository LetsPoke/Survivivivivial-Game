using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour //copied from https://www.youtube.com/watch?v=_QajrabyTJc&t=1202s
{
    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask groundMask;
    public float moveSpeed = 12f;
    public float gravity = -9.81f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    //clickMovment
    private NavMeshAgent agent;

    public float rotateSpeedMovement = 0.1f;
    float rotateVelocity;
    // Update is called once per frame
    void Update()
    {
        //movement
        agent = gameObject.GetComponent<NavMeshAgent>();
        //When pressing the left mouse button
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;

            //Checking if the raycast shot hits something that uses the navmesh system
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, Mathf.Infinity))
            {
                agent.SetDestination(hit.point);
                
                Quaternion rotationToLookAt = Quaternion.LookRotation(hit.point - transform.position);
                float rotationY = Mathf.SmoothDampAngle(transform.eulerAngles.y,
                    rotationToLookAt.eulerAngles.y,
                    ref rotateVelocity,
                    rotateSpeedMovement * (Time.deltaTime * 5));

                transform.eulerAngles = new Vector3(0, rotationY, 0);
            }
        }
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //if(isGrounded && velocity.y < 0){
        //    velocity.y = -2f;
        //}

        //Keyboard Input
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        //Movement
        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Jumping
        //if(Input.GetButtonDown("Jump") && isGrounded){
        //    velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity); //crazy math formal for accurat jumping
        //}

        //Gravity
        //velocity.y += gravity * Time.deltaTime;
        //controller.Move(velocity * Time.deltaTime); // 2 times delta time because of math shit
    }
}
