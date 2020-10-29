using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FadeInOutPanel : MonoBehaviour {
    
    public float time;
    public bool fadeInOnStart = false;
    public float delayAfterStart = 0.2f;

    private float countDown;
    private Image image;
    private Color opaqueColor;
    private Color transparentColor;

    public Action onFadeInComplete;
    public Action onFadeOutComplete;

    private void Awake() {
        image = GetComponent<Image>();

        opaqueColor = image.color;
        opaqueColor.a = 1;
        transparentColor = image.color;
        transparentColor.a = 0;

        if (fadeInOnStart) {
            image.color = opaqueColor;
        }

    }

    private void Start() {
        if (fadeInOnStart) {
            Invoke(nameof(FadeIn), delayAfterStart);
        }
    }

    public void FadeIn() {
        StartCoroutine(FadeRoutine(true));
    }

    public void FadeOut() {
        StartCoroutine(FadeRoutine(false));
    }

    private IEnumerator FadeRoutine(bool isFadeIn) {

        countDown = time;
        image.color = isFadeIn ? opaqueColor : transparentColor;
        Color transitionColor = image.color;

        while (countDown > 0) {

            countDown -= Time.deltaTime;

            if (isFadeIn)
                transitionColor.a = countDown / time;
            else
                transitionColor.a = 1 - (countDown / time);

            image.color = transitionColor;
            yield return null;

        }

        if (isFadeIn) {
            onFadeInComplete?.Invoke();
            onFadeInComplete = null;
        } else {
            onFadeOutComplete?.Invoke();
            onFadeInComplete = null;
        }

    }

}