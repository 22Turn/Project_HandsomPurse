using UnityEngine;
using System.Collections;

public class Btn_AddGetTag : MonoBehaviour
{
    public UIInput pInput = null;

	void OnClick()
    {
        PlayerData.AddTag(pInput.value, (int)SysMain.Now_Page);

        if (P_GetTag.pGetTag != null)
            P_GetTag.pGetTag.Refresh();

        Destroy(gameObject.transform.parent.gameObject);
    }
}
