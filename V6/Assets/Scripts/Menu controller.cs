using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Menucontroller : MonoBehaviour
{
    public GameObject menuPanel;
    public Movement playermovement;
    public Button continueButton;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
        }

    }

    public void Start()
    {
        if (DataSerializer.AnySaves() == false)
        {
            continueButton.interactable = false;
        }
        else
        {
            continueButton.interactable = true;
        }
    }

    public void NewGame()
    {
        new SaveData();
    }

    public void Save()
    {
        playermovement.Save();
        DataSerializer.Save();

        if (DataSerializer.AnySaves() == true)
        {
            continueButton.interactable = true;
        }
        
    }

    public void Continue()
    {
        DataSerializer.Load();
        menuPanel.SetActive(!menuPanel.activeSelf);
    }

    public void Exit()
    {

    }
   
}
