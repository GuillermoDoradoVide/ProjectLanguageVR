using UnityEngine;
using System.Collections;

public class PetCharacterController : MonoBehaviour {

    public StateMachine _PetStateMachine;
    public GameObject _Pet;
	// Use this for initialization
	void Start () {
        _PetStateMachine = GetComponent<StateMachine>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey) Application.Quit();
	}
}
