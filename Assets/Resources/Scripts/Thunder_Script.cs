using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Thunder_Script : MonoBehaviour
{
    public GameObject Thunder;
    float height, width;

    // Start is called before the first frame update
    void Start()
    {

        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y / 2;
        width = screenWorld.x;

    }
    

    // Update is called once per frame
    void Update()
    {
        
            while (true)
            {
            
            GameObject v = GameObject.Instantiate(Thunder);
            v.transform.position = new Vector3(Random.Range(-width, width), 0.2f, 0);
            GameObject f = GameObject.Instantiate(Thunder);
            f.transform.position = new Vector3(Random.Range(-width, width), 0.2f, 0);
            GameObject x = GameObject.Instantiate(Thunder);
            x.transform.position = new Vector3(Random.Range(-width, width), 0.2f, 0);
            }   
        
    }
}
