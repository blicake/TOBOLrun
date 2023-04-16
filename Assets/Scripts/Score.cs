using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private TMP_Text score;
    void Start()
    {
        score = GetComponent<TMP_Text>();
        score.text = "0";
    }
    void Update()
    {
        score.text = Player._score.ToString();
    }
}
