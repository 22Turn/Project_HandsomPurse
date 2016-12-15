using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class P_GetTag : MonoBehaviour
{
    static public P_GetTag pGetTag = null;
    public List<GameObject> pGObjTag = new List<GameObject>();

    int iStartX = -392;
    int iStartY = 72;

    void Awake()
    {
        pGetTag = this;
    }

    void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        int iNextX = iStartX;

        for (int i = 0; i < PlayerData.iTagCount; i++)
        {
            GameObject tempGObj = UITool.pthis.CreateUI(gameObject, "Prefab/G_TagType");

            G_TagType pTagType = tempGObj.GetComponent<G_TagType>();

            if (i < PlayerData.strTag.Length)
            {
                pTagType.SetName(PlayerData.strTag[i]);
                tempGObj.transform.localPosition = new Vector2(iNextX, iStartY + (i/4) * 5);
            }
            pGObjTag.Add(tempGObj);

            iNextX += pTagType.GetWidth() + 10;
        }
    }
}
