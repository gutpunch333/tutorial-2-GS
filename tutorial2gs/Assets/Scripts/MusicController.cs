using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public GameObject otherGameObject;
    private PlayerScript musicParent;

    public AudioSource musicSource;

    public AudioClip backgroundMusic;
    public AudioClip winSound;

    public int babyScore;
    private int gameEnded = 0;

    void Awake()
    {
        musicParent = otherGameObject.GetComponent<PlayerScript>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        musicSource.clip = backgroundMusic;
        musicSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        //babyScore == musicParent.scoreValue;
        if (musicParent.scoreValue == 8 & gameEnded == 0)
            {
                musicSource.Stop();
                musicSource.clip = winSound;
                musicSource.Play();
                Debug.Log("test");
                gameEnded++;
                
            }
       
    }
}
