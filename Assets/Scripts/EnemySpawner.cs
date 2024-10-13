using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private int randSpriteNum;
    private int randLeftOrRight;
    public GameObject spawnObject;
    public Sprite[] sprites;
    //timer to delay the spawn
    private float time;
    //timer delay
    public float delay;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //add time to time
        //this will see how much time has passed since the last frame
        time += Time.deltaTime;

        //I only want to spawn a new bat if there was a specified amouint of time between the last time I spawned an object
        if (time >= delay)
        {
            spawnEnemy();
            time = 0f;
            //f because it is a float
        }
    }

    private void spawnEnemy()
    {
        // Instantiate the spawn object
        // need to make newEnemy because I can't remove the polygon collider otherwise (can't remove attributes from prefabs during runtime).
        GameObject newEnemy = Instantiate(spawnObject);

        randSpriteNum = Random.Range(0, sprites.Length);

        //inside spawnEnemy to get spriteRenderer from the newEnemy that was just instantiated.
        SpriteRenderer enemySprite = newEnemy.GetComponent<SpriteRenderer>();
        enemySprite = spawnObject.GetComponent<SpriteRenderer>();
        enemySprite.sprite = sprites[randSpriteNum];

        // Add a new PolygonCollider2D that will automatically fit the new sprite
        // I need this because the sprites are different shapes and sizes, therefore their colliders won't look the same.
        PolygonCollider2D polygonCollider = newEnemy.AddComponent<PolygonCollider2D>();

        //Up to, not including means the options are 0 or 1
        randLeftOrRight = Random.Range(0, 2);

        if (randLeftOrRight == 0)
        {
            //spawn object on left side of screen
            newEnemy.transform.position = new Vector2(-13.5f, Random.Range(-5, 7));
        }
        else if (randLeftOrRight == 1)
        {
            //spawn object on right side of screen
            newEnemy.transform.position = new Vector2(12.5f, Random.Range(-5, 7));
        }
    }
}
