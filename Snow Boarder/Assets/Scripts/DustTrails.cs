using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DustTrails : MonoBehaviour
{
    [SerializeField] ParticleSystem slideEffect;
    void OnCollisionEnter2D(Collision2D other) 
    {
        slideEffect.Play();
    }
    
    void OnCollisionExit2D(Collision2D other) 
    {
        slideEffect.Stop();
    }
}
