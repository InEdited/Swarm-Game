using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMovement : MonoBehaviour
{
    public float moveSpeed;
    public GameObject left;
    bool wallAttached = false;
    bool ceilAttached = false;
    public GameObject right;

    bool directionRight = true;
    bool directionUp = true;

    private Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!wallAttached) {
            float input = Input.GetAxis("Horizontal");
            rigidbody.velocity = new Vector2(input * moveSpeed, rigidbody.velocity.y);

            if ((input > 0 && !directionRight) || (input < 0 && directionRight))
            {
                FlipDirection();
            }
        }

        if (wallAttached) {
            float input = Input.GetAxis("Vertical");
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, input * moveSpeed);

            if (input > 0 && !directionUp || input < 0 && directionUp) {
                FlipDirection();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && (wallAttached || Mathf.Abs(rigidbody.rotation % 360) == 180)) {
            letItGo();
        }
        
    }

    void FlipDirection() {
        GetComponent<SpriteRenderer>().flipX = !GetComponent<SpriteRenderer>().flipX;
        directionRight = !directionRight;
        directionUp = !directionUp;
    }

    void Update() {
        float hor_input = Input.GetAxis("Horizontal");
        float ver_input = Input.GetAxis("Vertical");
        bool left_climb = false;
        bool right_climb = false;

        if (Physics2D.OverlapPoint(left.transform.position)) {
            switch (Mathf.Abs(rigidbody.rotation % 360))
            {
                case 0:
                    if (!directionRight && hor_input < 0)
                        left_climb = true;
                    break;
                case 180:
                    if(directionRight && hor_input > 0) {
                        left_climb = true;
                    }
                    break;
                case 90:
                    if(directionUp && ver_input > 0)
                        left_climb = true;
                    break;
                case 270:
                    if(!directionUp && ver_input < 0) {
                        left_climb = true;
                    }
                    break;
            }
        } else if (Physics2D.OverlapPoint(right.transform.position)) {
            switch (Mathf.Abs(rigidbody.rotation % 360))
            {
                case 0:
                    if (directionRight && hor_input > 0)
                        right_climb = true;
                    break;
                case 180:
                    if(!directionRight && hor_input < 0) {
                        right_climb = true;
                    }
                    break;
                case 90:
                    if(!directionUp && ver_input < 0)
                        right_climb = true;
                    break;
                case 270:
                    if(directionUp && ver_input > 0) {
                        right_climb = true;
                    }
                    break;
            }
        }

        if (left_climb)
            climbLeftWall();
        else if (right_climb)
            climbRightWall();
    }

    void letItGo() {
        rigidbody.rotation = 0;
        wallAttached = false;
        directionRight = true;
        rigidbody.gravityScale = 1;
    }

    void climbLeftWall() {
        rigidbody.rotation -= 90;
        switch(Mathf.Abs(rigidbody.rotation % 360)) {
            case 0:
                wallAttached = false;
                directionRight = false;
                rigidbody.gravityScale = 1;
                break;
            case 180:
                wallAttached = false;
                directionRight = true;
                rigidbody.gravityScale = -1;
                break;
            case 90:
                wallAttached = true;
                directionUp = true;
                rigidbody.gravityScale = 0f;
                break;
            case 270:
                wallAttached = true;
                directionUp = false;
                rigidbody.gravityScale = 0f;
                break;
        }
    }

    void climbRightWall() {
        rigidbody.rotation += 90;
        if (rigidbody.rotation > 0) {
            rigidbody.rotation -= 360;
        }
        switch(Mathf.Abs(rigidbody.rotation % 360)) {
            case 0:
                wallAttached = false;
                directionRight = false;
                rigidbody.gravityScale = 1;
                break;
            case 180:
                wallAttached = false;
                directionRight = true;
                rigidbody.gravityScale = -1;
                break;
            case 90:
                wallAttached = true;
                directionUp = true;
                rigidbody.gravityScale = 0;
                break;
            case 270:
                wallAttached = true;
                directionUp = false;
                rigidbody.gravityScale = 0;
                break;
        }
    }
}
