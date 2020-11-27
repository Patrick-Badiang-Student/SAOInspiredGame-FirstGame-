using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
     //Movement
    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    
    public Transform GroundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public LayerMask Enemy;

    //Health
    public int MaxHealth = 100;
    public int currentHealth;
    public HealthbarScript healthBar;

    Vector3 velocity;
    bool isGrounded;

   
   void Start()
   {
       currentHealth = MaxHealth;
       healthBar.SetMaxHealth(MaxHealth);
   }
   
   
   
    void Update()
    {
        //Gravity implemented
        isGrounded = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y <0)
        {
            velocity.y = -2f;
        }

        //General movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
       
      if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
       {
         velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
       }

       velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
    //Health Code
    
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
}
