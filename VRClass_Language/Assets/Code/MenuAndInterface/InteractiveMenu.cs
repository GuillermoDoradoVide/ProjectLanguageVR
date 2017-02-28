using UnityEngine;
using System.Collections;

public class InteractiveMenu : MonoBehaviour, IElement, IMenu
{
	public MenuAnimationController menuAnimationController;
	public float timer = 2.0f;
	public float speed = 2.0f;
	public GameObject butonIcon;

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
		setSelectAnimation ();
		Invoke ("selected", 2);
	}

	public void resetElement()
	{
		setHideAnimation();
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
			timer = 2.0f;
		}
		else
		{
			butonIcon.transform.localPosition = Vector3.MoveTowards(butonIcon.transform.localPosition, new Vector3(butonIcon.transform.localPosition.x, butonIcon.transform.localPosition.y, 0.0f), Time.deltaTime * speed);
			timer -= Time.deltaTime;
		}
	}

	private void hideAnimation()
	{
		if (timer < 2)
		{
			menuAnimationController.animationIsPlaying = false;
			timer = 2.0f;
		}
		else
		{
			butonIcon.transform.localPosition = Vector3.Lerp(butonIcon.transform.localPosition, new Vector3(butonIcon.transform.localPosition.x, butonIcon.transform.localPosition.y, 0.03f),Time.deltaTime * speed);
			timer -= Time.deltaTime;
		}
	}

	private void selectAnimation()
	{
		if (timer < 0)
		{
			menuAnimationController.animationIsPlaying = false;
			timer = 2.0f;
		}
		else
		{
			butonIcon.transform.localPosition = Vector3.Lerp(butonIcon.transform.localPosition, new Vector3(butonIcon.transform.localPosition.x, butonIcon.transform.localPosition.y, 0.06f), Time.deltaTime * speed);
			timer -= Time.deltaTime;
		}
	}

	private void hoverEffect()
	{
	}

	private void selected() {
		setHideAnimation ();
		closeThisMenu ();
	}
}
