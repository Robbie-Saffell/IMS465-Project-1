using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public PlayerStats playerStatsReference;
    public Text healthDisplayPrompt;

    void Start()
    {
        if (playerStatsReference != null && healthDisplayPrompt != null)
        {
            healthDisplayPrompt.text = "HP: " + playerStatsReference.currentHealth.ToString();
        }
    }
}

// The first change was to make player movement independant from the framerate by multiplying it by time.deltatime.
// Thise makes it move per-second instead of per-frame
// The second and third changes were swapping the method execution times in the PlayerStats and HealthUI scripts.
// Awake happens before start, and so Playerstats needs to happen first since HealthUI relies on it.