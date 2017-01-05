using UnityEngine;
using System.Collections;

public class MenuAnimationController : MonoBehaviour {
    private enum AnimationActions { Show, Hide, Idle, Count };
    private AnimationActions animationActions;
    public delegate void DoMenuAnimations();
    public DoMenuAnimations[] doMenuAnimation;
    public DoMenuAnimations setShowAnimation, setHideAnimation, setIdleAnimation;

    private void Awake()
    {
        doMenuAnimation = new DoMenuAnimations[(int)AnimationActions.Count];
        setShowAnimation = null;
        setHideAnimation = null;
        setIdleAnimation = null;
        //active and set each delegate
        animationActions = AnimationActions.Hide;
        doMenuAnimation[(int)AnimationActions.Show] = setShowAnimation;
        doMenuAnimation[(int)AnimationActions.Hide] = setHideAnimation;
        doMenuAnimation[(int)AnimationActions.Idle] = setIdleAnimation;
    }
    // Use this for initialization
    void Start () {
	
	}
	
	public void playAnimation()
    {
        if (doMenuAnimation[(int)animationActions] != null)
        {
            doMenuAnimation[(int)animationActions]();
        }
    }
}
