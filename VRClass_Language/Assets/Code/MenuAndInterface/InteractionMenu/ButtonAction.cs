using UnityEngine;
using UnityEngine.Events;
using System.Collections;

public class ButtonAction : MonoBehaviour {
	public delegate void Action();
	public Action action;

	public void doAction() {
		if (action != null)
			action();
	}
}
