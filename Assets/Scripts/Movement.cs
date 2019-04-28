using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Movement : MonoBehaviourPunCallbacks
{

    public GameObject leftArm;
    public GameObject rightArm;

    private Rigidbody2D _torsoRigidBody2D;

    private void Start()
    {
        _torsoRigidBody2D = transform.Find("Torso").GetComponent<Rigidbody2D>();
    }



    void Move()
    {
        if (Input.GetKey(KeyCode.A)) _torsoRigidBody2D.AddForce(new Vector3(-10, 0, 0));
        if (Input.GetKey(KeyCode.D)) _torsoRigidBody2D.AddForce(new Vector3(10, 0, 0));
    }

    Rigidbody2D GetLimbRigidBody(GameObject limb)
    {
        return limb.transform.GetComponent<Rigidbody2D>();
    }

    void PointArmsToPoint(Vector3 forceDirection)
    {
        var leftArmTransform = leftArm.transform;
        var rightArmTransform = rightArm.transform;

        GetLimbRigidBody(leftArm).AddForceAtPosition(forceDirection, leftArmTransform.Find("LeftHand").position);
        GetLimbRigidBody(rightArm).AddForceAtPosition(forceDirection, rightArmTransform.Find("RightHand").position);
        GetLimbRigidBody(leftArm).AddForceAtPosition(-forceDirection, leftArmTransform.Find("LeftArmPivot").position);
        GetLimbRigidBody(rightArm).AddForceAtPosition(-forceDirection, rightArmTransform.Find("RightArmPivot").position);
    }

    void Update()
    {
        if (photonView.IsMine)
        {
            Move();
            if (Input.GetKey(KeyCode.Mouse0)) PointArmsToPoint(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }

    }
}
