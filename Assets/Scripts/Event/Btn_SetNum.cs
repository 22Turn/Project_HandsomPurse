using UnityEngine;
using System.Collections;

public class Btn_SetNum : MonoBehaviour
{
    public string sType = "";

    void OnClick()
    {
        switch(sType)
        {
            case "+":
                P_Calculator.pthis.OperatorPressed("+");
                break;
            case "-":
                P_Calculator.pthis.OperatorPressed("-");
                break;
            case "/":
                P_Calculator.pthis.OperatorPressed("/");
                break;
            case "x":
                P_Calculator.pthis.OperatorPressed("x");
                break;
            case "=":
                break;
            case "C":
                P_Calculator.pthis.ClearCalcData();
                break;
            default:
                P_Calculator.pthis.AddendNumber(sType);
                break;
        }
        /*
        if (GUI.Button(new Rect(61, 70, 47, 30), "+/-"))
        {
            if (currentNumber != "0")
            {
                if (currentNumber[0] != '-')
                    currentNumber = currentNumber.Insert(0, "-");
                else
                    currentNumber = currentNumber.Remove(0, 1);
            }
        }*/
    }
}
