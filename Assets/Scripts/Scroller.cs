using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scroller : MonoBehaviour
{
    public GameObject image1;  
    public GameObject image2;  
    public float scrollSpeed = 2.0f;

    void Update()
    {
        // Move both images downward at the same speed
        image1.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;
        image2.transform.position += Vector3.down * scrollSpeed * Time.deltaTime;

        // If image1's y value is less than or equal to the negative height of its sprite in unity units, move it on top of the other image
        if (image1.transform.position.y <= -GetHeight(image1))
        {
            MoveOnTop(image1, image2);
        }

        // If image2's y value is less than or equal to the negative height of its sprite in unity units, move it on top of the other image
        if (image2.transform.position.y <= -GetHeight(image2))
        {
            MoveOnTop(image2, image1);
        }
    }

    void MoveOnTop(GameObject lowerImage, GameObject upperImage)
    {
        //move the lower image to the upper image's y value PLUS however tall the actual size of the sprite is in unity units (this stacks it on top)
        lowerImage.transform.position = new Vector2(lowerImage.transform.position.x, upperImage.transform.position.y + GetHeight(upperImage));
    }

    // Get the actual size of the sprite in unity units
    float GetHeight(GameObject image)
    {
        return image.GetComponent<SpriteRenderer>().bounds.size.y;
    }
}
