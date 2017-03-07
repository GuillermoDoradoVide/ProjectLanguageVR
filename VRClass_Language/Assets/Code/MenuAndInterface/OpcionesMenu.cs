using UnityEngine;
using System.Collections;

public class OpcionesMenu : MonoBehaviour, IElement, IMenu
{
	public MenuAnimationController menuAnimationController;
	public float timer;
	public float speed;
	public Transform transform;
	public Transform pivotPoint;
	public GameObject menu;

	private void Awake()
	{
		menuAnimationController = GetComponent<MenuAnimationController>();
		menuAnimationController.setShowAnimation = showAnimation;
		menuAnimationController.setHideAnimation = hideAnimation;
		menuAnimationController.setSelectAnimation = selectAnimation;
	}

	private void OnEnable()
	{
		Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
	}

	private void OnDisable()
	{
		Debug.Log("Se DESactiva el objeto: [" + gameObject.name + "]");
	}

	//IElement interface implementation
	//**********************************
	public void closeThisMenu()
	{
		menu.SetActive(false);
	}

	public void hoverElement()
	{
		if (!menuAnimationController.animationIsPlaying)
		{
			hoverEffect();
		}
	}

	public void selectElement()
	{
		if (menu.activeSelf) {
			setHideAnimation ();
		}
		else{
			menu.SetActive (true);
			setShowAnimation ();
		}

	}

	public void resetElement()
	{
	}
	//**********************************************************************

	private void setShowAnimation()
	{
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
		menuAnimationController.animationIsPlaying = true;
		timer = 0;
	}

	private void setSelectAnimation()
	{
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Select;
		menuAnimationController.animationIsPlaying = true;
		timer = 0;
	}

	private void setHideAnimation()
	{
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
		menuAnimationController.animationIsPlaying = true;
		timer = 0;
	}

	private void showAnimation()
	{
		if (timer > 1) {
			timer = 1;
			menuAnimationController.animationIsPlaying = false;
		}
		transform.localScale = (Vector3.Lerp (transform.localScale, Vector3.one, timer * 0.8f));
		timer += Time.deltaTime * speed;
	}

	private void hideAnimation()
	{
		if (timer > 1) {
			timer = 1;
			menuAnimationController.animationIsPlaying = false;
		}
		else {
			timer += Time.deltaTime * speed;
		}
		transform.localScale = (Vector3.Lerp (transform.localScale, Vector3.zero, timer * 0.8f));
		if(timer == 1) {
			closeThisMenu ();
		}
	}

	private void selectAnimation()
	{
	}

	public void hoverEffect()
	{
	}
}