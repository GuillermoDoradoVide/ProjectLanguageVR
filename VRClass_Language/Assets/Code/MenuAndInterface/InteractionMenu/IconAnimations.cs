using UnityEngine;
using System.Collections;

public class IconAnimations : MonoBehaviour {

	public RectTransform iconRectTransform;
	public Vector3 scaleVector = new Vector3(1f, 1f, 1f);
	public Vector3 scaleOrigin = new Vector3(1f, 1f, 1f);
	public Vector3 initPos;
	public Vector3 finalPos;
	public Transform activePos;
	public Transform restPos;
	public float scaleSpeed;
	public float slerpScaleRange;
	public float translationSpeed;
	public float slerpTranslationRange;

	private void Awake () {
		iconRectTransform = GetComponent<RectTransform> ();
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
			finalPos = activePos.localPosition;
			initPos = restPos.localPosition;
		}else {
			finalPos = restPos.localPosition;
			initPos = activePos.localPosition;
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
