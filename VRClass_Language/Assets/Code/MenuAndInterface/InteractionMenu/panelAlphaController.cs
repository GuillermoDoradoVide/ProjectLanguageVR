using UnityEngine;
using System.Collections;

public class panelAlphaController : MonoBehaviour {

	public CanvasGroup canvasGroup;
	public GameObject canvasGameObject;
	public float transitionSpeed;

	private void Awake() {
		canvasGameObject = canvasGroup.gameObject;
	}

	public void showPanel() {
		canvasGameObject.SetActive (true);
		StartCoroutine(showAnimation ());
	}

	public void hidePanel() {
		StartCoroutine(hideAnimation ());
	}

	private IEnumerator showAnimation()
	{
		while(canvasGroup.alpha < 1) {
			canvasGroup.alpha += Time.deltaTime * transitionSpeed;
			yield return null;
		}
		canvasGroup.alpha = 1;
	}

	private IEnumerator hideAnimation()
	{
		while(canvasGroup.alpha > 0) {
			canvasGroup.alpha -= Time.deltaTime * transitionSpeed;
			yield return null;
		}
		canvasGroup.alpha = 0;
		canvasGameObject.SetActive (false);
	}
}
