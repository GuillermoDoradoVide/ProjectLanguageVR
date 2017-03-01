using UnityEngine;
using System.Collections;

public class MenuMobileSubMenuIzq : MonoBehaviour, IElement, IMenu
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
		//setShowAnimation();
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
	}

	private void setSelectAnimation()
	{
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Select;
		menuAnimationController.animationIsPlaying = true;
	}

	private void setHideAnimation()
	{
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
		menuAnimationController.animationIsPlaying = true;
	}

	private void showAnimation()
	{
		if (timer < 0)
		{
			menuAnimationController.animationIsPlaying = false;
			transform.localScale = Vector3.one;
			timer = 2.0f;
		}
		else
		{
			transform.localScale = (Vector3.Lerp (transform.localScale, Vector3.one, Time.deltaTime * speed));
			timer -= Time.deltaTime;
		}
	}

	private void hideAnimation()
	{
		if (timer < 0)
		{
			menuAnimationController.animationIsPlaying = false;
			transform.localScale = Vector3.zero;
			timer = 2.0f;
			closeThisMenu ();
		}
		else
		{
			transform.localScale = (Vector3.Lerp (transform.localScale, Vector3.zero, Time.deltaTime * speed));
			timer -= Time.deltaTime;
		}
	}

	private void selectAnimation()
	{
	}

	private void hoverEffect()
	{
	}
}