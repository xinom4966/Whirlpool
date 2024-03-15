using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float radius;
    private bool hasTarget = false;
    private Transform target;
    private int layerMask;

    private void Start()
    {
        layerMask = 1<<6;
    }
    void Update()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
        if (colliders.Length > 0)
        {
            hasTarget = true;
            target = colliders[0].transform;
        }
        if (hasTarget)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
