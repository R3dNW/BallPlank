using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    new Rigidbody rigidbody;

    public float sensitivity;
    public float jumpAmount;

    void Start()
    {
        this.rigidbody = this.GetComponent<Rigidbody>();
    }

    bool doubleJumpAllowed = true;

    private void FixedUpdate()
    {
        bool touchingGround = GetTouchingGround();

        this.rigidbody.AddForce(
            new Vector3(
                Input.GetAxis("Horizontal") * sensitivity,
                0,
                0
            ));

        if (touchingGround)
        {
            doubleJumpAllowed = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitInfo;

            if (touchingGround)
            {
                this.rigidbody.AddForce(
                    new Vector3(
                        0,
                        jumpAmount,
                        0
                    ));
            }
            else if (doubleJumpAllowed)
            {
                this.rigidbody.AddForce(
                    new Vector3(
                        0,
                        jumpAmount,
                        0
                    ));

                doubleJumpAllowed = false;
            }
        }
    }

    private bool GetTouchingGround()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(this.transform.position, Vector3.down, out hitInfo))
        {
            if (hitInfo.distance < 0.6f)
            {
                return true;
            }
        }

        return false;
    }
}
