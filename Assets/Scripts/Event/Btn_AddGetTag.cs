using UnityEngine;
using System.Collections;

public class Btn_AddGetTag : MonoBehaviour
{
    public UIInput pInput = null;

	void OnClick()
    {
        PlayerData.AddTag(pInput.value);
        Destroy(gameObject.transform.parent.gameObject);
    }
}
