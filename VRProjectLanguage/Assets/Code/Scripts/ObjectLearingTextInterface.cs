using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ObjectLearingTextInterface : MonoBehaviour {

    public Transform toolTipDisplayPosition;
    public string text;

    void Awake ()
    {
        text = transform.parent.gameObject.name;
    }
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }



}
