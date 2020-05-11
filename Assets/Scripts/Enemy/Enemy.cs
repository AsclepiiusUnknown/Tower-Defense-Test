using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour //Enemy
{
    [Header("Enemy Variables")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float minDistanceToPoint = 0.2f;

    public float maxHealth = 100;
    private float health;
    public int moneyWorth = 50;
    public GameObject deathEffect;

    void Start()
    {
        health = maxHealth;
        speed = startSpeed;
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct); //CHnage startSpeed to speed for a stacking effect (?)
    }

    void Die()
    {
        PlayerStats.money += moneyWorth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);
    }
}
