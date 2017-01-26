using UnityEngine;
using System.Collections;

public class ObjectInspector : MonoBehaviour, IRotation {

    public float rotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void rotateElement(Vector2 rotation)
    {
        transform.RotateAround(transform.position, new Vector3(-rotation.y, -rotation.x, 0), Mathf.Abs(rotation.magnitude + Time.deltaTime * rotationSpeed));
    }
}
