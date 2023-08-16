using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundScroller : MonoBehaviour {
    [SerializeField] private RawImage rawImage;
    [SerializeField] private float scrollingSpeed;

    private void Update() {
        rawImage.uvRect = new Rect(rawImage.uvRect.position + new Vector2(scrollingSpeed, 0) * Time.deltaTime,
            rawImage.uvRect.size);
    }
}
