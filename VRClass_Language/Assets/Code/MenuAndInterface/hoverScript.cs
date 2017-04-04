using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hoverScript : MonoBehaviour {

    public Color original;
    public Color hover;
	public Image image;

    private void Awake()
    {
		image = GetComponent<Image> ();
    }

    public void Onhover()
    {
		image.color = hover;
    }

    public void exitHover()
    {
		image.color = original;
    }
}
