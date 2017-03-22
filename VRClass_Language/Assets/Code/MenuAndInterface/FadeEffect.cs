using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeEffect : MonoBehaviour {

	public float fadeSpeed;
	private float new_alpha_color = 1;
	public Image fadeImage;
	public Color currentFadeColor;
	public Color originColor;
	public enum fadeType
	{
		FIn, FOut
	};
	public fadeType type;

	private void Awake() {
		fadeImage = GetComponentInChildren<Image> ();
		currentFadeColor = fadeImage.color;
		originColor = currentFadeColor;
		fadeImage.rectTransform.sizeDelta = new Vector2(Screen.width + 25, Screen.height + 25);
	}

	// Use this for initialization
	private void Start () {
		
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
		new_alpha_color = 1;
		type = FadeEffect.fadeType.FIn;
	}

	public void setFadeOut() {
		new_alpha_color = 0;
		type = FadeEffect.fadeType.FOut;
	}

	private void fadeIn() {
		if (new_alpha_color < 0) {
			currentFadeColor.a = 0;
			fadeImage.color = currentFadeColor;
			gameObject.SetActive (false);
		}
		else {
			currentFadeColor.a = new_alpha_color;
			fadeImage.color = currentFadeColor;
		}
		new_alpha_color -= fadeSpeed * Time.deltaTime;
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
