using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class Knight_Script : MonoBehaviour
{
    //Integers
    [SerializeField] private int jumpCount = 0;

    //Rigidbody 2D
    [SerializeField] private Rigidbody2D rb;

    //Animator
    [SerializeField] private Animator animator;

    //GameObjects
    [SerializeField] private GameObject Weapon;

    //Floats
    [SerializeField] private float Direction;
    [SerializeField] private float Timer;
    [SerializeField] private float JumpPower = 5f;
    [SerializeField] private float MoveSpeed = 5f;
    
    //Header
    [Header("Health")]

    //Slider
    [SerializeField] Slider HealthSlider;
    
    //Integers
    [SerializeField] private int Health, MaxHealth;
    

    void Start()

    {
        animator.SetInteger("HealthPoint", 3);
    }

    void Update()

    {
        //Jumping Behavior
        if ((jumpCount < 2 && Input.GetKeyDown(KeyCode.Space)) 
            || jumpCount < 2 && Input.GetKeyDown(KeyCode.UpArrow) 
            || jumpCount < 2 && Input.GetKeyDown(KeyCode.W))
        {
            Jump();
            animator.SetBool("isJumping", true);
            Timer += Time.deltaTime;
            animator.SetBool("isIdle", false);
            animator.SetBool("isWalking", false);

        }
        if (Timer == 0.75f)
        {
            animator.SetBool("isJumping", false);
        }
        //Ending Jumping Behavior


        //Walking Behavior
        if (Input.GetAxis("Horizontal") != 0){

            //  Run Behavior
            while (Input.GetKey("left shift"))
            {
                MoveSpeed *= MoveSpeed;
                animator.SetBool("isRunning", true);
            }
            Move();
        } else
        {
            animator.SetBool("isWalking", false);
        }

            //This script specifies whether the knight is idle or not
        if (Direction == 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
    
    }
    //Methods
    void Jump()
    {
        jumpCount++; //The number of jumps increased, used to limit the jumps to 2.
         
        if (jumpCount == 1)
        {
            JumpPower = 2;
        }
        else
        {
            JumpPower = 1;
        }
       
        rb.AddForce(Vector2.up * JumpPower * 180f);
        CancelInvoke("ResetjumpCount");
        Invoke("ResetjumpCount", 3f);
    }
    void Move()
    {
        animator.SetBool("isWalking", true);
        Direction = Input.GetAxis("Horizontal");
        Vector3 Move = new Vector3(Direction, 0, 0);
        transform.position += Move * Time.deltaTime * MoveSpeed;
        if (Direction < 0)
        {
            Vector3 newRotation = new Vector3(0, -180, 0);
            transform.eulerAngles = newRotation;
        }
        else if (Direction > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

    }
    void ResetjumpCount()
    {
        jumpCount = 0;
    }    

    //The script below applies damage for the knight with the quantity that I want,where it can be used for many weapons
    public void ApplyDamage(int Damage)
    {
    Health -= Damage;
    HealthSlider.value = Health;
    }

    //The script below should detect the knife if touches the knight,
    //then it decreases from his health...
    //And if it is a coin it increases the coin counter...
    //If the knife hits the knight it creates an explosion with animation
    //which plays a force on the knight then destroys

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string item = collision.GetComponent<SpriteRenderer>().sprite.name;
        if (item.Equals("knife"))
        {
            print("Ouchhh");
            Destroy(collision.gameObject);
        }
    }

    }

