using System;
using System.IO;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    [SerializeField] GameObject WinMenu;

    
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player._win = true;
        }
    }
}
