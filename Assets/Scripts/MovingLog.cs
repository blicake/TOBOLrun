using TMPro;
using UnityEngine;

public class MovingLog : MonoBehaviour
{
    [SerializeField] GameObject LoseMenu;
    public float speed;
    private void Update()
    {
        if (!Player._pause && CompareTag("moving"))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - speed);
            transform.Rotate(0, 0, 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Player._death = true;
        }
    }
}
