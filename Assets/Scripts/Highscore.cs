using TMPro;
using UnityEngine;

public class Highscore : MonoBehaviour
{
    private TMP_Text highscore;
    void Start()
    {
        highscore = GetComponent<TMP_Text>();
        highscore.text = Player._highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player._death) highscore.text = Player._highscore.ToString();
    }
}
