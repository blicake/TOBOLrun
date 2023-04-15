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
    private void Start()
    {
        rb.isKinematic = false;
        stopped = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!Player._pause) transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + speed*0.04f);
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
            rb.velocity = new Vector3(0f, speed*3, 0f);
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
        }
        while (time < 0.7f)
        {
            rb.velocity = new Vector3(0f, - speed*3, 0f);
            yield return new WaitForSeconds(Time.deltaTime);
            time += Time.deltaTime;
        }
        rb.velocity = new Vector3(0f, 0f, 0f);
    }
}
