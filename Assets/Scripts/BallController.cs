using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class BallController : MonoBehaviourPunCallbacks
{
    public GameObject head;
    public bool isHeld = false;

    void Start()
    {
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), head.GetComponent<Collider2D>());
        
    }

    void StickToParent() {
        if (transform.parent != null) {
            transform.localPosition = Vector3.zero;
            isHeld = true;
        }
    }

    private void Update() {
        if(photonView.IsMine) StickToParent();
    }

}
