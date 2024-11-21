using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menucontroller : MonoBehaviour
{
    public GameObject menuPanel;
    public Movement playermovement;
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuPanel.SetActive(!menuPanel.activeSelf);
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
    }
    public void Continue()
    {

    }

    public void Exit()
    {

    }
   
}
