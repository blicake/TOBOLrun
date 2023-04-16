using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BuyBonus : MonoBehaviour
{
    public int speedCost;
    public int horseCost;
    public void BuySpeed()
    {
        int bonus = PlayerPrefs.GetInt("bonusSpeed");
        int coins = PlayerPrefs.GetInt("coins");
        if (coins >= speedCost)
        {
            PlayerPrefs.SetInt("bonusSpeed", bonus + 1);
            coins -= speedCost;
            PlayerPrefs.SetInt("coins", coins);
            BonusCount.update = true;
            MainMenuData.update = true;
        }
        PlayerPrefs.Save();
    }
    public void BuyHorse()
    {
        int bonus = PlayerPrefs.GetInt("bonusHorse");
        int coins = PlayerPrefs.GetInt("coins");
        if (coins >= speedCost)
        {
            PlayerPrefs.SetInt("bonusHorse", bonus + 1);
            coins -= speedCost;
            PlayerPrefs.SetInt("coins", coins);
            BonusCount.update = true;
            MainMenuData.update = true;
        }
        PlayerPrefs.Save();
    }
}
