using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Script : MonoBehaviour
{
    //GameObjects
    [SerializeField] GameObject MenuPanel;
    void Start()
    {
        MenuPanel.SetActive(false);
    }

    void Update()
    {
        
    }
    public void OpenSettings()
    {
        MenuPanel.SetActive(true);
        
    }
    public void CloseSettings()
    {
        MenuPanel.SetActive(false);
       
    }
}
