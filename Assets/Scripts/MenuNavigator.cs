using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuNavigator : MonoBehaviour {
    public bool music, sfx;
    public Button musicButton, sfxButton;

    private void Start() {
        music = sfx = true;
    }

    public void Play() {
        SceneManager.LoadScene("Scenes/Play");
    }

    public void SetSFX() {
        if (sfx) {
            sfx = false;
            sfxButton.transform.GetChild(0).gameObject.SetActive(false);
        }
        else {
            sfx = true;
            sfxButton.transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    public void SetMusic() {
        if (music) {
            music = false;
            musicButton.transform.GetChild(0).gameObject.SetActive(false);
        }
        else {
            music = true;
            musicButton.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
