using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField] private BoxCollider col;
    [SerializeField] private float speed;
    [SerializeField] private float scaleFactor = 3;
    private bool move = true;

    void Start()
    {
        ObstacleManger.Accelerate += speedUp;
        Player.PlayerDeath += death;
    }

    void Update()
    {
        if(!move)
            return;

        this.transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (this.transform.position.x <= -scaleFactor * col.size.x)
            transform.position = new Vector3(-transform.position.x, transform.position.y, transform.position.z);
    }

    private void speedUp(float amount)
    {
        this.speed += amount;
    }

    private void death()
    {
        move = false;
    }

    void OnDisable()
    {
        ObstacleManger.Accelerate -= speedUp;
        Player.PlayerDeath -= death;
    }
}
