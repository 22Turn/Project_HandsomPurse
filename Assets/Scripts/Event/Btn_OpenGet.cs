using UnityEngine;
using System.Collections;

public class Btn_OpenGet : MonoBehaviour
{
    public GameObject Obj_PageGet;
    public GameObject Obj_PageIndex;

    void OnClick()
    {
        Obj_PageGet.SetActive(true);
        Obj_PageIndex.SetActive(false);
    }
}
