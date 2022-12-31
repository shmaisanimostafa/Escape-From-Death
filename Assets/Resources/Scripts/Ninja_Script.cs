using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ninja_Script : MonoBehaviour
{
    public Rigidbody2D rbNinja;
    // Start is called before the first frame update
    void Start()
    {
        rbNinja.AddForce(Vector2.left * 5f, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
