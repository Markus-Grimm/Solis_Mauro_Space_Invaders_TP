using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager instance = null;

    public GameObject player;
    public AudioSource playerAudioS;
    public AudioClip laser;

    public GameObject enemy;
    public AudioSource enemyAudioS;
    public AudioClip enemydead;


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

        enemy = GameObject.FindGameObjectWithTag("Enemy");
        enemyAudioS = enemy.GetComponent<AudioSource>();
    }



}
