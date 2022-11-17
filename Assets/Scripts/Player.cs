using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float jumpMultiplier = 4;
    [SerializeField] private float fallMultiplier = 6;
    [SerializeField] private float fallImpulseMultiplier = 4;
    [SerializeField] private float checkDistance = .3f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxJumpTime = .3f;
    private float jumpTime = 0;
    private bool jumping = false;
    private bool grounded = false;
    private float impulseMultiplier = 1;
    private bool died = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
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

        if (Input.GetKeyDown(KeyCode.S))
            impulseMultiplier = fallImpulseMultiplier;
        if (Input.GetKeyUp(KeyCode.S))
            impulseMultiplier = 1;
    }

    void FixedUpdate()
    {
        if (died)
            return;

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
        rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.fixedDeltaTime * impulseMultiplier;
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

    void OnCollisionEnter(Collision col)
    {
        if (col.transform.tag.Equals("Obstacle"))
        {
            rb.constraints = RigidbodyConstraints.None;
            died = true;
            anim.SetBool("Died", true);
        }
    }
}
