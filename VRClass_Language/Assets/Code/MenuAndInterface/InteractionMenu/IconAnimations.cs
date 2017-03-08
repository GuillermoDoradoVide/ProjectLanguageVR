using UnityEngine;
using System.Collections;

public class IconAnimations : MonoBehaviour {

	public RectTransform iconRectTransform;
	//	public  enum SCALE_ACTION
	//	{
	//		SCALE_UP, SCALE_DOWN, SCALE_ORIGIN
	//	};
	//	public SCALE_ACTION scaleType;
	public Vector3 scaleVector = new Vector3(1f, 1f, 1f);
	public Vector3 scaleOrigin = new Vector3(1f, 1f, 1f);
	public float scaleSpeed;
	public float slerpScaleRange;

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

}
