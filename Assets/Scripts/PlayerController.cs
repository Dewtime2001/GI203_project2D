using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D), typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float maxRollSpeed;
    public float accelerationSpeed;
    public float decelerationSpeed;
    public float rollDegreeMultiplier;
    public float jumpSpeed;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private CircleCollider2D cc;

    private float circumference;
    private bool isGrounded = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cc = GetComponent<CircleCollider2D>();
        circumference = 2 * Mathf.PI * cc.radius;
    }

    void Update()
    {
        isGrounded = cc.IsTouchingLayers(groundLayer);
        Move(Input.GetAxisRaw("Horizontal"));
        AnimationUpdate();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void AnimationUpdate()
    {
        float speed = rb.linearVelocity.magnitude;
        if (speed > 0)
        {
            transform.Rotate(0, 0, (speed * -Mathf.Sign(rb.linearVelocity.x) * Time.deltaTime / circumference) * 360f * rollDegreeMultiplier);
        }
    }

    void Move(float h)
    {
        if (h != 0)
        {
            rb.linearVelocity += h * accelerationSpeed * Vector2.right * Time.deltaTime;
            if (rb.linearVelocity.x > maxRollSpeed || rb.linearVelocity.x < -maxRollSpeed)
            {
                rb.linearVelocity = new Vector2(h * maxRollSpeed, rb.linearVelocity.y);
            }
        }
        else if (rb.linearVelocity.x != 0)
        {
            float deceleratedSpeed = Mathf.Lerp(rb.linearVelocity.x, 0, decelerationSpeed * Time.deltaTime);
            rb.linearVelocity = new Vector2(deceleratedSpeed, rb.linearVelocity.y);
        }
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpSpeed);
        }
    }
}
