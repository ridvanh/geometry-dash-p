using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigator : MonoBehaviour {
    public void Play() {
        SceneManager.LoadScene("Scenes/Play");

        if (AudioManager.Instance.enableMusic) {
            AudioManager.Instance.transform.GetChild(0).gameObject.SetActive(false);
            AudioManager.Instance.transform.GetChild(1).gameObject.SetActive(true);
        }

        if (!AudioManager.Instance.enableSfx) {
            AudioManager.Instance.transform.GetChild(2).gameObject.SetActive(false);
        }
    }
}
