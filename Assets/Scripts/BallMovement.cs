using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BallMovement : NetworkBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody rb;
    [SyncVar] public int playerNumber;

    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
            return;

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    public override void OnStartLocalPlayer()
    {
        GetComponent<Renderer>().material.color = Color.green;

        base.OnStartLocalPlayer();

        if (isServer)
            playerNumber = 1;
        else
            playerNumber = 0;
    }
}

