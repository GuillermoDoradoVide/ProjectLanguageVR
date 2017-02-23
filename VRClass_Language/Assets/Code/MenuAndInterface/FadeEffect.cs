using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {

	private float fadeSpeed = 1.5f;
	private float new_alpha_color;
	public Image fadeImage;
	public Color currentFadeColor;
	public Color originColor;
	public enum fadeType
	{
		FIn, FOut
	};
	private fadeType type;

	private void Awake() {
		fadeImage = GetComponentInChildren<Image> ();
		currentFadeColor = fadeImage.color;
		originColor = currentFadeColor;
	}

	// Use this for initialization
	private void Start () {
		fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width + 25, Screen.height + 25);
	}

	private void Update() {
		fader ();
	}

	private void fader () {
		switch (type) {
			case fadeType.FIn: {
				fadeIn ();
				break;
			}
		case fadeType.FOut: {
				fadeOut ();
				break;
			}
		}
	}

	public void setFadeIn() {
		type = FadeEffect.fadeType.FIn;
		new_alpha_color = 1;
	}

	public void setFadeOut() {
		type = FadeEffect.fadeType.FOut;
		new_alpha_color = 0;
	}

	private void fadeIn() {
		new_alpha_color -= fadeSpeed * Time.deltaTime;
		if (new_alpha_color < 0) {
			
			gameObject.SetActive (false);
		}
		else {
			currentFadeColor.a = new_alpha_color;
			fadeImage.color = currentFadeColor;
		}
	}

	private void fadeOut () {
		new_alpha_color += fadeSpeed * Time.deltaTime;
		if (new_alpha_color > 1) {
			currentFadeColor.a = 1;
			fadeImage.color = currentFadeColor;
			//gameObject.SetActive (false);
		} else {
			currentFadeColor.a = new_alpha_color;
			fadeImage.color = currentFadeColor;
		}
	}
}
