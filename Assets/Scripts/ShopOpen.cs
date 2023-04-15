using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopOpen : MonoBehaviour
{
    [SerializeField] GameObject Shop;
    [SerializeField] GameObject Menu;
    public void Open()
    {
        Shop.SetActive(true);
        Menu.SetActive(false);
    }
    public void Close()
    {
        Shop.SetActive(false);
        Menu.SetActive(true);
    }
}
