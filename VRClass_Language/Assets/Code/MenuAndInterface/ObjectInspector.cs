using UnityEngine;
using System.Collections;

public class ObjectInspector : MonoBehaviour, IRotation, IMove {

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

    public void setMovementParentObject(GameObject reticle)
    {
        transform.SetParent(reticle.transform);
    }

    public void clearMovementParentObject()
    {
        transform.parent = null;
    }
}
