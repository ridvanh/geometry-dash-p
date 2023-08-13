using System;
using UnityEngine;

public class Level : MonoBehaviour {
    public float moveSpeed;
    
    private Vector3 moveVector;
    private Rigidbody2D rigidbody;


    private void Awake() {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Start() {
        moveVector = new Vector3(-moveSpeed * 0.016f, 0, 0);
        rigidbody.velocity = moveVector;
    }

    
    void Update() {
        transform.position += moveVector;
    }
}
