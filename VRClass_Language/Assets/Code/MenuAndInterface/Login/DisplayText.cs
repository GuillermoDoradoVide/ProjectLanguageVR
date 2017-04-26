using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DisplayText : MonoBehaviour {

    public string text;
    public Text referenceText;
    public CanvasGroup canvasGroup;
    public bool isShowing = false;
    public float transitionSpeed;


    private void Start()
    {
    }
	
    [ContextMenu("changeText")]
    public void changeText()
    {
        StartCoroutine(changeTextAnimation());
    }

    private IEnumerator changeTextAnimation()
    {
        yield return (hideAnimation());
        referenceText.text = text;
        yield return (showAnimation());
    }

    private IEnumerator showAnimation()
    {
        isShowing = true;
        while (canvasGroup.alpha < 1)
        {
            if (!isShowing)
                yield break;
            canvasGroup.alpha += Time.deltaTime * transitionSpeed;
            yield return null;
        }
        canvasGroup.alpha = 1;
    }

    private IEnumerator hideAnimation()
    {
        isShowing = false;
        while (canvasGroup.alpha > 0)
        {
            if (isShowing)
                yield break;
            canvasGroup.alpha -= Time.deltaTime * transitionSpeed;
            yield return null;
        }
        canvasGroup.alpha = 0;
    }


}
