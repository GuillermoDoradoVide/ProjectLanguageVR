using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ToolTipCanvasScript : MonoBehaviour
{

    public bool animationIsPlaying = false;
    public PlayerInteractions playerInteractions;
    private enum AnimationActions { Show, Hide, Count };
    private AnimationActions animationActions;
    public delegate void DoMenuAnimations();
    public DoMenuAnimations[] doMenuAnimation;
    public Canvas toolTipCanvas;
    private CanvasGroup toolTipCanvasGroup;
    public float transitionSpeed;
    private Text toolTipText;

    public float nearWidth;
    public float nearHeight;
    public int nearTextSize;

    public float mediumWidth;
    public float mediumHeight;
    public int mediumTextSize;

    public float farWidth;
    public float farHeight;
    public int farTextSize;

    private RectTransform canvasRectTransform;

    void Awake()
    {
        doMenuAnimation = new DoMenuAnimations[(int)AnimationActions.Count]; // init array of delegates
        // Set each action delegate
        animationActions = AnimationActions.Hide;
        doMenuAnimation[(int)AnimationActions.Show] = showAnimation;
        doMenuAnimation[(int)AnimationActions.Hide] = hideAnimation;
        toolTipCanvasGroup = toolTipCanvas.GetComponent<CanvasGroup>();
        toolTipText = GetComponentInChildren<Text>();
        canvasRectTransform = toolTipCanvas.GetComponent<RectTransform>(); ;
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInteractions.displayToolTip)
        {
            checkAnimation(AnimationActions.Show);
        }
        else
        {
            Debug.Log("entra a hacerlo");
            checkAnimation(AnimationActions.Hide);
        }
        if (animationIsPlaying)
        {
            if (doMenuAnimation[(int)animationActions] != null)
            {
                doMenuAnimation[(int)animationActions]();
            }
        }
    }

    public void showAnimation()
    {
        if (toolTipCanvasGroup.alpha < 1)
        {
            toolTipCanvasGroup.alpha += Time.deltaTime * transitionSpeed;
        }
        else
        {
            toolTipCanvasGroup.alpha = 1;
            animationIsPlaying = false;
        }
    }

    public void hideAnimation()
    {
        if (toolTipCanvasGroup.alpha > 0)
        {
            toolTipCanvasGroup.alpha -= Time.deltaTime * transitionSpeed;
        }
        else
        {
            toolTipCanvasGroup.alpha = 0;
            animationIsPlaying = false;
            gameObject.SetActive(false);
        }
    }

    private void checkAnimation(AnimationActions animAction)
    {
        if (!animationIsPlaying && animationActions != animAction)
        {
            animationIsPlaying = true;
            animationActions = animAction;
        }
    }

    public void changeTextValue(string newText)
    {
        toolTipText.text = newText;
    }

    public void changeSizeValuesMedium()
    {
        canvasRectTransform.sizeDelta = new Vector2(mediumWidth, mediumHeight);
        toolTipText.fontSize = mediumTextSize;
    }

    public void changeSizeValuesNear()
    {
        canvasRectTransform.sizeDelta = new Vector2(nearWidth, nearHeight);
        toolTipText.fontSize = nearTextSize;
    }

    public void changeSizeValuesFar()
    {
        canvasRectTransform.sizeDelta = new Vector2(farWidth, farHeight);
        toolTipText.fontSize = farTextSize;
    }

}
