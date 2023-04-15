using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    private Animator animator;
    public Rigidbody rb;
    private bool stopped;
    private bool jumped;
    private void Start()
    {
        jumped = false;
        rb.isKinematic = false;
        stopped = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!Player._pause) rb.velocity = new Vector3(0, 0, speed);
        if (Player._pause)
        {
            rb.isKinematic = true;
            animator.enabled = false;
            stopped = true;
        }
        if (stopped && !Player._pause)
        {
            rb.isKinematic = false;
            animator.enabled = true;
            stopped = false;
        }
        if (transform.position.x < -1.4f) transform.position = new Vector3(-1.4f, transform.position.y, transform.position.z);
        if (transform.position.x > 1.4f) transform.position = new Vector3(1.4f, transform.position.y, transform.position.z);
        if (transform.position.y < 0.15f) transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
        animator.SetFloat("Direction", joystick.Horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            jumped = true;
            animator.SetTrigger("Jump");
            StartCoroutine("Jumping");
        }
    }

    IEnumerator Jumping()
    {
        while(transform.position.y < 1.2f)
        {
            rb.velocity = new Vector3(0f, 5f, speed*1.2f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        while (transform.position.y > 0.15f)
        {
            rb.velocity = new Vector3(0f, - 4f, speed*1.2f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        rb.velocity = new Vector3(0f, 0f, speed);
        jumped = false;
    }
}
