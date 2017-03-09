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

	private void Onclick() {
		hidePanel ();
	}

	public void showPanel() {
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
		gameObject.SetActive (false);
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
		if (activePosition) {
			finalPos = new Vector3 (initPos.x, initPos.y, initPos.z + hoverOverUIAmmount);
		}else {
			finalPos = new Vector3 (initPos.x, initPos.y, initPos.z - hoverOverUIAmmount);
		}
		StartCoroutine (smoothTranslation());
	}

	private IEnumerator smoothTranslation() {
		slerpTranslationRange = 0;
		while (iconRectTransform.localPosition != finalPos) {
			iconRectTransform.localPosition = Vector3.Lerp (initPos, finalPos,  slerpTranslationRange);
			slerpTranslationRange += Time.deltaTime * translationSpeed;
			if (slerpTranslationRange > 1)
				slerpTranslationRange = 1;
			yield return null;
		}
	}

}
