using TMPro;
using System.IO;
using UnityEngine;

public class ApplySpeedBonus : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    public void Apply()
    {
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        ContainerClass.SettingsContainer myCoins = JsonUtility.FromJson<ContainerClass.SettingsContainer>(jsonContainer);
        int countBonus = myCoins.bonusSpeed - 1;
        if (myCoins.bonusSpeed > countBonus)
        {
            myCoins.speedApplied = true;
            count.text = countBonus.ToString();
            jsonContainer = JsonUtility.ToJson(myCoins);
            File.WriteAllText("Assets/jsonContainer.json", jsonContainer);
        }
    }
}
