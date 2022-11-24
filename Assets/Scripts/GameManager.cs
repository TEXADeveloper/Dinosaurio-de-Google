using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject timerImage;
    [SerializeField] private GameObject diedPanel;

    [SerializeField] private ObstacleManger oM;
    [SerializeField] private float spawnCooldown;
    private float timer;
    private bool died = false;

    void Start()
    {
        Player.PlayerDeath += death;
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnCooldown && !died)
        {
            timer = 0;
            oM.SpawnRandom();
        }
    }

    private void death()
    {
        died = true;
        diedPanel.SetActive(true);
        timerImage.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }

    public void GotoMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }

    void OnDisable()
    {
        Player.PlayerDeath -= death;
    }
}
