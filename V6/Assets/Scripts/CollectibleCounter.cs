using System;
using UnityEngine;

public class CollectibleCounter : MonoBehaviour
{
    public int counter;

    public void IncreaseCounter()
    {
        counter++;
    }
    public void Load()
    {
        counter = SaveData.instance.collectiblesCount;
    }

    public void Save()
    {
        SaveData.instance.collectiblesCount = counter;
    }

    
}