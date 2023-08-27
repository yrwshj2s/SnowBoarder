using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float delay = 1f;
    [SerializeField] ParticleSystem finishEffect;
    Scene level;
    int levelNo;

    void Start() 
    {
        level = SceneManager.GetActiveScene();
        levelNo = level.buildIndex;
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            finishEffect.Play();
            Debug.Log("winner");
            Invoke("restartLevel", delay);
        }
    }

    void restartLevel()
    {
        SceneManager.LoadScene(levelNo);
    }
}
