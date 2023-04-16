using System.IO;
using UnityEngine;

public class CreateFile : MonoBehaviour
{
    void Start()
    {
        string saveFile = Application.persistentDataPath + "/jsonContainer.json";
        if (File.Exists(saveFile))
        {
            ContainerClass.SettingsContainer myCoins = new();
            string json = JsonUtility.ToJson(myCoins);
            File.WriteAllText(saveFile, json);
        }
        
    }
}
