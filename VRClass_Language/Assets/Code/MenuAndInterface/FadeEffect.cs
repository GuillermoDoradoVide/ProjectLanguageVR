using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {

	public float fadeSpeed = 1.5f;
	public float new_alpha_color;
	public Image fadeImage;
	public Color fadeColor;
	public Color origin;

	void Awake() {
		fadeImage = GetComponentInChildren<Image> ();
		fadeColor = fadeImage.color;
		origin = fadeColor;
	}

	// Use this for initialization
	void Start () {
		fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width + 25, Screen.height + 25);
	}

	public bool fadeIn() {
		new_alpha_color = fadeColor.a;
		new_alpha_color -= fadeSpeed * Time.deltaTime;
		if (new_alpha_color < 0) {
			return true;
		}
		else {
			fadeColor.a = new_alpha_color;
			fadeImage.color = fadeColor;
			return false;
		}
	}

	public bool fadeOut () {
		new_alpha_color = fadeColor.a;
		new_alpha_color += fadeSpeed * Time.deltaTime;
		if (new_alpha_color > 1) {
			fadeColor.a = 1;
			fadeImage.color = fadeColor;
			return true;
		} else {
			fadeColor.a = new_alpha_color;
			fadeImage.color = fadeColor;
			return false;
		}
	}
}
