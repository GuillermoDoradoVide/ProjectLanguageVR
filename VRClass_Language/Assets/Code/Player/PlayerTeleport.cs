using UnityEngine;
using System.Collections;

public class PlayerTeleport : MonoBehaviour {

	Transform teleportPosition;
	private void Awake() {
		EventManager.addTeleportListener (teleport);
	}

	private void OnDisable() {
		EventManager.removeTeleportListener (teleport);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void teleport(Transform positionToTeleport) {
		teleportPosition = positionToTeleport;
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("teleportPlayer", 1);
	}

	private void teleportPlayer() {
		transform.position = new Vector3 (teleportPosition.position.x, transform.position.y , teleportPosition.position.z);
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeIn);
	}
}
