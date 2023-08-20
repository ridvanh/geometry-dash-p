using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioSource menuMusicSource, inGameMusicSource, sfxSource;
    
    public Toggle sfxToggle, musicToggle;
    public bool enableMusic, enableSfx;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start() {
        enableMusic = enableSfx = true;
        sfxSource.Pause();
    }

    public void EnableMusic() {
        if (musicToggle.isOn) {
            menuMusicSource.UnPause();
            enableMusic = true;
        }
        else {
            menuMusicSource.Pause();
            enableMusic = false;
        }
    }

    public void EnableSFX() {
        if (sfxToggle.isOn) {
            enableSfx = true;
        }
        else {
            enableSfx = false;
        }
    }

    public void PlayDeathSound() {
        sfxSource.PlayOneShot(sfxSource.clip);
    }
}
