using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{

    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVol = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0f, 1f)] float damageVol = 1f;


    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVol);

    }
    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVol);

    }

    void PlayClip(AudioClip clip, float volume)
    {
        if(clip != null)
        {
            Vector3 cameraPos = Camera.main.transform.position;
            AudioSource.PlayClipAtPoint(clip, cameraPos, volume);
        }
    }

}
