using UnityEngine;

[CreateAssetMenu(fileName = "PirateSprite", menuName = "Custom/PirateSprite")]
public class PirateSprite : ScriptableObject
{
    
    public bool Flip(GameObject pirateObject, bool facingRight) 
    {
        Vector3 currentScale = pirateObject.transform.localScale; 
        currentScale.x *= -1; 
        pirateObject.transform.localScale = currentScale; 

        facingRight = !facingRight; 

        return facingRight;
    }
}
