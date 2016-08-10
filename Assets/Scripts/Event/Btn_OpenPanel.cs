using UnityEngine;
using System.Collections;

public class Btn_OpenPanel : MonoBehaviour
{
    public ENUM_Page TargetPage = ENUM_Page.Main;
    public string PanelName = null;
    void OnClick()
    {
        UITool.pthis.CreatePanel(PanelName);
        SysMain.Now_Page = TargetPage;
    }
}
