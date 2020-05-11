using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    private Transform target;
    private Enemy targetEnemy;

    [Header("General")]
    public float range = 15f;

    [Header("Use Bullets (default)")]
    public GameObject bulletPrefab;
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Use Laser")]
    public bool useLaser = false;

    public int damagePerSec = 30;
    public float slowPct = .5f;

    public float enemyScale = 1;
    public LineRenderer laserRenderer;
    public ParticleSystem laserImpactEffect;
    public Light laserImpactLight;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";
    public float TurnSpeed = 10f;
    public Transform partToRotate;
    public Transform firePoint;


    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void Update()
    {
        if (target == null)
        {
            if (useLaser && laserRenderer.enabled)
            {
                laserRenderer.enabled = false;
                laserImpactEffect.Stop();
                laserImpactLight.enabled = false;
            }

            return;
        }

        LockOnTarget();

        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0)
            {
                Shoot();
                fireCountdown = 1 / fireRate;
            }

            fireCountdown -= Time.deltaTime;
        }
    }

    #region Shooting
    #region Target Locking
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            target = null;
        }
    }
    #endregion

    #region Shooting Bullets
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * TurnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }
    }
    #endregion

    #region Lasering
    void Laser()
    {
        targetEnemy.TakeDamage(damagePerSec * Time.deltaTime);
        targetEnemy.Slow(slowPct);


        if (!laserRenderer.enabled)
        {
            laserRenderer.enabled = true;
            laserImpactEffect.Play();
            laserImpactLight.enabled = true;
        }

        laserRenderer.SetPosition(0, firePoint.position);
        laserRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.transform.position - target.position;

        laserImpactEffect.transform.position = target.position + dir.normalized * (enemyScale / 2);

        laserImpactEffect.transform.rotation = Quaternion.LookRotation(dir);
    }
    #endregion
    #endregion

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
