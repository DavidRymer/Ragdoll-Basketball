using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stability : MonoBehaviour
{

    public GameObject head;

    void Stabilise() {
        if (head.transform.position.y < 3) head.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 25));
    }

    private void Update() {
        Stabilise();
    }

}
