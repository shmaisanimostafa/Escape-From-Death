using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject Coin;
    [SerializeField] GameObject Knife;
    [SerializeField] GameObject Thunder;
//    [SerializeField] GameObject HealthPoint;
    [SerializeField] Sprite[] WeaponImages;
    float height, width;
    float thunderTimer;
    public float thunderCounter;
    public float thunderScale;

    // Start is called before the first frame update
    void Start()
    {
        thunderCounter = Random.Range(3, 5);
        thunderScale = Random.Range(-1, 1.68f);
        thunderTimer += Time.deltaTime;

        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y;
        width = screenWorld.x;
        StartCoroutine(CoinSpawner());
        StartCoroutine(WeaponSpawner());
        //   StartCoroutine(ThunderSpawner());
        //   StartCoroutine(HealthPointSpawner());
    }


    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator CoinSpawner()
    {
        while (true)
        {
            GameObject v = GameObject.Instantiate(Coin);
            v.transform.position = new Vector3(Random.Range(-width, width), 0.2f, 0);

            yield return new WaitForSeconds(Random.Range(20f, 40f));
        }
    }

    IEnumerator WeaponSpawner()
    {
        while (true)
        {
            GameObject v = GameObject.Instantiate(Knife);
            v.transform.position = new Vector3(Random.Range(-width, width), height, 0);
            v.GetComponent<SpriteRenderer>().sprite = WeaponImages[Random.Range(0, WeaponImages.Length)];
            yield return new WaitForSeconds(Random.Range(2f, 4f));
        }
    }

    //IEnumerator ThunderSpawner()
    //{
       
        
    //    while (thunderTimer < 1)
    //    {
    //        for (int i = 0; i< thunderCounter; i++)
    //        {
    //            GameObject v = GameObject.Instantiate(Thunder);
    //            v.transform.position = new Vector3(Random.Range(-width, width), 0, 0);              
    //            v.transform.localScale= new Vector3(thunderScale, thunderScale, thunderScale);
    //        }
    //    }
    //}


    //IEnumerator HealthPointSpawner()
    //{
    //    while (true)
    //    {
    //        for (int i = 0; i < counter; i++)
    //        {
    //            GameObject v = GameObject.Instantiate(HealthPoint);
    //            v.transform.position = new Vector3(-8 + i, height - i, 0);
    //        }
    //    }
    //}

    //Pause Method
    public void Pause()
    {
        StopAllCoroutines();
    }
    public void Play()
    {
        StartCoroutine(CoinSpawner());
        StartCoroutine(WeaponSpawner());
   //    StartCoroutine(HealthPointSpawner());

    }
    void OnCollisionEnter2D(Collision Col)
    {
    if(Col.Collider.GameObject.CompareTag("Player"))
    {
    Knight_Script.ApplyDamage(25); 
    }
    Destroy(GameObject);
    }
}
