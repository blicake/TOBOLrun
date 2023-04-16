using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
    private bool opened;
    private void Start()
    {
        opened = false;
    }
    public void OpenMenu()
    {
        if (opened)
        {
            audioSource.PlayOneShot(clickSound);
            SettingsMenu.SetActive(false);
            opened = false;
            Player._pause = false;
        }
        else
        {
            audioSource.PlayOneShot(clickSound);
            SettingsMenu.SetActive(true);
            opened = true;
            Player._pause = true;
        }
    }
}
