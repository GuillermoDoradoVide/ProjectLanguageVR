using UnityEngine;
using System.Collections;

public class LookActionMenu : MonoBehaviour, IElement, IMenu {

	public MenuAnimationController menuAnimationController;
	public float timer;
	public float speed;

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
		setShowAnimation();
	}

	private void OnDisable()
	{
		Debug.Log("Se DESactiva el objeto: [" + gameObject.name + "]");
	}

	void Start()
	{
	}

	void Update()
	{
	}

	//IElement interface implementation
	//**********************************
	public void closeThisMenu()
	{
		gameObject.SetActive(false);
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
		if (gameObject.activeSelf) {
			setHideAnimation ();
		}
		else{
			gameObject.SetActive (true);
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