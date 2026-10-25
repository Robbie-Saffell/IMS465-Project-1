using UnityEngine;
using System.Threading.Tasks;

public class Enemy : MonoBehaviour
{
    // Rotates the enemy along the y axis to turn the weapon, simulating a swing

    public int raise = 30;
    public int swing = 0;
    private Vector3 rotate;
    private Vector3 stop = new Vector3(0, 0, 0);
    private bool attack = true;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotate = new Vector3(0, raise, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotate * Time.deltaTime);
        if (attack)
        {
            Swing();
        }
    }

    async void Swing()
    {
        attack = false;
        if (transform.rotation.eulerAngles.y >= 240 && transform.rotation.eulerAngles.y <= 250)
        {
            transform.rotation = Quaternion.Euler(0, 251, 0);
            rotate = stop;
            await waitFor(20); // ~ 1/3 seconds
            rotate = new Vector3(0, raise, 0);
        }
        else if (transform.rotation.eulerAngles.y >= 50 && transform.rotation.eulerAngles.y <= 60)
        {
            transform.rotation = Quaternion.Euler(0, 49, 0);
            rotate = stop;
            await waitFor(40); // ~ 2/3 seconds
            rotate = new Vector3(0, swing, 0);
        }
        attack = true;
    }
    public async Task waitFor(int n)
    {
        for (int i = 0; i < n; i++)
        {
            await Task.Yield();
        }
    }
}
