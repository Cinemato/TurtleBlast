using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTip : MonoBehaviour
{
    [SerializeField] bool isUsed = true;

    public bool getIsUsed()
    {
        return isUsed;
    }

    public void setIsUsed(bool boolean)
    {
        isUsed = boolean;
    }
}
