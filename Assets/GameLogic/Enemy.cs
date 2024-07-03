using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;

    GameObject player;
    Vector2 direction = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError($"Could not find player object", this);
            throw new System.Exception($"Could not find player object");
        }

    }

    // Update is called once per frame
    void Update()
    {
        direction = Movement.GetDirectionForEnemy(transform.position, player.transform.position);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = direction * speed;
    }
}
