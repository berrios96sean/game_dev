using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_sprite : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    /* This is just an example of how player movement is done. There are probabyly 
     * some better features we can add later. For the zombie we'll want to create 
     * some time of spawn conditions etc. 
     */ 
void Update()
{
    float moveSpeed = 2f; // Adjust this value to change the movement speed

    // Get input from arrow keys or WASD
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");

    // Calculate the movement vector
    Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0f) * moveSpeed * Time.deltaTime;

    // Apply the movement to the sprite's position
    transform.position += movement;

    // Flip the sprite horizontally based on movement direction
    if (moveHorizontal < 0 && transform.localScale.x > 0)
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    if (moveHorizontal > 0 && transform.localScale.x < 0)
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    if (moveVertical < 0 && transform.localScale.x > 0)
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    if (moveVertical > 0 && transform.localScale.x < 0)
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

    // Additional conditions for handling two movement keys simultaneously
    // TO-DO: Fix this, not working as expected 
    if (moveHorizontal != 0 && (moveVertical > 0 || moveVertical < 0))
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    if ((moveHorizontal < 0 || moveHorizontal > 0) && moveVertical != 0)
        transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);

}



}
