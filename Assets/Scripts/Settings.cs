using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    private bool opened;
    private void Start()
    {
        opened = false;
    }
    public void OpenMenu()
    {
        if (opened)
        {
            SettingsMenu.SetActive(false);
            opened = false;
        }
        else
        {
            SettingsMenu.SetActive(true);
            opened = true;
        }
    }
}
