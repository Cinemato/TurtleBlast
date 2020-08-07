using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] bool hasShellOn = false;
    [SerializeField] int numberOfWeapons = 1;

    public bool getHasShellOn()
    {
        return hasShellOn;
    }

    public int getNumberOfWeapons()
    {
        return numberOfWeapons;
    }

    public void incrementWeapons()
    {
        if(numberOfWeapons < 3)
            numberOfWeapons++;
    }
}
