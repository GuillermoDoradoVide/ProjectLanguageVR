using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ToolTipPanel : MonoBehaviour {
	
	public MenuAnimationController menuAnimationController;
	public CanvasGroup toolTipCanvasGroup;
	private RectTransform canvasRectTransform;

	public Text name;
	public float timer = 1.0f;
	public float transitionSpeed;

	void Start () {
		menuAnimationController.setShowAnimation = showAnimation;
		menuAnimationController.setHideAnimation = hideAnimation;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void updatePanelInfo(ObjectToolTipData toolTipObject) {
		name.text = toolTipObject.itemData.getItemData().name;
		toolTipCanvasGroup.transform.position = new Vector3 (toolTipObject.gameObject.transform.position.x , toolTipObject.gameObject.GetComponent<MeshRenderer>().bounds.max.y + 0.5f, toolTipObject.gameObject.transform.position.z);
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
