using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioListener sounds;

    public static bool state;

    public void ChangeSoundsState()
    {
        if (state)
        {
            state = false;
            sounds.enabled = false;
        }
        else
        {
            state = true;
            sounds.enabled = true;
        }
    }
}
