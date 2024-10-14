using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
