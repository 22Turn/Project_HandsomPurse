using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour {

    static public PlayerData pthis = null;

    public int iMoney = 0;
    public int iSoul = 0;
    public int iPrestige = 0;
    public int iPetCount = 0;

    public PetData[] pPet = null;
    public List<MissionData> pMission = new List<MissionData>();
    // ------------------------------------------------------------------
    void Awake()
    {
        pthis = this;
    }
}
