using UnityEngine;
using System.Collections;

public class SysMain : MonoBehaviour
{
    public static ENUM_Page Now_Page = ENUM_Page.Main;

    public static double dTempNumber = 0;
    // Use this for initialization
	void Start ()
    {
	}

    public static void SetTempNumber(double dNum)
    {
        dTempNumber = dNum;
    }
}
