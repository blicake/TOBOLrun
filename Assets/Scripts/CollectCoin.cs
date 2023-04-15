using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, 1.5f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            if (!(tag == "big")) Player._coins++;
            else Player._coins += 10;
            Coins.update = true;
            Destroy(gameObject);
        }
    }
}
