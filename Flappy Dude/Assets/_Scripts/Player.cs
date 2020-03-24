using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;

    bool didFlap = false;
    public Vector3 flapVelocity;

    public float maxSpeed = 5f;
    public float forwardSpeed = 1f;


    // Start is called before the first frame update
    void Start()
    {
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            didFlap = true;
        }
    }

    private void FixedUpdate() {
        MovePlayer();
    }

    void MovePlayer() {
        velocity.x = forwardSpeed;
        velocity += gravity;

        if (didFlap) {
            didFlap = false;

            if(velocity.y < 0) {
                velocity.y = 0;
            }

            velocity += flapVelocity;
        }

        velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

        transform.position += velocity * Time.fixedDeltaTime;

        float angle = 0;

        if(velocity.y < 0) {
            angle = Mathf.Lerp(0, -45, -velocity.y / maxSpeed);
        }

        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.transform.tag != "Sky") {

            Time.timeScale = 0;
        }
    }
}
