using UnityEngine;
using System.Collections;

public class IconAnimations : MonoBehaviour {

	public RectTransform iconRectTransform;
	public Vector3 scaleVector = new Vector3(1f, 1f, 1f);
	public Vector3 scaleOrigin = new Vector3(1f, 1f, 1f);
	public Vector3 initPos;
	public Vector3 finalPos;
	public float scaleSpeed;
	public float slerpScaleRange;
	public float translationSpeed;
	public float slerpTranslationRange;
	public float hoverOverUIAmmount;
	public CanvasGroup canvasGroup;
	public float transitionSpeed;
	public bool isShowing = false;

	private void Awake () {
		iconRectTransform = GetComponent<RectTransform> ();
		canvasGroup = GetComponent<CanvasGroup> ();
		initPos = iconRectTransform.localPosition;
	}

	private void OnEnable()
	{
		initPos = iconRectTransform.localPosition;
		showPanel ();
		Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
	}

	private void OnDisable()
	{
		Debug.Log("Se DESactiva el objeto: [" + gameObject.name + "]");
	}

	public void Onclick() {
		selectPanel ();
	}

	private void selectPanel() {
		Invoke ("hidePanel", 1);
	}

	public void showPanel() {
		isShowing = true;
		StartCoroutine(showAnimation ());
	}

	public void hidePanel() {
		if(gameObject.activeSelf) {
			isShowing = false;
			StartCoroutine(hideAnimation ());
		}
	}

	private void deactiveMenu () {
		gameObject.SetActive (false);
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
		yield return new WaitForSeconds (1.2f);
		deactiveMenu ();
	}

	public void scaleIcon(float factor) {
		scaleVector.x = factor;
		scaleVector.y = factor;
		scaleVector.z = factor;
		smoothScale ();
	}

	private void smoothScale() {
		scaleOrigin = iconRectTransform.localScale;
		StartCoroutine (calculateScale());
	}

	private IEnumerator calculateScale()  {
		slerpScaleRange = 0;
		while (iconRectTransform.localScale != scaleVector) {
			iconRectTransform.localScale = Vector3.Slerp (scaleOrigin, scaleVector, slerpScaleRange);
			slerpScaleRange += Time.deltaTime * scaleSpeed;
			if (slerpScaleRange > 1)
				slerpScaleRange = 1;
			yield return null;
		}
	}

	public void translateIcon(bool activePosition) {
//		if (activePosition) {
//			finalPos = new Vector3 (initPos.x, initPos.y, initPos.z + hoverOverUIAmmount);
//		}else {
//			finalPos = new Vector3 (initPos.x, initPos.y, initPos.z - hoverOverUIAmmount);
//		}
//		StartCoroutine (smoothTranslation());
	}

	private IEnumerator smoothTranslation() {
		slerpTranslationRange = 0;
		while (iconRectTransform.localPosition != finalPos) {
			iconRectTransform.localPosition = Vector3.Lerp (initPos, finalPos,  slerpTranslationRange);
			slerpTranslationRange += Time.deltaTime * translationSpeed;
			if (slerpTranslationRange > 1) {
				slerpTranslationRange = 1;
				iconRectTransform.localPosition = Vector3.Lerp (initPos, finalPos,  slerpTranslationRange);
			}
			yield return null;
		}
	}

}
