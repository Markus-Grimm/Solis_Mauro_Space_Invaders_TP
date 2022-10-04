using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;

    public GameObject player;
    public AudioSource playerAudioS;

    public AudioSource enemyAudioS;


    public static AudioManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerAudioS = player.GetComponent<AudioSource>();

        enemyAudioS = this.GetComponent<AudioSource>();
    }

    public void PlayPlayer()
    {
        playerAudioS.Play();
    }

    public void PlayEnemyDead()
    {
        enemyAudioS.Play();
    }



}
