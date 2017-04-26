using UnityEngine;
using System.Collections;

public class BossOfficeLobby : StateScript {

	public InteractionMenuController menuController;
	private delegate void Steps();
	private Steps Step;

	void Start()
	{
	}

	// Update is called once per frame
	public override void atUpdate()
	{
	}

	private void ShowLobbyOptions() {
		menuController.addDialogTriggerAction (0,"Go to the lab.",loadLabLevel);
	}

	private void loadLabLevel() {
		EventManager.triggerEvent (Events.EventList.PLAYER_FadeOut);
		Invoke ("changeScene", 2);
	}

	private void changeScene() {
		SceneController.Instance.SwitchScene ("Laboratory");
	}

	public override void atInit()
	{
		ShowLobbyOptions ();
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
