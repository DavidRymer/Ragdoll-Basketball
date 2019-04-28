using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Grab : MonoBehaviourPunCallbacks
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other + "  fddddd  ");

        if (other.name == "Ball(Clone)" && Input.GetKey(KeyCode.Mouse0) && photonView.IsMine)
        {
            var isHeld = other.GetComponent<BallController>().isHeld;
            if (!isHeld) other.transform.SetParent(transform);
        }
    }

    void Throw()
    {

        var ball = transform.Find("Ball(Clone)");

        if (ball != null && !Input.GetKey(KeyCode.Mouse0))
        {
            ball.parent = null;
            ball.GetComponent<Rigidbody2D>().AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position) * 60);
            ball.GetComponent<BallController>().isHeld = false;
        }

    }



    void Update()
    {
        if (photonView.IsMine) Throw();
    }

}
