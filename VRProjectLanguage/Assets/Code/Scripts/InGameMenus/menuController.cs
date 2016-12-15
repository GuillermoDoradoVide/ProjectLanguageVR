using UnityEngine;
using System.Collections;

public class menuController : MonoBehaviour {

    private Material material;
    private Color normal;
    public Color hightlight;

    public Camera playerCamera;
    private RaycastHit hit;
    public bool isHover;

    public float timer = 0.0f;
    public float selectTimer;
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
        if (checkIfBeeingSelected()) selected();
    }

    public void changeToNormal()
    {
        material.color = normal;
    }

    public bool checkIfBeeingSelected()
    {
        if (timer < selectTimer)
        {
            timer += Time.deltaTime;
            return false;
        }
        else
        {
            timer = 0.0f;
            return true;
        }
    }

    protected void selected()
    {
        material.color = Color.cyan;
    }

    // Update is called once per frame
    void Update () {
        if (!isHover) { changeToNormal(); }
        isHover = false;
        if (Physics.Raycast(playerCamera.transform.position, playerCamera.transform.forward, out hit))
        {
            if (hit.transform == transform)
            {
                hover();
            }
            else
            {
                changeToNormal();
            }
        }
        else
        {
            changeToNormal();
        }
    }
}
