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
            Debug.Log(PlayerPrefs.GetInt("coins"));
            if (tag == "score") text.text = PlayerPrefs.GetInt("highscore").ToString();
            else text.text = PlayerPrefs.GetInt("coins").ToString();
            update = false;
        }
    }
}
