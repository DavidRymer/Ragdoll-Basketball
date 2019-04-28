using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
public class PlayerMovement : MonoBehaviourPunCallbacks
{
    private Rigidbody rb;
    public int speed = 2;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        if (photonView.IsMine)
        {
            if (Input.GetKey(KeyCode.A)) rb.velocity = Vector3.left * speed;
            if (Input.GetKey(KeyCode.D)) rb.velocity = Vector3.right * speed;
        }

    }
}
