using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ShowAndHideAgentName : MonoBehaviour {
    public string currentName;
    public Text referenceText;
    public CanvasGroup canvasGroup;
    public bool isShowing = false;
    public float transitionSpeed;

    public void changeNameColorDisplay()
    {
        referenceText.color = Color.red;
    }

    public void resetNameColorDisplay()
    {
        referenceText.color = Color.black;
    }


    [ContextMenu("changeText")]
    public void changeText(string name)
    {
        currentName = name;
        StartCoroutine(changeTextAnimation());
    }

    private IEnumerator changeTextAnimation()
    {
        referenceText.gameObject.SetActive(true);
        referenceText.text = currentName;
        yield return (showAnimation());
    }

    public void hideText()
    {
        StartCoroutine(hideAnimation());
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
