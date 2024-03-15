using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

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
    public static PlayerMovement instance;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        if (healthPoints <= 0f )
        {
            GameOver();
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
                rb.AddForce(new Vector2(0f, jumpForce));
            }
            else
            {
                Shoot();
                if (rb.velocity.y < -0.5f)
                {
                    rb.velocity = new Vector3(rb.velocity.x, -0.5f, rb.velocity.z);
                }
                rb.velocity += Vector3.up * 0.25f;
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
        Destroy(gameObject);
    }
}
