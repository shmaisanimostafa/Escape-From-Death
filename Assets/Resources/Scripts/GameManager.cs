using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject Coin;

    //[SerializeField] GameObject Thunder;

    //    [SerializeField] GameObject HealthPoint;


    //Floats
    [SerializeField] private float height, width;
    //[SerializeField] private float thunderTimer;
    //public float thunderCounter;
    //public float thunderScale;

    //Integers
    [SerializeField] private int CoinCounter;

    //Text
    [SerializeField] private Text CoinCount;
    [SerializeField] private Text PlayerName;

    void Start()
    {
        //thunderCounter = Random.Range(3, 5);
        //thunderScale = Random.Range(-1, 1.68f);
        //thunderTimer += Time.deltaTime;

        Vector3 screenWorld = new Vector3(Screen.width, Screen.height, 0);
        screenWorld = Camera.main.ScreenToWorldPoint(screenWorld);
        height = screenWorld.y;
        width = screenWorld.x;
        StartCoroutine(CoinSpawner());
        //   StartCoroutine(ThunderSpawner());
        //   StartCoroutine(HealthPointSpawner());

    }


    void Update()
    {

    }

    //Enumerators
    IEnumerator CoinSpawner()
    {
        while (true)
        {
            GameObject v = GameObject.Instantiate(Coin);
            v.transform.position = new Vector3(Random.Range(-width, width), 0.2f, 0);

            yield return new WaitForSeconds(Random.Range(20f, 40f));
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

    //Methods

    public void Pause()
    {
        StopAllCoroutines();
    }
    public void Play()
    {
        StartCoroutine(CoinSpawner());
   //    StartCoroutine(HealthPointSpawner());

    }
    public void CoinIncrementer()
    {
        CoinCount.text = " " + CoinCounter;
    }

}
//We should take text from input and close it so it will be shown in the settings top bar.