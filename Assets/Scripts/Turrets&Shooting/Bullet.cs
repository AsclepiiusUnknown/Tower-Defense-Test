using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Transform target;

    public float speed = 70f;
    public float explosionRadius;
    public GameObject hitEffect;

    public int hitDamage = 50;
    public int explosionDamage = 50;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectGO = (GameObject)Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(effectGO, 5f);

        if (explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            HitDamage(target);
        }

        //Debug.Log("Hit");
        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                ExplosionDamage(collider.transform);
            }
        }
    }

    void HitDamage(Transform enemyGO)
    {
        Enemy e = enemyGO.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(hitDamage);
            print("Dmg: " + hitDamage);
        }
    }

    void ExplosionDamage(Transform enemyGO)
    {
        Enemy e = enemyGO.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(explosionDamage);
            print("Exp Dmg: " + hitDamage);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
