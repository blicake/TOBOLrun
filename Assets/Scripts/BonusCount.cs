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
        if(tag == "speed")
        {
            bonusCount.text = PlayerPrefs.GetInt("bonusSpeed").ToString();
        }
        if (tag == "horse")
        {
            bonusCount.text = PlayerPrefs.GetInt("bonusHorse").ToString();
        }
        update = false;
    }
}
