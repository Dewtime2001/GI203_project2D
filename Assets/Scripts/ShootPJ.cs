using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPJ : MonoBehaviour
{
    public GameObject Player;
    public Transform shootPoint;
    public Rigidbody2D CannonBall;
    public GameObject Bullet;

    private float timer;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);

        if (distance < 28)
        {
            timer += Time.deltaTime;
            
            if (timer > 3)
            {
                timer = 0;
                shoot();
            }
        }
    }

    void shoot()
    {
        Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, Player.transform.position, 1f);
        Rigidbody2D fireBullet = Instantiate(CannonBall, shootPoint.position, Quaternion.identity);
        fireBullet.velocity = projectileVelocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 distanc = target - origin;

        float disX = distanc.x;
        float disY = distanc.y;

        float velocityX = disX / time;
        float velocityY = disY / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        Vector2 result = new Vector2(velocityX, velocityY);

        return result;
    }
}
