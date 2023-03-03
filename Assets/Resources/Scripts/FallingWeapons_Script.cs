using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingWeapons_Script : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject Explosion;
    //Animator
    [SerializeField] private Animator animator;
    //Images
    [SerializeField] Sprite[] WeaponImages;
    //Floats
    [SerializeField] private float height, width;

    void Start()
    {
        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y;
        width = screenWorld.x;
        StartCoroutine(WeaponSpawner());
    }

    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") 
        { 
            Destroy(gameObject);
            GameObject v = GameObject.Instantiate(Explosion);
            v.transform.position = collision.transform.position;
           
            

        }
        if (collision.gameObject.tag == "Player") { print("Ouchhh"); }
    }

    IEnumerator WeaponSpawner()
    {
        while (true)
        {
            GameObject v = GameObject.Instantiate(Weapon);
            v.transform.position = new Vector3(Random.Range(-width, width), height, 0);
            v.GetComponent<SpriteRenderer>().sprite = WeaponImages[Random.Range(0, WeaponImages.Length)];
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
        //Here we should add some scripts that detects if the spawned knife hits the floor,
        //it creats and explode object which plays an animation then destroys
    }

}
