using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pirateMovement : MonoBehaviour
{
    //Pirate's speed (change in position PER FRAME)
    public float speed = 5.0f; //maybe we should make player-character's speed inherent to a player-character Class instead of defining it within the corresponding movement script like this? 

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

        //Make sure our shifts happen per second instead of per frame 
        horizontalShift *= Time.deltaTime; 
        verticalShift *= Time.deltaTime; 

        //Change sprite position by adjusting X and Y axes
        transform.Translate(horizontalShift, verticalShift, 0);

        
    }


}
