using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private Animator anim;

    void Start()
    {
        Player.PlayerDeath += shake;
    }

    private void shake()
    {
        anim.SetTrigger("Shake");
    }

    void OnDisable()
    {
        Player.PlayerDeath -= shake;
    }
}
