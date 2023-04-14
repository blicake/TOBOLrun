using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] TMP_Text coins;

    public static bool update;

    private void Start()
    {
        coins.text = Player._coins.ToString();
        update = false;
    }
    private void Update()
    {
        if (update)
        {
            update = false;
            coins.text = Player._coins.ToString();
        }
    }
}
