using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

	public float startingHealth=100f;
    public float currentHealth;
    public float sinkSpeed = 2.5f;
    public int scoreValue = 10;
    public AudioClip deathClip;

    Animator anim;
    ParticleSystem hitParticles;
    AudioSource enemyAudio;
    CapsuleCollider capsuleCollider;
    bool isDead;
    bool isSinking;

    void Awake()
    {
        anim = GetComponent<Animator>();
        hitParticles = GetComponentInChildren<ParticleSystem>();
        enemyAudio = GetComponent<AudioSource>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;

    }
    
    void Update()
    {
       if(isSinking)
       {
           transform.Translate(Vector3.down * sinkSpeed * Time.deltaTime);
       }
    }


}
