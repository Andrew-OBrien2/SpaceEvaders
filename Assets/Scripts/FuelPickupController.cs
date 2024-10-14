using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelPickup : MonoBehaviour
{
    public float speed;
    private Rigidbody2D fuelRigidBody;
    public FuelBar fuelBar;

    // Start is called before the first frame update
    void Start()
    {
        fuelRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        fuelRigidBody.velocity = new Vector2(fuelRigidBody.velocity.x, -speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            fuelBar.FillFuel();

            //destroy the fuel pickup after it's collected
            Destroy(gameObject);
        }
    }
}
