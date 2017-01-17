using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectToolTip : MonoBehaviour {

    public float minWidth;
    public float maxWidth;
    public float minHeight;
    public float maxHeight;
    public int minTextSize;
    public int maxTextSize;
    public float timer = 1.0f;

    public bool disableTooltip = true;

    public MenuAnimationController menuAnimationController;
    
    public CanvasGroup toolTipCanvasGroup;
    private Text toolTipText;
    private RectTransform canvasRectTransform;
    public float transitionSpeed;
    //IElement interface implementation
    //**********************************
    

    private void OnEnable()
    {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
        menuAnimationController.animationIsPlaying = true;
    }

    private void OnDisable()
    {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
        menuAnimationController.animationIsPlaying = true;
    }
    // Use this for initialization
    void Start () {
        toolTipCanvasGroup = GetComponent<CanvasGroup>();
        toolTipText = GetComponentInChildren<Text>();
        canvasRectTransform = GetComponent<RectTransform>();
        menuAnimationController = GetComponent<MenuAnimationController>();
        menuAnimationController.setShowAnimation = showAnimation;
        menuAnimationController.setHideAnimation = hideAnimation;
    }

    private void Update()
    {
        if (disableTooltip)
        {
            menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Hide;
            menuAnimationController.animationIsPlaying = true;
        }
        disableTooltip = true;
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
            gameObject.SetActive(false);
        }
    }


}
