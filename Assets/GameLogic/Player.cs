using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
        direction = Movement.GetDirection2D();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rigidBody.velocity = direction * speed;
        Debug.Log($"New Velocity: {rigidBody.velocity}", rigidBody);
    }
}
