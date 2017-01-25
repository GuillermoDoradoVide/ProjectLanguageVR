using UnityEngine;
using System.Collections;

public class ObjectInspector : MonoBehaviour, IRotation {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void rotateElement(Vector2 rotation)
    {
        Debug.Log("entro en el metodo de rotate");
        transform.Rotate(new Vector3(-rotation.y, -rotation.x, 0), Mathf.Abs(rotation.magnitude + Time.deltaTime * 2.0f));
    }
}
