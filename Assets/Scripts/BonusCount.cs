using System.IO;
using TMPro;
using UnityEngine;

public class BonusCount : MonoBehaviour
{
    private TMP_Text bonusCount;
    public static bool update;
    void Start()
    {
        bonusCount = GetComponent<TMP_Text>();
        update = true;
    }
    void Update()
    {
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        ContainerClass.SettingsContainer myCoins = JsonUtility.FromJson<ContainerClass.SettingsContainer>(jsonContainer);
        if(tag == "speed")
        {
            bonusCount.text = myCoins.bonusSpeed.ToString();
        }
        if (tag == "horse")
        {
            bonusCount.text = myCoins.bonusHorse.ToString();
        }
        update = false;
    }
}
