using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    private int coinAmount;
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinAmount = Scriptable.GameData().totalMoneyAmount;
        coinText.text = coinAmount.ToString();
    }

    private void OnEnable()
    {
        EventManager.EarnMoney += EarnMoney;
    }

    private void EarnMoney(ObjectTypes obj)
    {
        foreach (var data in Scriptable.ObjectsData().objectDatasList)
        {
            if (data.type==obj)
            {
                coinAmount += data.point*3;
                coinText.text = coinAmount.ToString();
                Scriptable.GameData().totalMoneyAmount = coinAmount;
                SaveManager.SaveGameData(Scriptable.GameData());
            }
        }
    }
}
