using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Threading.Tasks;

public class Prj1PlayerMove : MonoBehaviour
{
    // Component Refs
    public GameObject Player;
    private Rigidbody rb;
    private Collider hitbox;
    // Movement
    public float speed = 5f;
    private float moveX;
    private float moveY;
    public bool stunned = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Weapon.TakeDamage += PTakeDamage;
        Prj1HealthUI.PlayerDeath += OnPlayerDeath;
        rb = GetComponent<Rigidbody>();
        hitbox = GetComponent<CapsuleCollider>(); // Gets the first matching component, hit detection collider needs to be first
    }
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        moveX = movementVector.x;
        moveY = movementVector.y;
    }
    // Uses the built in input system jump for the dodge trigger.
    async void OnJump()
    {
        hitbox.enabled = false;
        speed = 20f;
        await waitFor(20);
        hitbox.enabled = true;
        await waitFor(8);
        speed = 5f;
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveX, 0.0f, moveY);
        Vector3 moveFacing = transform.TransformDirection(movement);
        rb.linearVelocity = (moveFacing * speed);
    }
    // Slightly moves the player in the opposite direction they moved when getting hit to prevent continuous damage
    public async void PTakeDamage()
    {
        speed = -10; // push the playerbackwards, away from the enemy
        stunned = true;
        await waitFor(10);
        speed = 5;
        stunned = false;
    }
    // Sends the player back to 0,0,0 in world coordinates
    public void OnPlayerDeath()
    {
        Player.transform.position = new Vector3(0, 0, 0);
    }
    // Waits for a specified number of frames
    public async Task waitFor(int n)
    {
        for (int i = 0; i < n; i++)
        {
            await Task.Yield();
        }
    }
}
