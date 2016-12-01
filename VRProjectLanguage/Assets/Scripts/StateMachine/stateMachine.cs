using UnityEngine;
using System.Collections;

public class StateMachine : MonoBehaviour {
    public stateScript _state;
	// Update is called once per frame
	void Update () {
        _state.doUpdate();
	}
}
