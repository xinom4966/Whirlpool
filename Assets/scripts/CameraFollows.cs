using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollows : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private float speed;
    void Start()
    {
        player = PlayerMovement.instance;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, player.GetTransform().position.y, Time.deltaTime * speed), transform.position.z);
    }
}
