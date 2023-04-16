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
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        ContainerClass.SettingsContainer myCoins = JsonUtility.FromJson<ContainerClass.SettingsContainer>(jsonContainer);
        if(myCoins.currentCoins >= speedCost)
        {
            myCoins.bonusSpeed++;
            myCoins.currentCoins -= speedCost;
            BonusCount.update = true;
            MainMenuData.update = true;
            jsonContainer = JsonUtility.ToJson(myCoins);
            File.WriteAllText("Assets/jsonContainer.json", jsonContainer);
        }
    }
    public void BuyHorse()
    {
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        ContainerClass.SettingsContainer myCoins = JsonUtility.FromJson<ContainerClass.SettingsContainer>(jsonContainer);
        if (myCoins.currentCoins >= speedCost)
        {
            myCoins.bonusHorse++;
            myCoins.currentCoins -= horseCost;
            BonusCount.update = true;
            MainMenuData.update = true;
            jsonContainer = JsonUtility.ToJson(myCoins);
            File.WriteAllText("Assets/jsonContainer.json", jsonContainer);
        }
        
    }
}
