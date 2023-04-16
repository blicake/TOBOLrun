using System.IO;
using TMPro;
using UnityEngine;

public class MainMenuData : MonoBehaviour
{
    private TMP_Text text;
    public static bool update;
    void Start()
    {
        text = GetComponent<TMP_Text>();
        update = true;
    }
    private void Update()
    {
        if (update)
        {
            string jsonContainer = File.ReadAllText("Assets/jsonContainer.json");
            ContainerClass.SettingsContainer myCoins = JsonUtility.FromJson<ContainerClass.SettingsContainer>(jsonContainer);
            if (tag == "score") text.text = myCoins.highscore.ToString();
            else text.text = myCoins.currentCoins.ToString();
            update = false;
        }
    }
}
