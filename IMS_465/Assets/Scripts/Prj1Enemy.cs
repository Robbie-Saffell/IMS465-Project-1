using System; // Allows use of Action(line 5)
using UnityEngine;
public class Prj1Enemy : MonoBehaviour
{
    public static Action TakeDamage;
    
    public void OnTriggerEnter(Collider other)
    {
        TakeDamage?.Invoke();
    }
}
