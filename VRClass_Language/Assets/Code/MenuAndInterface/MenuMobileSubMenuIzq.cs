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
	public GameObject mobile;
	public Vector3 onPosition;
	public Vector3 origin;

	private void Awake()
	{
		menuAnimationController = GetComponent<MenuAnimationController>();
		menuAnimationController.setShowAnimation = showAnimation;
		menuAnimationController.setHideAnimation = hideAnimation;
		menuAnimationController.setSelectAnimation = selectAnimation;
		origin = mobile.transform.localPosition;
		onPosition = new Vector3 (onPosition.x - 0.1f, onPosition.y, onPosition.z);
	}

	private void OnEnable()
	{
		Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
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

	public void closeMenu()
	{
		gameObject.SetActive(false);
	}

	public void hideMenu (){
	}
	public void selectMenu (){
	}
	public void hoverMenu(){
	}
	public void resetMenu(){
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
		mobile.transform.localPosition = Vector3.Slerp (origin, onPosition , timer * 1.2f);
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
		mobile.transform.localPosition = Vector3.Slerp (onPosition, origin , timer * 1.2f);
		if(timer == 1) {
			closeMenu ();
		}
	}

	private void selectAnimation()
	{
	}

	public void hoverEffect()
	{
	}
}