using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float healthPoint;
    [SerializeField] private bool isStompable;

    private void Update()
    {
        if (healthPoint <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Stomp"))
        {
            if (isStompable)
            {
                Destroy(gameObject);
            }
        }
        else if (other.CompareTag("Bullet"))
        {
            healthPoint--;
        }
    }
}
