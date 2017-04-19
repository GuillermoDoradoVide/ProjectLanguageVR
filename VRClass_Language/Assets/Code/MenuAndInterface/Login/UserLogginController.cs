using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserLogginController : MonoBehaviour {

	public GameObject loginInterface;

	public Text userIDV;
	public Text newUserID;

	public GameObject firstValue;
	public GameObject secondValue;
	public GameObject thirdValue;
	public GameObject continueSessionButton;
	public GameObject continueNewUserButton;

	public GameObject agentCodePass;
	public GameObject greetings;
	public GameObject introInterface;

	public EditUserID EditUserFirstValue;
	public EditUserID EditUserSecondValue;
	public EditUserID EditUserThirdValue;
	public int userID_s;
	public string strID;

	public AudioClip succesLogin;
	public AudioClip wrongLogin;
	public AudioClip newAgentSound;

	// Use this for initialization
	private void Start () {
		agentCodePass.SetActive (true);
		greetings.SetActive (false);
		EditUserFirstValue = firstValue.GetComponent<EditUserID> ();
		EditUserSecondValue = secondValue.GetComponent<EditUserID> ();
		EditUserThirdValue = thirdValue.GetComponent<EditUserID> ();
	}
	
	public void checkUserLoggin() {
		getValues ();
		if(checkUser (userID_s)) {
			SoundManager.playSFX (succesLogin);
			loginSucces ();
		}
		else {
			SoundManager.playSFX (wrongLogin);
		}
	}

	public void newAgent() {
		SessionManager.Instance.createNewUser ();
		if(checkUser (SessionManager.Instance.userID)) {
			SoundManager.playSFX (succesLogin);
			newAgentSessionStart ();
		}
		else {
			SoundManager.playSFX (wrongLogin);
		}
	}

	private void getValues() {
		userID_s = EditUserFirstValue.currentValue * 100 + EditUserSecondValue.currentValue * 10 + EditUserThirdValue.currentValue;
	}

	private void loginSucces() {
		agentCodePass.SetActive (false);
		greetings.SetActive (true);
		continueSessionButton.SetActive (true);
		strID = userID_s.ToString().PadLeft (3, '0');
		userIDV.text = strID;
		userIDV.text.PadLeft (3, '0');

	}

	private bool checkUser(int ID) {
		return SessionManager.Instance.loadUserProfileAndData (ID);
	}

	private void newAgentSessionStart() {
		introInterface.SetActive (true);
		continueNewUserButton.SetActive (true);
		strID = SessionManager.Instance.userID.ToString().PadLeft (3, '0');
		newUserID.gameObject.SetActive (true);
		newUserID.text = strID;
		newUserID.text.PadLeft (3, '0');
		SoundManager.playSFX (newAgentSound);
		agentCodePass.SetActive (false);
		greetings.SetActive (false);
		continueSessionButton.SetActive (false);
	}

	public void startIntro() {
		EventManager.triggerEvent (Events.EventList.NEW_USER);
		agentCodePass.SetActive (false);
		greetings.SetActive (false);
		continueSessionButton.SetActive (false);
		introInterface.SetActive (false);
		loginInterface.SetActive (false);

	}
}
