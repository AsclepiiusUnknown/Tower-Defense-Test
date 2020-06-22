using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    #region Variables
    [Header("Movement")]
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    public float minDistanceToPoint = 0.2f;

    [Header("Health")]
    public float maxHealth = 100;
    private float health;
    public Image healthBar;

    [Header("Death")]
    public int moneyWorth = 50;
    public GameObject deathEffect;

    private bool isDead = false;
    #endregion

    #region Setup
    void Start()
    {
        health = maxHealth;
        speed = startSpeed;
    }
    #endregion

    #region Damage
    //take the given ammount of damage and die if we are below 0 health
    public void TakeDamage(float amount)
    {
        health -= amount;

        healthBar.fillAmount = health / maxHealth;

        if (health <= 0 && !isDead)
        {
            Die();
        }
    }
    #endregion

    #region Slow Down
    //Slow down this enemy by the given percentage
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
    }
    #endregion

    #region Death
    //destroy this enemy appropriately to avoid errors and give money as well as use the effect and tell the wave spawner
    void Die()
    {
        isDead = true;

        PlayerStats.money += moneyWorth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        WaveSpawner.EnemiesAlive--;

        Destroy(gameObject);
    }
    #endregion
}
