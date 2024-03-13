using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetBox : MonoBehaviour
{
    private PlayerMovement player;

    private void Start()
    {
        player = PlayerMovement.instance;
    }

    private void OnTriggerEnter(Collider other)
    {
        player.SetGround(true);
    }

    private void OnTriggerExit(Collider other)
    {
        player.SetGround(false);
    }
}
