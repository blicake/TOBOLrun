using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float horizontalMoveSpeed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip startSound;
    private Animator animator;
    public Rigidbody rb;
    private bool stopped;
    private bool jumped;
    private CapsuleCollider _collider;
    private void Start()
    {
        audioSource.PlayOneShot(startSound);
        _collider = GetComponent<CapsuleCollider>();
        StartCoroutine("IncreaseSpeed");
        jumped = false;
        rb.isKinematic = false;
        stopped = false;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (!Player._pause && Player._speedBonus == 0)
        {
            if (transform.position.x < -1.2f)
            {
                Debug.Log(joystick.Horizontal);
                if (joystick.Horizontal > 0) rb.velocity = new Vector3(joystick.Horizontal * horizontalMoveSpeed, 0, speed);
                else rb.velocity = new Vector3(0, 0, speed);
            }
            else if(transform.position.x > 1.2f)
            {
                Debug.Log(joystick.Horizontal);
                if (joystick.Horizontal < 0) rb.velocity = new Vector3(joystick.Horizontal * horizontalMoveSpeed, 0, speed);
                else rb.velocity = new Vector3(0, 0, speed);
            }
            else rb.velocity = new Vector3(joystick.Horizontal * horizontalMoveSpeed, 0, speed);

        }

        if (Player._speedBonus == 1)
        {
            if(transform.position.z < 100)
            {
                rb.velocity = new Vector3(0, 0, speed * 5);
                
                _collider.enabled = false;
            }
            else
            {
                Player._speedBonus = 0;
                _collider.enabled = true;
            }
        }

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
        if (transform.position.y < 0.15f) transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
        animator.SetFloat("Direction", joystick.Horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && !jumped)
        {
            jumped = true;
            animator.SetTrigger("Jump");
            StartCoroutine("Jumping");
        }
    }
    IEnumerator IncreaseSpeed()
    {
        while (speed < 15f)
        {
            yield return new WaitForSeconds(4f);
            speed *= 1.05f;
        }
    }

    IEnumerator Jumping()
    {
        while(transform.position.y < 1.2f)
        {
            rb.velocity = new Vector3(0f, 5f, speed*1.2f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        audioSource.PlayOneShot(jumpSound);
        while (transform.position.y > 0.15f)
        {
            rb.velocity = new Vector3(0f, - 4f, speed*1.2f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        rb.velocity = new Vector3(0f, 0f, speed);
        jumped = false;
    }
}
