using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioListener sounds;

    public static int state;

    private void Start()
    {
        state = PlayerPrefs.GetInt("sounds");
    }

    public void ChangeSoundsState()
    {
        if (state == 1)
        {
            state = 0;
            sounds.enabled = false;
            PlayerPrefs.SetInt("sounds", 0);
        }
        else
        {
            state = 1;
            sounds.enabled = true;
            PlayerPrefs.SetInt("sounds", 1);
        }
    }
}
