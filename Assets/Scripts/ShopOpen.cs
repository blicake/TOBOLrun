using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Menu;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSound;
    public void Open()
    {
        audioSource.PlayOneShot(clickSound);
        Shop.SetActive(true);
        Menu.SetActive(false);
    }
    public void Close()
    {
        audioSource.PlayOneShot(clickSound);
        Shop.SetActive(false);
        Menu.SetActive(true);
    }
}
