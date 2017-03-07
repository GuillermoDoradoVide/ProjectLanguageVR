using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTipPanel : MonoBehaviour {
	
	public MenuAnimationController menuAnimationController;
	public CanvasGroup toolTipCanvasGroup;
	private RectTransform canvasRectTransform;
	//panel info
	public Text name;
	public float timer = 1.0f;
	public float transitionSpeed;

	void Start () {
		menuAnimationController.setShowAnimation = showAnimation;
		menuAnimationController.setHideAnimation = hideAnimation;
	}

	public void updatePanelInfo(ObjectToolTipData toolTipObject) {
		name.text = toolTipObject.itemData.getItemData().name;
		GameObject toolTipGO = toolTipObject.gameObject;
		toolTipCanvasGroup.transform.position = new Vector3 (toolTipGO.transform.position.x , toolTipGO.GetComponent<MeshRenderer>().bounds.max.y + 0.5f, toolTipGO.transform.position.z);
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
		}
	}
}
