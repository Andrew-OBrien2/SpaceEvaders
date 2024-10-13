using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    //make the bat move towards the player
    public float speed;
    private Rigidbody2D asteroidRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        asteroidRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        asteroidRigidBody.velocity = new Vector2 (asteroidRigidBody.velocity.x, -speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
