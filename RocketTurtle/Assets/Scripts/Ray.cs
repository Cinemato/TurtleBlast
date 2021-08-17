using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray : MonoBehaviour
{
    public int timesHit = 0;

    private void Update()
    {
        if (timesHit >= 3)
        {
            Destroy(gameObject);
        }
    }

    public void plusHit()
    {
        timesHit++;
    }
}
