using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    public GameObject deathEffect;
    public GameObject deadPlayer;
    public AudioSource audioSource;
    public SpawnController spawnController_script;
    public GameObject SpawnController_OBJ;

    private bool movingRight = false;
    private bool facingRight;
    public float moveSpeed;

    public float jumpForce;
    private bool isGrounded;
    private bool wallJump = false;
    private const float groundedRadius = .2f;
    public Transform groundCheck;
    public LayerMask Ground;
    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    private void Start()
    {
        SpawnController_OBJ = GameObject.FindWithTag("SpawnController");
        spawnController_script = SpawnController_OBJ.GetComponent<SpawnController>();
    }

    private void Awake()
    {
        movingRight = true;

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();
    }

    private void Update()
    {
        if (movingRight == true)
        {
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }

        if (movingRight == false)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            animator.SetBool("isJumping", true);
            isGrounded = true;
            rb.AddForce(new Vector2(0f, jumpForce));
            audioSource.Play();
        }

        if (Input.GetKeyDown(KeyCode.Space) && wallJump == true && isGrounded == false)
        {
            Flip();
            wallJump = false;

            if (movingRight == true)
            {
                movingRight = false;
            }
            else
            {
                movingRight = true;
            }

            animator.SetBool("isJumping", true);
            rb.AddForce(new Vector2(0f, jumpForce));
            audioSource.Play();
        }
    }

    private void FixedUpdate()
    {
        bool wasGrounded = isGrounded;
        isGrounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, Ground);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                isGrounded = true;
                if (!wasGrounded)
                    OnLandEvent.Invoke();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Die();
        }

        if (collision.gameObject.tag == "Wall")
        {
            wallJump = true;
        }
    }

    public void OnLanding()
    {
        animator.SetTrigger("Landing");
        animator.SetBool("isJumping", false);
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    private void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Instantiate(deadPlayer, transform.position, Quaternion.identity);
        Destroy(gameObject);
        spawnController_script.SpawnPlayer();
    }
}