using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ninja_Script : MonoBehaviour
{
    public GameObject v;
    public float Timer;
    public Rigidbody2D rbNinja;
    // Start is called before the first frame update
    void Start()
    {   
        rbNinja.AddForce(Vector2.left * 10f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

//Destroy the Ninja after 1sec
    Timer += Time.deltaTime;
    if(Timer >= 1)
    {
            Destroy(v);  
    }
    }
}
