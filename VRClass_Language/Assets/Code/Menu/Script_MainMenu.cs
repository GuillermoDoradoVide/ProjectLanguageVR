using UnityEngine;
using System.Collections;

public class Script_MainMenu : MonoBehaviour {
    public MenuAnimationController menuAnimationController;
	// Use this for initialization
	void Start () {
        menuAnimationController = GetComponent<MenuAnimationController>();
        menuAnimationController.setShowAnimation = showAnimation;
    }
	
	// Update is called once per frame
	void Update () {
        menuAnimationController.animationActions = MenuAnimationController.AnimationActions.Show;
        menuAnimationController.SetShowAnimation = showAnimation;
    }

    private void showAnimation ()
    {
        Debug.Log("hola");
        this.gameObject.transform.Translate(0, 0.5f, 0);
    }
}
