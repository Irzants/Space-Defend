using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 30;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    //player take dmg form enemy when collide
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer dmg = other.GetComponent<DamageDealer>(); //call script DamageDealer

        if(dmg != null)
        {
            TakeDamage(dmg.GetDamage());
            PlayHitEffect(); //call method to show up the explosion
            audioPlayer.PlayDamageClip(); //call dmg audio from audioplayer script
            ShakeCamera();
            dmg.Hit();
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity); //call particle sistem effect
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax); //destroy the effect after it called

        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }


}
