using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController characterController;

    public float speed = 32f;

    private float gravity  =  -9.81f;

    public Transform groundCheck;

    public float sphereRadious = 0.3f;

    public LayerMask groundMask;

    bool isGrounded;

    Vector3 velocity;

    public float jumpHeight = 3f;

    float x,y,z;

    //VARIABLES PARA ANIMACIONES
    private Animator anim;


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {


    isGrounded = Physics.CheckSphere(groundCheck.position, sphereRadious, groundMask);

    if(isGrounded && velocity.y < 0){
        velocity.y = -2f;
    }
    
    x = Input.GetAxis("Horizontal");

    z= Input.GetAxis("Vertical");

    Vector3 move  = transform.right * x + transform.forward * z;


    if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    characterController.Move(move * speed * Time.deltaTime);


    velocity.y += gravity * Time.deltaTime;

    characterController.Move(velocity * Time.deltaTime);

    anim.SetFloat("VelX",x);
    anim.SetFloat("VelY",z);

    }
}
