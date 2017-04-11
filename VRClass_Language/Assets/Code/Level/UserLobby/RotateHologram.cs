using UnityEngine;
using System.Collections;

public class RotateHologram : MonoBehaviour {

	private Transform _T;
	private Vector3 rotationVector;
	public int rotationAngle;
	public Material material;
	public Material Transition;
	public MeshRenderer meshR;
	public Color alpha;
	// Use this for initialization
	void Start () {
		_T = GetComponent<Transform> ();
		rotationVector = Vector3.up;
		meshR = gameObject.GetComponent<MeshRenderer> ();
		gameObject.SetActive (false);
	}

	public void rotateHologram () {
		_T.RotateAround (_T.position,rotationVector , rotationAngle * Time.deltaTime);
	}

	public void showHologram() {
		StartCoroutine (showEffect());
	}

	public void hideHologram() {
		
	}

	private IEnumerator showEffect() {
		alpha = Transition.GetColor ("_TintColor");
		float value = alpha.a;
		meshR.material = Transition;
		bool first = false;
		while (alpha.a < 1) {
			value += Time.deltaTime;
			alpha.a = value;
			Transition.SetColor ("_TintColor", alpha);
			yield return null;
		}
		while (alpha.a > 0) {
			value -= Time.deltaTime * 2;
			alpha.a = value;
			Transition.SetColor ("_TintColor", alpha);
			yield return null;
		}
		while (alpha.a < 0.5f) {
			value += Time.deltaTime;
			alpha.a = value;
			Transition.SetColor ("_TintColor", alpha);
			yield return null;
		}
		while (alpha.a > 0) {
			value -= Time.deltaTime;
			alpha.a = value;
			Transition.SetColor ("_TintColor", alpha);
			yield return null;
		}
		while (alpha.a < 2) {
			value += Time.deltaTime * 2;
			alpha.a = value;
			Transition.SetColor ("_TintColor", alpha);
			yield return null;
		}
		alpha.a = 0;
		Transition.SetColor ("_TintColor", alpha);
		meshR.material = material;
	}
}
