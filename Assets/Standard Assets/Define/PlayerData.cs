using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    public static float fMoney = 0;

    // ------------------------------------------------------------------
    public static float GetMoney()
    {
        return fMoney;
    }
    // ------------------------------------------------------------------
    public static bool AddMoney(float fValue)
    {
        fMoney = fMoney + fValue;
        return true;
    }
}
