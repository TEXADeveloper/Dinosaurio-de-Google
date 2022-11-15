using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpMultiplier = 5;
    [SerializeField] private float fallMultiplier = 7;
    [SerializeField] private float checkDistance = 0.3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxJumpTime = 1;
    private float jumpTime = 0;
    public bool jumping = false;
    public bool grounded = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) /*&& grounded*/)
        {
            jumping = true;
            grounded = false;
            anim.SetBool("Grounded", false);
            anim.SetBool("Jumping", true);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            jumping = false;
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
        }
    }

    void FixedUpdate()
    {
        if (jumping)
            jump();
        else
            fall();

        if (!grounded && !jumping)
            isGrounded();
    }

    private void jump()
    {
        jumpTime += Time.fixedDeltaTime;
        if (jumpTime >= maxJumpTime)
        {
            jumping = false;
            anim.SetBool("Jumping", false);
            anim.SetBool("Falling", true);
            return;
        }
        rb.velocity += Vector3.up * jumpMultiplier * Time.fixedDeltaTime * 1/jumpTime;
    }

    private void fall()
    {
        rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime;
    }

    private void isGrounded()
    {
        bool hit = Physics.Raycast(transform.position + Vector3.up * 0.05f, Vector3.down, checkDistance, groundLayer);
        if (hit)
        {
            anim.SetBool("Falling", false);
            anim.SetBool("Grounded", true);
            grounded = hit;
            jumpTime = 0;
        }
    }
}
