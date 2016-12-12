using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

    private Material material;
    private Color normal;
    public Color hightlight;
    public bool isHover;
    void Awake ()
    {
        material = GetComponent<MeshRenderer>().material;
        normal = material.color;
    }

	// Use this for initialization
	void Start () {
	}

    public void hover()
    {
        material.color = hightlight;
        isHover = true;
    }

    public void changeToNormal()
    {
        material.color = normal;
    }

    // Update is called once per frame
    void Update () {
        if (!isHover) { changeToNormal(); }
        isHover = false;
        

    }
}
