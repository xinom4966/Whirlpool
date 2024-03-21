using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Collider groundCheck;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawner;
    [SerializeField] private float healthPoints;
    private bool isGrounded;
    private Vector2 moveInput;
    public int ammoNum;
    public int ammoReset;
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        ammoNum = 8;
        ammoReset = ammoNum;
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        if (healthPoints <= 0f )
        {
            GameOver();
        }
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y <= -20f)
        {
            rb.velocity = new Vector2(rb.velocity.x, -20f);
        }
    }
    public void OnMovementEnter(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnActionEnter(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                ammoNum = ammoReset;
                rb.AddForce(new Vector2(0f, jumpForce));
            }
            else
            {
                if (ammoNum > 0)
                {
                    Shoot();
                    ammoNum--;
                    if (rb.velocity.y < -0.5f)
                    {
                        rb.velocity = new Vector3(rb.velocity.x, -0.5f, rb.velocity.z);
                    }
                    rb.velocity += Vector3.up * 0.25f;
                }
            }
        }
    }

    public void SetGround(bool value)
    {
        isGrounded = value;
    }

    private void Shoot()
    {
        GameObject.Instantiate(bulletPrefab, bulletSpawner);
    }

    public void Bounce(float bounce)
    {
        rb.velocity += Vector3.up * bounce;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            healthPoints--;
        }
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void AddHP(int value)
    {
        healthPoints += value;
    }
}
