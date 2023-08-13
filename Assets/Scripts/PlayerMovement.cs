using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rigidbody;
    private BoxCollider2D boxCollider;
    
    [Header("Physical values")]
    public float jumpHeight = 5f;
    public float gravityScale = 5f;
    
    
    [Header("Ground checking")]
    public float extraHeight = 0.25f;
    public LayerMask landableLayers;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        HandleJump();
    }

    void HandleJump() {
        if (Input.GetMouseButtonDown(0) && IsGrounded()) {
            rigidbody.gravityScale = gravityScale;
            float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * rigidbody.gravityScale) * -2) 
                              * rigidbody.mass;
            rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            if (rigidbody.velocity.y > 0) {
                rigidbody.gravityScale = gravityScale;
            }
        }
    }

    bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size,
            0f, Vector2.down, extraHeight, landableLayers);
        
        return raycastHit2D.collider != null;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Deadzone")) {
            SceneManager.LoadScene("Scenes/Play");
        }
    }
}
