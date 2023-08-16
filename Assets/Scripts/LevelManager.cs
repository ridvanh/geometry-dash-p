using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Singleton
    public static LevelManager Instance { get; private set; }

    private void Awake() {
        if (Instance != null && Instance != this) {
            Destroy(this);
        }
        else {
            Instance = this;
        }
    }
    
    //Other properties and methods
    public LevelState levelState;

    private void Start() {
        levelState = LevelState.Ground;
    }

    public void ChangeState() {
        switch (levelState) {
            case LevelState.Ground:
                Debug.Log("Level State has changed to Aerial");
                levelState = LevelState.Aerial;
                break;
            case LevelState.Aerial:
                Debug.Log("Level State has changed to Ground");
                levelState = LevelState.Ground;
                break;
        }
    }
}
