using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    private Animator animator;
    private Rigidbody rigidbody;
    private bool stopped;
    private void Start()
    {
        stopped = false;
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Player._pause)
        {
            rigidbody.isKinematic = true;
            animator.enabled = false;
            stopped = true;
        }
        if (stopped && !Player._pause)
        {
            rigidbody.isKinematic = false;
            animator.enabled = true;
            stopped = false;
        }
        if (transform.position.x < -1.4f) transform.position = new Vector3(-1.4f, transform.position.y, transform.position.z);
        if (transform.position.x > 1.4f) transform.position = new Vector3(1.4f, transform.position.y, transform.position.z);
        if (transform.position.y < 0.15f) transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
        rigidbody.velocity = new Vector3(0f, 0f, speed);
        animator.SetFloat("Direction", joystick.Horizontal);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
            StartCoroutine("Jumping");
        }
    }

    IEnumerator Jumping()
    {
        float time = 0f;
        while(time < 0.35f)
        {
            rigidbody.velocity = new Vector3(0f, speed*3, 0f);
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
        }
        while (time < 0.7f)
        {
            rigidbody.velocity = new Vector3(0f, - speed*3, 0f);
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
        }
        rigidbody.velocity = new Vector3(0f, 0f, 0f);
    }
}
