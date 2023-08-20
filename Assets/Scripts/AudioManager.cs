using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance { get; private set; }
    
    [SerializeField] private AudioSource menuMusicSource, inGameMusicSource, sfxSource;
    
    public Toggle sfxToggle, musicToggle;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void EnableMusic() {
        if (musicToggle.isOn) {
            menuMusicSource.UnPause();
        }
        else {
            menuMusicSource.Pause();
        }
    }

    
}
