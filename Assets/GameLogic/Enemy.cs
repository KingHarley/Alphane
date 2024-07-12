using GameLogic;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public float speed;
    GameObject player;
    public Stats stats;
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
        direction = Movement.GetDirectionBetweenVectors(transform.position, player.transform.position);
    }

    private void FixedUpdate()
    {
        rigidBody.velocity = direction * speed;

        if (stats.Health <= 0)
            ProcessDeath();
    }

    void ProcessDeath()
        => Destroy(this);

    private void OnTriggerEnter2D(Collider2D collision)
        => ProcessTriggerCollision(collision);

    private void OnTriggerStay2D(Collider2D collision)
        => ProcessTriggerCollision(collision);

    private void ProcessTriggerCollision(Collider2D collision)
    {
        var go = collision.gameObject;
        var goName = go.name;
        if (goName == "MainPlayer")
        {
            if(stats.IsReadyToDamage)
            {
                go.SendMessage("TakeDamage", stats.Damage);
                stats.TriggerDamageCooldown();
            }
        }
    }
}
