using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] AudioListener sounds;

    public static int state;

    public void ChangeSoundsState()
    {
        if (state == 1)
        {
            state = 0;
            sounds.enabled = true;
        }
        else
        {
            state = 1;
            sounds.enabled = false;
        }
    }
}
