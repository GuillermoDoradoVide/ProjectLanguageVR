using UnityEngine;
using System.Collections;

public class MissionBriefing_1 : StateScript {

	public CharacterManager characterManager;
	public AudioClip[] firstAudio;
	public CharacterManager.CharacterState[] RotateB;
	public Transform[] rotateTo;

	public RotateHologram _hologram;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
		CurrentStep ();
	}

	private void startBriefing() {
		characterManager.setCharacterNextStates (RotateB);
		characterManager.setWaypoints (rotateTo);
		CurrentStep = first;
		_hologram.gameObject.SetActive (true);
		_hologram.showHologram ();
		characterManager.setDialogs (firstAudio);
		characterManager.setTalking ();
	}

	private void first () {
		_hologram.rotateHologram ();
	}

	private void waitForPlayer() {

	}

	public override void atInit()
	{
		CurrentStep = startBriefing;
	}

	public override void atEnd()
	{
	}

	public override void atPause()
	{
		//throw new NotImplementedException();
	}

	public override void atReadyActiveState()
	{
		//throw new NotImplementedException();
	}
}
