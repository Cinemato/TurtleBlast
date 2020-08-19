using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] GameObject player;

    public void respawn()
    {
        PlayerStats.instance.respawn();
    }
}
