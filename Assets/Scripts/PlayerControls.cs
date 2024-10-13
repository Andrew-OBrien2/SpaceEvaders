using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Rigidbody2D playerRigidBody;
    public float movementSpeed;
    public float maxSpeed;
    public float acceleration;
    public float deceleration;

    // Start is called before the first frame update
    void Start()
    {
        //I can only get this component using the following line of code
        //because the rigidobdy2d is attached to the player and this script is
        //also attached to the player
        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //check each action in here.
        movePlayer();
    }

    private void movePlayer()
    {
        // Get current velocity
        Vector2 currentVelocity = playerRigidBody.velocity;

        // Check if arrow keys are being held down to increase velocity
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (currentVelocity.x > -maxSpeed) // Move left
            {
                currentVelocity.x -= acceleration * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (currentVelocity.x < maxSpeed) // Move right
            {
                currentVelocity.x += acceleration * Time.deltaTime;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            if (currentVelocity.y < maxSpeed) // Move up
            {
                currentVelocity.y += acceleration * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (currentVelocity.y > -maxSpeed) // Move down
            {
                currentVelocity.y -= acceleration * Time.deltaTime;
            }
        }

        // When no keys are pressed, apply deceleration
        if (!Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))
        {
            if (currentVelocity.x > 0)
            {
                currentVelocity.x -= deceleration * Time.deltaTime;
            }
            else if (currentVelocity.x < 0)
            {
                currentVelocity.x += deceleration * Time.deltaTime;
            }
        }

        if (!Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.DownArrow))
        {
            if (currentVelocity.y > 0)
            {
                currentVelocity.y -= deceleration * Time.deltaTime;
            }
            else if (currentVelocity.y < 0)
            {
                currentVelocity.y += deceleration * Time.deltaTime;
            }
        }

        // Apply the updated velocity to the player's Rigidbody
        playerRigidBody.velocity = currentVelocity;
    }

    private void useAbility()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            //if they have a power up saved, fire the weapon and reduce the count by one. Remove the icon showing them their power up.
        }
    }

    private void blinkForward()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //display the blink location ahead of them N number of pixel spaces away
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            //teleport the player over to the blink location gameObject
        }
    }

    private void pauseGame()
    {
        //THIS VARIABLE will likely need to be global so it can be used in other ways, such as stopping enemy movement and the background scrolling.
        bool gamePaused = false;
        if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == false)
        {
            //pause the game.
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && gamePaused == true)
        {
            //unpause / resume the game.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Asteroid"))
        {
            //end the game, do whatever is needed like save score and stuff.
        }
    }
}
