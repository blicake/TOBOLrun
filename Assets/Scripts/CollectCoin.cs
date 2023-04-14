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
            Player._coins++;
            Coins.update = true;
            Destroy(gameObject);
        }
    }
}
