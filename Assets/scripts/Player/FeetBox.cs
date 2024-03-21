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
        if (other.CompareTag("Ground"))
        {
            player.SetGround(true);
        }
        else if (other.CompareTag("Enemy"))
        {
            player.AddHP(1);
            player.ammoNum = player.ammoReset;
            player.Bounce(15f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player.SetGround(false);
    }
}
