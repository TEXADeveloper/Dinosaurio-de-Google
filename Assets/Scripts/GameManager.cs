using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private ObstacleManger oM;
    [SerializeField] private float spawnCooldown;
    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCooldown)
        {
            timer = 0;
            oM.SpawnRandom();
        }
    }
}
