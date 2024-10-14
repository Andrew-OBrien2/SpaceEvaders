using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawner : MonoBehaviour
{
    //timer to delay the spawn
    private float time;
    //timer delay
    public float delay;
    public GameObject spawnObject;
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

        if (time >= delay)
        {
            spawnItem();
            time = 0f;
        }
    }

    private void spawnItem()
    {
        Instantiate(spawnObject);
        spawnObject.transform.position = new Vector2(Random.Range(-8.5f,8.5f), 6.5f);
    }
}
