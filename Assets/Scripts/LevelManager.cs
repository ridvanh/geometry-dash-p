using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public LevelState levelState;

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    
    private void Start() {
        levelState = LevelState.Ground;
    }

    public void ChangeState() {
        switch (levelState) {
            case LevelState.Ground:
                levelState = LevelState.Aerial;
                break;
            case LevelState.Aerial:
                levelState = LevelState.Ground;
                break;
        }
    }
}
