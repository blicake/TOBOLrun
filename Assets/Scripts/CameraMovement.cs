using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static Vector3 offset;

    [SerializeField] private GameObject player;

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }

    private void Update()
    {
        transform.position = new Vector3(
                                            transform.position.x + (player.transform.position.x - transform.position.x),
                                            0.15f + offset.y,
                                            player.transform.position.z + offset.z
                                         );
    }
}
