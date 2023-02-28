using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class target : MonoBehaviour
{
    target instance;
    public float health = 50f;
    public Animator animator;
    public Collider collider;
    public bool isDead = false;

    private void Awake()
    {
        instance = this;

    }

    private void Update()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            isDead = true;
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("Death", true);
        
        StartCoroutine(ol());


        
    }

    IEnumerator ol()
    {
        yield return new WaitForSeconds(4);
        Destroy(collider);
        Destroy(gameObject);
    }




}


