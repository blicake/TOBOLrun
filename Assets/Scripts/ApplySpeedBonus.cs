using TMPro;
using System.IO;
using UnityEngine;

public class ApplySpeedBonus : MonoBehaviour
{
    [SerializeField] TMP_Text count;
    public void Apply()
    {
        PlayerPrefs.GetInt("bonusSpeed");
        int countBonus = PlayerPrefs.GetInt("bonusSpeed") - 1;
        if (PlayerPrefs.GetInt("bonusSpeed") > countBonus)
        {
            PlayerPrefs.SetInt("speedApplied", 1);
            count.text = countBonus.ToString();
        }
        PlayerPrefs.Save();
    }
}
