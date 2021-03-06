﻿using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage=10;

    Animator anim;
    PlayerHealth playerHealth;
    GameObject player;
    bool playerInRange;
    float timer;

    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        playerInRange = false;
        timer = 0f;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject==player)
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>timeBetweenAttacks&&playerInRange)
        {
            Attack();
        }
        if(playerHealth.currentHealth<=0)
        {
            anim.SetTrigger("PlayerDead");
        }
    }

    void Attack()
    {
        timer = 0f;
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }

    }
}
