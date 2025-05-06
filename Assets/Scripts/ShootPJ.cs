using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPJ : MonoBehaviour
{
    public Transform shootPoint;
    public Rigidbody2D cannonBallPrefab;
    public float shootingCooldown = 3f;
    public float projectileTimeToTarget = 1f;
    public float shootingRange = 28f;

    private GameObject player;
    private float timer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance < shootingRange)
        {
            timer += Time.deltaTime;

            if (timer >= shootingCooldown)
            {
                timer = 0f;
                Shoot();
            }
        }
    }

    void Shoot()
    {
        Vector2 velocity = CalculateProjectileVelocity(shootPoint.position, player.transform.position, projectileTimeToTarget);
        Rigidbody2D cannonBall = Instantiate(cannonBallPrefab, shootPoint.position, Quaternion.identity);
        cannonBall.linearVelocity = velocity;
    }

    Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
    {
        Vector2 displacement = target - origin;

        float vx = displacement.x / time;
        float vy = displacement.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

        return new Vector2(vx, vy);
    }
}