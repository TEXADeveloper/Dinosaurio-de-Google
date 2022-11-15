using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private bool move = false;
    private ObstacleManger oM;

    public void SetManager(ObstacleManger manager)
    {
        oM = manager;
    }

    void OnEnable()
    {
        move = true;
    }

    void FixedUpdate()
    {
        if (move)
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        if (this.transform.position.x <= -15)
            oM.Despawn(this.gameObject);
    }

    void OnDisable()
    {
        move = false;
    }
}
