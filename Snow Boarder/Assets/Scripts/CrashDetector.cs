using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem dieEffect;
    [SerializeField] AudioClip crashSFX;
    Scene level;
    int levelNo;
    bool hasCrashed = false;

    void Start() 
    {
        level = SceneManager.GetActiveScene();
        levelNo = level.buildIndex;
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Level" && !hasCrashed)
        {
            hasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            dieEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            levelNo = level.buildIndex;
            Invoke("restartLevel", delay);
        }
    }

    void restartLevel()
    {
        SceneManager.LoadScene(levelNo);
    }
}
