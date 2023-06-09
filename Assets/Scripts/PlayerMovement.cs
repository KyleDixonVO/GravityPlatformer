using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] CapsuleCollider2D capsule;
    [SerializeField] bool jumping;
    [SerializeField] float jumpForce;
    [SerializeField] float topSpeedHorz;
    [SerializeField] float topSpeedVert;
    [SerializeField] float baseForce;
    [SerializeField] float horizontalSpeed;
    [SerializeField] float verticalSpeed;
    [SerializeField] float accelerationHorz;
    [SerializeField] float accelerationVert;
    [SerializeField] float groundCheckDistance;
    [SerializeField] LayerMask groundedMask;
    [SerializeField] float gracePeriodLength;
    [SerializeField] float elapsedGracePeriod;

    [SerializeField] private float horizontalInput;
    [SerializeField] private float verticalInput;
    [SerializeField] private bool shouldJump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckInputs();
    }

    private void FixedUpdate()
    {
        isGrounded();

        if (!GameManager.GM.isGamePaused())
        {
            UnfreezeRigidbody();
            Move();
            Jump();
        }
        else
        {
            FreezeRigidbody();
        }
    }

    void CheckInputs()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        if (Input.GetButtonDown("Jump") && !jumping)
        {
            shouldJump = true;
        }
    }

    void Move()
    { 
        rb.AddForce(new Vector2(horizontalInput * baseForce * Time.fixedDeltaTime, 0));
    }

    void Jump()
    {
        if (shouldJump && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            shouldJump = false;
            jumping = true;
        }
    }

    void FreezeRigidbody()
    {
        if (rb.simulated == false) return;
        rb.simulated = false;
    }

    void UnfreezeRigidbody()
    {
        if (rb.simulated == true) return;
        rb.simulated = true;
    }

    bool isGrounded()
    {
        
        if (Physics2D.Linecast(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2)), new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2) - groundCheckDistance), groundedMask).collider != null)
        {
            Debug.Log(Physics2D.Linecast(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2)), new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2) - groundCheckDistance), groundedMask).collider);
            elapsedGracePeriod = 0;
            jumping = false;
            return true;
        }
        else if (elapsedGracePeriod < gracePeriodLength)
        {
            elapsedGracePeriod += Time.deltaTime;
            Debug.Log(gracePeriodLength - elapsedGracePeriod);
            return true;
        }
        else
        {
            //Debug.Log("No collider");
            return false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlackHole") 
        {
            collision.GetComponent<BlackHole>().ApplyForce(rb);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2)), new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y - (capsule.size.y / 2) - groundCheckDistance));
    }
}
