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
                P_Calculator.pthis.PerformOperation();
                break;
            case "AC":
                P_Calculator.pthis.ClearCalcData();
                break;
            case "C":
                P_Calculator.pthis.delendNumber();
                break;
            default:
                P_Calculator.pthis.AddendNumber(sType);
                break;
        }
    }
}
