using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkierController : MonoBehaviour {

    public float moveSpeed = 6.0f;
    public float moveSpeedNoFriction = 0.05f;
    public float airSpeed = 0.5f;
    public float jumpSpeed = 80.0f;

    public PhysicMaterial slick;
    public PhysicMaterial normal;

    private CapsuleCollider characterCollider;
    private Rigidbody rb;
    private int inTrigger = 0;
    private bool noFriction = false;

    // Use this for initialization
    void Start () {
        characterCollider = GetComponent<CapsuleCollider> ();
        rb = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update () {
        if (isGrounded ()) {
            noFriction = Input.GetButton ("Fire3");
        }

        float speed = noFriction
            ? moveSpeedNoFriction
            : moveSpeed;

        if (noFriction) {
            characterCollider.material = slick;
        } else {
            characterCollider.material = normal;
        }

        Vector3 moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
        moveDirection = transform.TransformDirection (moveDirection);
        moveDirection *= speed;

        if (noFriction) {
            moveDirection += rb.velocity;
        }

        moveDirection.y = rb.velocity.y;
        if (isGrounded()) {
            if (Input.GetButton ("Jump")) {
                moveDirection.y = jumpSpeed;
            }
        }
            
        rb.velocity = moveDirection;

    }

    void OnTriggerEnter(Collider other) {
        inTrigger++;
    }

    void OnTriggerExit(Collider other) {
        inTrigger--;
    }

    private bool isGrounded() {
        return inTrigger > 0;
    }
}
