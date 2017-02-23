using UnityEngine;
using System.Collections;

public class EffectManager : SingletonComponent<EffectManager> {

	public FadeEffect fade;

	private void Awake()
	{
		EventManager.startListening(Events.EventList.PLAYER_FadeIn, fadeIn);
		EventManager.startListening(Events.EventList.PLAYER_FadeOut, fadeOut);
	}

	private void OnDisable() {
		EventManager.stopListening(Events.EventList.PLAYER_FadeIn, fadeIn);
		EventManager.stopListening(Events.EventList.PLAYER_FadeOut, fadeOut);
	}

	public void fadeIn()
	{
		fade.gameObject.SetActive (true);
		fade.setFadeIn ();
	}

	public void fadeOut() {
		fade.gameObject.SetActive (true);
		fade.setFadeOut ();
	}
}
