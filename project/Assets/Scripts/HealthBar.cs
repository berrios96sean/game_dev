using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //you have to import this when you're scripting UI

public class HealthBar : MonoBehaviour
{
    //Create a slider variable
    public Slider slider; 
    
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health; 
    }

    public void SetHealth(int health)
    {
        slider.value = health; 
    }
}
