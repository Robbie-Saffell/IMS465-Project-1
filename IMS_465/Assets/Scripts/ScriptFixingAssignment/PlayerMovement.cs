using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        transform.position += Vector3.forward * moveSpeed * Time.deltaTime; 
    }
}