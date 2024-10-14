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
    public float blinkDistance;

    public GameObject teleportIconPrefab;
    private GameObject teleportIcon;

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
        blinkForward();
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
        //while the player is holding space, do this
        if (Input.GetKey(KeyCode.Space))
        {
            if (teleportIcon == null)
            {
                //                                                                                                               need rotation when instantiating
                teleportIcon = Instantiate(teleportIconPrefab, new Vector2(transform.position.x, transform.position.y + blinkDistance), Quaternion.identity);
            }
            else
            {
                //move the existing icon
                teleportIcon.transform.position = new Vector2(transform.position.x, transform.position.y + blinkDistance);
            }

            // Make sure the teleport icon doesn't go out of bounds (player boundry box's y value is 5.3)
            if (teleportIcon.transform.position.y > 5f)
            {
                // Set the Y position to 5.2 if it's equal to or greater than 5.3
                teleportIcon.transform.position = new Vector2(teleportIcon.transform.position.x, 5f);
            }
        }

        //if the player releases space, do this
        if (Input.GetKeyUp(KeyCode.Space) && teleportIcon != null)
        {
            transform.position = teleportIcon.transform.position;
            Destroy(teleportIcon);
            teleportIcon = null;
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
