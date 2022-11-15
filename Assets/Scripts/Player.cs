using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float gravityScale = 9.8f;
    [SerializeField] private float jumpHeight = 5;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxJumpTime = 1;
    private float jumpTime = 0;
    public bool jumping = false;
    public bool grounded = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            jumping = true;
            grounded = false;
        }
        if (Input.GetKeyUp(KeyCode.Space))
            jumping = false;
    }

    void FixedUpdate()
    {
        if (jumping)
            jump();

        if (!grounded && !jumping)
            gravity();
    }

    void jump()
    {
        jumpTime += Time.fixedDeltaTime;
        if (jumpTime >= maxJumpTime)
        {
            jumping = false;
            return;
        }
        transform.Translate(Vector3.up * jumpHeight * Time.fixedDeltaTime);
    }

    private void gravity()
    {
        RaycastHit[] rays = Physics.RaycastAll(transform.position + Vector3.up * 0.05f, Vector3.down, gravityScale * Time.fixedDeltaTime, groundLayer);
        if (rays.Length > 0)
        {
            this.transform.position = new Vector3(transform.position.x, rays[0].point.y, transform.position.z);
            grounded = true;
            jumpTime = 0;
        } else
            transform.Translate(Vector3.down * gravityScale * Time.fixedDeltaTime);
    }
}
