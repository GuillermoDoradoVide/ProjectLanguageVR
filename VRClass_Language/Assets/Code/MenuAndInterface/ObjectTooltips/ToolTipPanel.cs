using UnityEngine;
using System.Collections;

public class ToolTipPanel : MonoBehaviour {
	
	public MenuAnimationController menuAnimationController;
	public CanvasGroup toolTipCanvasGroup;
	private RectTransform canvasRectTransform;
	public float timer = 1.0f;
	public float transitionSpeed;

	void Start () {
		menuAnimationController.setShowAnimation = showAnimation;
		menuAnimationController.setHideAnimation = hideAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setShowPanel() {
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
		menuAnimationController.animationIsPlaying = true;
	}

	public void setHidePanel() {
		menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
		menuAnimationController.animationIsPlaying = true;
	}

	private void showAnimation()
	{
		if(toolTipCanvasGroup.alpha < 1)
		{
			toolTipCanvasGroup.alpha += Time.deltaTime * transitionSpeed;
		}
		else
		{
			toolTipCanvasGroup.alpha = 1;
			menuAnimationController.animationIsPlaying = false;
		}
	}

	private void hideAnimation()
	{
		if (toolTipCanvasGroup.alpha > 0)
		{
			toolTipCanvasGroup.alpha -= Time.deltaTime * transitionSpeed;
		}
		else
		{
			toolTipCanvasGroup.alpha = 0;
			menuAnimationController.animationIsPlaying = false;
			//gameObject.SetActive(false);
		}
	}
}
