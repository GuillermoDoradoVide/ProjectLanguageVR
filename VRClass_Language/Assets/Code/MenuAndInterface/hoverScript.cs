using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hoverScript : MonoBehaviour {

    public Color original;
    public Color hover;

    private void Awake()
    {

    }

    public void Onhover()
    {
        GetComponent<Image>().color = hover;
    }

    public void exitHover()
    {
        GetComponent<Image>().color = original;
    }
}
