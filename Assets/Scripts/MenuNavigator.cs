using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene("Scenes/Play");
    }
}
