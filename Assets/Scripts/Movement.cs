using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private FloatingJoystick joystick;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float horizontalMoveSpeed;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip jumpSound;
    private Animator animator;
    public Rigidbody rb;
    private bool stopped;
    private bool jumped;
    private CapsuleCollider _collider;
    private void Start()
    {
        _collider = GetComponent<CapsuleCollider>();
        if (Player._speedBonus == 1) StartCoroutine("SpeedStart");
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
        if (Player._pause)
        {
            audioSource.mute = true;
            rb.isKinematic = true;
            animator.enabled = false;
            stopped = true;
        }
        if (stopped && !Player._pause)
        {
            audioSource.mute = false;
            rb.isKinematic = false;
            animator.enabled = true;
            stopped = false;
        }
        if (transform.position.y < 0.15f) transform.position = new Vector3(transform.position.x, 0.15f, transform.position.z);
        animator.SetFloat("Direction", joystick.Horizontal);
        if (Input.GetKeyDown(KeyCode.Space) && !jumped && Player._speedBonus == 0)
        {
            jumped = true;
            animator.SetTrigger("Jump");
            StartCoroutine("Jumping");
        }
    }

    IEnumerator SpeedStart()
    {
        _collider.enabled = false;
        while (transform.position.z < 100)
        {
            rb.velocity = new Vector3(0, 0, speed * 5);
            yield return new WaitForSeconds(0.1f);
        }
        Player._speedBonus = 0;
        _collider.enabled = true;
    }
    IEnumerator IncreaseSpeed()
    {
        while (speed < 25f)
        {
            yield return new WaitForSeconds(4f);
            speed *= 1.05f;
        }
    }

    IEnumerator Jumping()
    {
        while(transform.position.y < 1.2f)
        {
            rb.AddForce(Vector3.up * jumpSpeed);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        audioSource.PlayOneShot(jumpSound);
        while (transform.position.y > 0.15f)
        {
            rb.AddForce(Vector3.up * -jumpSpeed * 0.5f);
            yield return new WaitForSeconds(Time.deltaTime);
        }
        rb.velocity = new Vector3(0f, 0f, speed);
        jumped = false;
    }
}
