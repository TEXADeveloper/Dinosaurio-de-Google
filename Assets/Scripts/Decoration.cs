using UnityEngine;

public class Decoration : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    private bool move = false;
    private DecorationManger dM;

    void Start()
    {
        ObstacleManger.Accelerate += speedUp;
    }

    public void SetManager(DecorationManger manager, float value)
    {
        dM = manager;
        speed = value;
    }

    void OnEnable()
    {
        move = true;
    }

    void FixedUpdate()
    {
        if (move)
            transform.Translate(Vector3.left * speed * Time.fixedDeltaTime);
        if (this.transform.position.x <= -50)
            dM.Despawn(this.gameObject);
    }

    void OnDisable()
    {
        move = false;
        ObstacleManger.Accelerate -= speedUp;
    }

    private void speedUp(float amount)
    {
        this.speed += amount;
    }
}
