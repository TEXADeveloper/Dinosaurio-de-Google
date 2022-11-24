using UnityEngine;

public class Decoration : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private bool move = false;
    private DecorationManger dM;

    public void SetManager(DecorationManger manager, float value)
    {
        dM = manager;
        speed = value;
    }

    void OnEnable()
    {
        move = true;
        ObstacleManger.Accelerate += speedUp;
        Player.PlayerDeath += death;
    }

    void FixedUpdate()
    {
        if (move)
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        if (this.transform.position.x <= -50)
            dM.Despawn(this.gameObject);
    }

    private void death()
    {
        move = false;
    }

    void OnDisable()
    {
        move = false;
        ObstacleManger.Accelerate -= speedUp;
        Player.PlayerDeath -= death;
    }

    private void speedUp(float amount)
    {
        this.speed += amount;
    }
}
