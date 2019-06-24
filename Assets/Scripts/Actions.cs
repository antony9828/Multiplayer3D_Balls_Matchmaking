using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var playerNumber = other.GetComponent<BallMovement>().playerNumber;
        if (playerNumber == 1)
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}
