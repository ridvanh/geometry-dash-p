using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private BoxCollider2D _boxCollider;
    
    [Header("Physical values")]
    public float jumpHeight = 5f;
    public float gravityScale = 5f;


    [Header("Ground checking")]
    public float extraHeight = 0.25f;
    public LayerMask landableLayers;


    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _boxCollider = GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement() {
        switch (LevelManager.Instance.levelState) {
            case LevelState.Ground:
                if (Input.GetMouseButtonDown(0) && IsGrounded()) {
                    _rigidbody.gravityScale = gravityScale;
                    float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rigidbody.gravityScale) * -2) 
                                      * _rigidbody.mass;
                    _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

                    if (_rigidbody.velocity.y > 0) {
                        _rigidbody.gravityScale = gravityScale;
                    }
                }
                break;
            case LevelState.Aerial:
                if (Input.GetMouseButton(0)) {
                    _rigidbody.gravityScale = gravityScale;
                    float jumpForce = Mathf.Sqrt(jumpHeight * (Physics2D.gravity.y * _rigidbody.gravityScale) * -2) 
                                      * _rigidbody.mass;
                    _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
                    
                    if (_rigidbody.velocity.y > 0) {
                        _rigidbody.gravityScale = gravityScale;
                    }
                }
                break;
        }
    }

    bool IsGrounded() {
        RaycastHit2D raycastHit2D = Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size,
            0f, Vector2.down, extraHeight, landableLayers);
        
        return raycastHit2D.collider != null;
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Deadzone")) {
            if (AudioManager.Instance.enableSfx) {
                AudioManager.Instance.PlayDeathSound();
            }
            SceneManager.LoadScene("Scenes/Play");
        }else if (other.CompareTag("StateChanger")) {
            LevelManager.Instance.ChangeState();
        }
    }
}
