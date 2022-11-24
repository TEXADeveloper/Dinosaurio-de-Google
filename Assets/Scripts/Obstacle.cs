using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private bool move = false;
    private ObstacleManger oM;

    public void SetManager(ObstacleManger manager, float value)
    {
        oM = manager;
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
        if (this.transform.position.x <= -30)
            oM.Despawn(this.gameObject);
    }

    void OnDisable()
    {
        move = false;
        ObstacleManger.Accelerate -= speedUp;
        Player.PlayerDeath -= death;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag.Equals("Player"))
            oM.SpeedUp();
    }

    private void death()
    {
        move = false;
    }

    private void speedUp(float amount)
    {
        this.speed += amount;
    }
}
