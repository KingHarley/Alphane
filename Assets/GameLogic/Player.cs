using GameLogic;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        var dir = enemies.Any() ? GetDirectionToClosestObject(gameObject, enemies) : Movement.GetRandomDirection();
        bullet.direction = dir;
        bullet.player = this;
        bullet.transform.position = transform.position;
        IsReadyToShoot = false;
        SecondsSinceLastShot = 0;
    }

    Vector2 GetDirectionToClosestObject(GameObject currentObj, GameObject[] objects)
    {
        if (!objects.Any())
            throw new System.Exception($"{nameof(GetDirectionToClosestObject)}: No objects thus there is no closest object");
        var closestObj = objects
            .OrderBy(go => Movement.GetDistance(go.transform.position, currentObj.transform.position))
            .First();
        return Movement.GetDirectionBetweenVectors(currentObj.transform.position, closestObj.transform.position);
    }

    void ProcessDeath()
    {
        print($"{name}: Is Dead!");
    }

}
