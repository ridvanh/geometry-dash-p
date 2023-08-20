using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("Scenes/Play");

        if (AudioManager.Instance.musicToggle.isOn) {
            AudioManager.Instance.transform.GetChild(0).gameObject.SetActive(false);
            AudioManager.Instance.transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    
    
}
