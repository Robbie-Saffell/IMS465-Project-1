using System; // Allows use of Action(line 5)
using UnityEngine;
public class Weapon : MonoBehaviour
{
    // This class is used to deal with triggering damage, detatching it from the enemy itself

    private Collider hitbox;
    public static Action TakeDamage;
    private void Start()
    {
        hitbox = GetComponent<BoxCollider>();
    }
    public void OnTriggerEnter(Collider other)
    {
        TakeDamage?.Invoke();
    }
}
