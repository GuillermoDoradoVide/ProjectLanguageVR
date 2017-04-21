using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ShowAndHideWithAlpha : MonoBehaviour {

    public CanvasGroup canvasGroup;
    [Header("UI variables")]
    public bool isShowing = false;
    public float transitionSpeed;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    // Use this for initialization
    void Start () {
	
	}

    private void OnEnable()
    {
        //initPos = iconRectTransform.localPosition;
        showPanel();
        Debug.Log("Se activa el objeto: [" + gameObject.name + "]");
    }

    private void OnDisable()
    {
        Debug.Log("Se DESactiva el objeto: [" + gameObject.name + "]");
        StopAllCoroutines();
    }

    public void showPanel()
    {
        isShowing = true;
        StartCoroutine(showAnimation());
    }

    public void hidePanel()
    {
        if (gameObject.activeInHierarchy)
        {
            isShowing = false;
            StartCoroutine(hideAnimation());
        }
        else
        {
            isShowing = false;
            canvasGroup.alpha = 0;
            deactiveMenu();
        }
    }

    private void deactiveMenu()
    {
        gameObject.SetActive(false);
    }

    private IEnumerator showAnimation()
    {
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
        while (canvasGroup.alpha > 0)
        {
            if (isShowing)
                yield break;
            canvasGroup.alpha -= Time.deltaTime * transitionSpeed;
            yield return null;
        }
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1.2f);
        deactiveMenu();
    }

}
