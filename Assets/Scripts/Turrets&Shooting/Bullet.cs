using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    #region Variables
    private Transform target;

    public float speed = 70f;
    public float explosionRadius;
    public GameObject hitEffect;

    public int hitDamage = 50;
    public int explosionDamage = 50;
    #endregion

    #region Setup
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
    #endregion

    #region Seek
    //Set the new target
    public void Seek(Transform _target)
    {
        target = _target;
    }
    #endregion

    #region Hit Target
    //Hit the target and create an explosion if we need to, otheriwse just perfomr normal damage
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
    #endregion

    #region Explosive
    //Explode and deal explosion damage
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

    //Deal explosion damage in the given area to the enemy game object
    void ExplosionDamage(Transform enemyGO)
    {
        Enemy e = enemyGO.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(explosionDamage);
            print("Exp Dmg: " + hitDamage);
        }
    }
    #endregion

    #region Damage
    //Deal hit damage to the enemy game object
    void HitDamage(Transform enemyGO)
    {
        Enemy e = enemyGO.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(hitDamage);
            print("Dmg: " + hitDamage);
        }
    }
    #endregion

    #region Gizmos
    //Draw gizmos for prototyping and debugging
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
    #endregion
}
