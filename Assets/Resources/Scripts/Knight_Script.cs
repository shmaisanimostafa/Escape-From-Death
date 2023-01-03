using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Knight_Script : MonoBehaviour
{
    //Integers
    private int jumpCount = 0;

    //Rigidbody 2D
    public Rigidbody2D rb;

    //Animator
    public Animator animator;

    //GameObjects
    private GameObject Weapon;

    //Floats
    private float Direction;
    private float Timer;
    [SerializeField] float JumpPower = 5f;
    [SerializeField] float MoveSpeed = 5f;

    //Start Method
    void Start()

    {
        animator.SetInteger("HealthPoint", 3);
    }

    //Update Method
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

            //Run Behavior
            //while (Input.GetKey("left shift"))
            //{
            //    MoveSpeed *= MoveSpeed;
            //    animator.SetBool("isRunning", true);
            //}
            //End Run Behavior

            Move();
        } else
        {
            animator.SetBool("isWalking", false);
        }
        //Ending Walking Behavior

            //Walking and Not Jumping (Idle or not)
        if (Direction == 0 && !Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJumping", false);
            animator.SetBool("isWalking", false);
            animator.SetBool("isIdle", true);
        }
        //Ending Walking and Not Jumping (Idle or not)

  //      OnTriggerEnter2D(Collider other);
    }
    //Jump Method
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
    //Move Method
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
    //JumpCounterReset Method
    void ResetjumpCount()
    {
        jumpCount = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Weapon = other.gameObject;
        Destroy(Weapon);
    }
}


