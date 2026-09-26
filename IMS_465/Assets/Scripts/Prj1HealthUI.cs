using UnityEngine;
using UnityEngine.UI; // Needed for connecting to UI elements (Image in this case)
using System;

public class Prj1HealthUI : MonoBehaviour
{
    // Events
    public static Action PlayerDeath;
    // GameObjects
    public Prj1HealthUI HUI;
    // Ints
    public int health = 3;
    // Images
    public Image heart1;
    public Image heart2;
    public Image heart3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    private void OnEnable()
    {
        Prj1Enemy.TakeDamage += UITakeDamage; // Setup the observer for detecting TakeDamage event
        health = 3;
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;
    }
    private void OnDisable()
    {
        Prj1Enemy.TakeDamage -= UITakeDamage; // Close the observer to prevent data leak
    }
    // Take damage gets activated by the broadcast signal from the enemy script detecting collision
    public void UITakeDamage()
    {
        health--;
        if (health == 2)
        {
            heart3.enabled = false;
        } else if (health == 1)
        {
            heart2.enabled = false;
        } else
        {
            heart1.enabled = false;
            HUI.enabled = false;
            PlayerDeath?.Invoke(); // Kill player if they have 0 health
            HUI.enabled = true;
        }
    }
}
