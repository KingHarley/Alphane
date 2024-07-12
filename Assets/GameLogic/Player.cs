using GameLogic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rigidBody;
    public Stats stats;
    Vector2 direction = Vector2.zero;

    public Bullet PrefabBullet;
    int ShootRate = 2;
    public float SecondsSinceLastShot = 0;
    public bool IsReadyToShoot = false;

    // Update is called once per frame
    void Update()
    {
        direction = Movement.GetDirectionForPlayer();
    }

    private void FixedUpdate()
    {
        Move();

        if (stats.Health <= 0)
            ProcessDeath();
        if (!IsReadyToShoot)
        {
            SecondsSinceLastShot += Time.deltaTime;
            if (SecondsSinceLastShot >= ShootRate)
                IsReadyToShoot = true;
        }
        else
        {
            Shoot();
        }
    }

    void Move()
    {
        rigidBody.velocity = direction * speed;
    }

    void Shoot()
    {
        var bullet = Instantiate(PrefabBullet);
        bullet.direction = Movement.GetDirectionBetweenVectors(transform.position, GameObject.FindGameObjectWithTag("Enemy").transform.position);
        bullet.player = this;
        bullet.transform.position = transform.position;
        IsReadyToShoot = false;
        SecondsSinceLastShot = -1000;
    }

    void ProcessDeath()
    {
        print($"{name}: Is Dead!");
    }

}
