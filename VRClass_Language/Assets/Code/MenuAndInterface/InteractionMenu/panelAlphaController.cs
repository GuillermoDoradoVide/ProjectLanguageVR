using UnityEngine;
using System.Collections;

public class panelAlphaController : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public GameObject canvasGameObject;
	public float transitionSpeed;
	public bool isShowing = false;

	private void Awake() {
		canvasGameObject = canvasGroup.gameObject;
	}

	public void showPanel() {
		canvasGameObject.SetActive (true);
		isShowing = true;
		StartCoroutine(showAnimation ());
	}

	public void hidePanel() {
		isShowing = false;
		StartCoroutine(hideAnimation ());
	}

	private IEnumerator showAnimation()
	{
		while(canvasGroup.alpha < 1) {
			if (!isShowing)
				yield break;
			canvasGroup.alpha += Time.deltaTime * transitionSpeed;
			yield return null;
		}
		canvasGroup.alpha = 1;
	}

	private IEnumerator hideAnimation()
	{
		while(canvasGroup.alpha > 0) {
			if (isShowing)
				yield break;
			canvasGroup.alpha -= Time.deltaTime * transitionSpeed;
			yield return null;
		}
		canvasGroup.alpha = 0;
		canvasGameObject.SetActive (false);
	}
}
