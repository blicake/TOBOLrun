using System.IO;
using TMPro;
using UnityEngine;

public class MainMenuScore : MonoBehaviour
{
    private TMP_Text highscore;
    public class SettingsContainer
    {
        public int currentCoins;
        public int highscore;
        public bool soundSwitch;
    }
    void Start()
    {
        highscore = GetComponent<TMP_Text>();
        string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
        SettingsContainer myCoins = JsonUtility.FromJson<SettingsContainer>(jsonContainer);
        highscore.text = myCoins.highscore.ToString();
    }
}
