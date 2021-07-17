using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage;

    private Collider2D colider;
    private void Start()
    {
        colider= GetComponent<Collider2D>();
        colider.enabled = false;
        StartCoroutine(SetCollider(true));
    }

    private IEnumerator SetCollider(bool value)
    {
        yield return new WaitForSeconds(0.15f); 
        colider.enabled = value;
        yield return null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        HP otherHP = other.gameObject.GetComponent<HP>();
        if (otherHP!=null)
        {
            otherHP.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
