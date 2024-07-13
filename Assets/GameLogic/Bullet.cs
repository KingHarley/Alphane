using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace GameLogic
{
    public class Bullet : MonoBehaviour
    {
        public Player player;
        public Rigidbody2D rigidBody;
        private float speed = 5;
        public Stats stats;
        public Vector2 direction;

        private void FixedUpdate()
        {
            rigidBody.velocity = direction * speed;
        }

        private void Update()
        {
            CheckDistance();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            var go = collision.gameObject;
            if (go.tag == "Enemy")
            {
                go.SendMessage("TakeDamage", stats.Damage);
                Destroy(gameObject);
            }
        }

        void CheckDistance()
        {
            if (Movement.GetDistance(transform.position, player.transform.position) > 100)
                Destroy(gameObject);
        }
    }
}