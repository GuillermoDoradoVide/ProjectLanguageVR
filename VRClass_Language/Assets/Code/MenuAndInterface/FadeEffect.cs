using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {

	public float fadeSpeed;
	private float new_alpha_color = 1;
	public Image fadeImage;
	public Color currentFadeColor;
	public Color originColor;
    public bool isFadingIn;

	private void Awake() {
        isFadingIn = true;
        fadeImage = GetComponentInChildren<Image> ();
		currentFadeColor = fadeImage.color;
		originColor = currentFadeColor;
		fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width + 25, Screen.height + 25);
	}

	public void setFadeIn() {
		new_alpha_color = 1;
        isFadingIn = true;
        StartCoroutine(fadeIn());
    }

	public void setFadeOut() {
		new_alpha_color = 0;
        isFadingIn = false;
        StartCoroutine(fadeOut());
    }

    private IEnumerator fadeIn()
    {
        while (new_alpha_color > 0)
        {
            if (!isFadingIn)
                yield break;
            currentFadeColor.a = new_alpha_color;
            fadeImage.color = currentFadeColor;
            new_alpha_color -= fadeSpeed * Time.deltaTime;
            yield return null;
        }
        currentFadeColor.a = 0;
        fadeImage.color = currentFadeColor;  
        new_alpha_color = 0;
        gameObject.SetActive(false);
    }

    private IEnumerator fadeOut()
    {
        while(new_alpha_color < 1)
        {
            if (isFadingIn)
                yield break;
            currentFadeColor.a = new_alpha_color;
            fadeImage.color = currentFadeColor;
            new_alpha_color += fadeSpeed * Time.deltaTime;

            yield return null;
        }
        currentFadeColor.a = 1;
        fadeImage.color = currentFadeColor;
        new_alpha_color = 1;
    }
}
