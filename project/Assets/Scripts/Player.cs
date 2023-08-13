using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

#region Library Imports 

    //HEALTH
    public HealthBar healthBar; 
    //This allows this script to access the animator which is attached to the pirate 
    //Note that you must also select the animator within the Inspector for this movement script 
    public Animator animator; 
    // Call PirateSprite Library 
    public PirateSprite pirate_sprite;

#endregion

#region Variable Declarations 

    public int maxHealth = 100; 
    public int currentHealth; 
    //Pirate's speed (change in position PER FRAME)
    public float speed = 5.0f; 
    public float magnitude = 0.0f;
    //I think the speed of all moveable sprites should maybe be defined as properties of the corresponding classes instead of within their movement scripts
    //For example: Pirate's speed should be inherent to a Pirate class, Zombies' speed should be inherent to a Zombie class (or sub-classes for different zombie types), etc
    //Tracks whether the pirate is facing right
    //This is manipulated within Flip() and referenced within Update() to control which way the sprite is looking based on the direction the player is moving
    bool facingRight = true; 

    public Rigidbody2D rb; 
    Vector3 movement; 

#endregion

#region Main Functions 

    private void Awake()
    {
        // Loads these object in the Unity editor automatically binding to the Player Object 
        pirate_sprite = ScriptableObject.CreateInstance<PirateSprite>();
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth; 
        healthBar.SetMaxHealth(maxHealth); 
    }

    // Update is called once per frame
    void Update()
    {
        float hShift; 
        Move(out hShift); 
        Flip(hShift); 

        //Listen for damage, and take damage if necessary 
        //In its current form, I'm just pressing space bar to make the player take damage, just to make sure the health bar functions 
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20); 
        }
    }

#endregion

#region Helper Functions 

    //Processes damage and updates health bar accordingly
    void TakeDamage(int damage) 
    {
        currentHealth -= damage; 
        healthBar.SetHealth(currentHealth);
    }

    //Flip function (for movement/animation)
    void Flip(float horizontalShift) 
    {
        //Flip the sprite if its current orientation does not match the direction in which the user wants it to move
        if (horizontalShift > 0 && !facingRight) {
            facingRight = pirate_sprite.Flip(gameObject,facingRight);
        }

        if (horizontalShift < 0 && facingRight) {
            facingRight = pirate_sprite.Flip(gameObject,facingRight);
        }
    }

    void Move(out float hShift)
    {
        //Define the magnitude of horizontal and vertical movements by getting the input axis and multiplying it by speed
        hShift = Input.GetAxis("Horizontal"); 
        float vShift = Input.GetAxis("Vertical"); 
 
        // movement updates to enable smooth transitions 
        movement = new Vector3(hShift,vShift, magnitude);
        rb.velocity = new Vector2(movement.x, movement.y) * speed;
    }

#endregion

}
