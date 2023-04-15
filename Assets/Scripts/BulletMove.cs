using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.position += transform.TransformDirection(Vector3.forward*speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player._death = true;
        }
    }
}
