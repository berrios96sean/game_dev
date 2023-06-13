using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateMovement : MonoBehaviour
{

    //This allows this script to access the animator which is attached to the pirate 
    //Note that you must also select the animator within the Inspector for this movement script 
    public Animator animator; 

    //Pirate's speed (change in position PER FRAME)
    public float speed = 5.0f; 

    //I think the speed of all moveable sprites should maybe be defined as properties of the corresponding classes instead of within their movement scripts
    //For example: Pirate's speed should be inherent to a Pirate class, Zombies' speed should be inherent to a Zombie class (or sub-classes for different zombie types), etc

    //Tracks whether the pirate is facing right
    //This is manipulated within Flip() and referenced within Update() to control which way the sprite is looking based on the direction the player is moving
    bool facingRight = true; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Define the magnitude of horizontal and vertical movements by getting the input axis and multiplying it by speed
        float horizontalShift = Input.GetAxis("Horizontal") * speed; 
        float verticalShift = Input.GetAxis("Vertical") * speed; 

        //Manipulate the animator's PlayerSpeed parameter to match the absolute value of our horizontal shift
        //Has to use absolute value so that PlayerSpeed doesn't become negative when the player moves to the left
        animator.SetFloat("PlayerSpeed", Mathf.Abs(horizontalShift));

        //Make sure our shifts happen per second instead of per frame 
        horizontalShift *= Time.deltaTime; 
        verticalShift *= Time.deltaTime; 

        //Change sprite position by adjusting X and Y axes
        transform.Translate(horizontalShift, verticalShift, 0);

        //Flip the sprite if its current orientation does not match the direction in which the user wants it to move
        if (horizontalShift > 0 && !facingRight) {
            Flip();
        }

        if (horizontalShift < 0 && facingRight) {
            Flip(); 
        }
    }

    //Flip function
    void Flip() 
    {
        Vector3 currentScale = gameObject.transform.localScale; 
        currentScale.x *= -1; 
        gameObject.transform.localScale = currentScale; 

        facingRight = !facingRight; 
    }

}
