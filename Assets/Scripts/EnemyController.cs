using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player;
    private Vector2 playerLocation;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerLocation = player.transform.position;
        transform.position = Vector2.MoveTowards(transform.position, playerLocation, speed * Time.deltaTime);
        flipEnemySprite();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {



            //if the enemy collides with the player, end the game.



        }
    }

    private void flipEnemySprite()
    {
        // Flip sprite based on the direction to the player
        if (playerLocation.x < transform.position.x)
        {
            // Face left
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            // Face right
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
