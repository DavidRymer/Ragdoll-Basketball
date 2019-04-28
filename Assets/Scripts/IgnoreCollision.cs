using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    private void Start() {
        var collider = GetComponent<Collider2D>();

        Physics2D.IgnoreCollision(collider, GetColliderInPlayer("Head"));
        Physics2D.IgnoreCollision(collider, GetColliderInPlayer("Torso"));
        Physics2D.IgnoreCollision(collider, GetColliderInPlayer("RightLeg"));
        Physics2D.IgnoreCollision(collider, GetColliderInPlayer("LeftLeg"));

        if (transform.name == "LeftArm") Physics2D.IgnoreCollision(collider, GetColliderInPlayer("RightArm"));
        else Physics2D.IgnoreCollision(collider, GetColliderInPlayer("LeftArm"));

    }

    Collider2D GetColliderInPlayer(string transformName) => transform.parent.Find(transformName).GetComponent<Collider2D>();

}
