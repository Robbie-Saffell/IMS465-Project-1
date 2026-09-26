using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    void Awake()
    {
        maxHealth = 100f;
        currentHealth = maxHealth;
        Debug.Log("[PlayerStats] Health values initialized.");
    }
}