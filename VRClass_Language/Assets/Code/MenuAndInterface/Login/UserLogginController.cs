using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserLogginController : MonoBehaviour {

	public GameObject loginInterface;
    public GameObject ABCLoggin;
    public GameObject displayCodeName;

	public Text userIDV;
	public Text newUserID;

	public GameObject firstValue;
	public GameObject secondValue;
	public GameObject thirdValue;
	public GameObject continueSessionButton;
	public GameObject continueNewUserButton;

	public GameObject agentCodePass;
    private ShowAndHideWithAlpha animationAgentCode;
    public GameObject introGreetings;
    private ShowAndHideWithAlpha animationIntroGreetings;
    public GameObject introInterface;
    private ShowAndHideWithAlpha animationIntroInterface;

    public EditUserID EditUserFirstValue;
	public EditUserID EditUserSecondValue;
	public EditUserID EditUserThirdValue;
	public int userID_s;
	public string strID;

	public AudioClip succesLogin;
	public AudioClip wrongLogin;
	public AudioClip newAgentSound;

    private ShowAndHideWithAlpha animationShowHide;

	// Use this for initialization
	private void Start () {
        animationAgentCode = agentCodePass.GetComponent<ShowAndHideWithAlpha>();
        animationIntroGreetings = introGreetings.GetComponent<ShowAndHideWithAlpha>();
        animationIntroInterface = introInterface.GetComponent<ShowAndHideWithAlpha>();
        agentCodePass.SetActive (false);
		introGreetings.SetActive (false);
        introInterface.SetActive(false);
		EditUserFirstValue = firstValue.GetComponent<EditUserID> ();
		EditUserSecondValue = secondValue.GetComponent<EditUserID> ();
		EditUserThirdValue = thirdValue.GetComponent<EditUserID> ();
        animationShowHide = GetComponent<ShowAndHideWithAlpha>();
        animationShowHide.showPanel();
    }

    public void clickSound(AudioClip sound)
    {
        SoundManager.playSFX(sound);
    }

    public void showAgentCodeInterface()
    {
        agentCodePass.SetActive(true);
        animationAgentCode.showPanel();
    }

    public void hideAgentCodeInterface()
    {
        animationAgentCode.hidePanel();
    }

    public void showIntroGreetings()
    {
        introGreetings.SetActive(true);
        animationIntroGreetings.showPanel();
    }

    public void hideIntroGreetings()
    {
        animationIntroGreetings.hidePanel();
    }

    public void showIntroInterface()
    {
        introInterface.SetActive(true);
        animationIntroInterface.showPanel();
    }

    public void hideIntroInterface()
    {
        animationIntroInterface.hidePanel();
    }
    [ContextMenu("CheckUserLoggin")]
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
        //animationAgentCode.hidePanel();
        //agentCodePass.SetActive (false);
        ABCLoggin.SetActive(false);
        displayCodeName.SetActive(false);

        introGreetings.SetActive (true);
        animationIntroGreetings.showPanel();
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
        animationIntroInterface.showPanel();
		continueNewUserButton.SetActive (true);
		strID = SessionManager.Instance.userID.ToString().PadLeft (3, '0');
		newUserID.gameObject.SetActive (true);
		newUserID.text = strID;
		newUserID.text.PadLeft (3, '0');
		SoundManager.playSFX (newAgentSound);
        //agentCodePass.SetActive (false);
        //introGreetings.SetActive (false);
        animationAgentCode.hidePanel();
        animationIntroGreetings.hidePanel();
		continueSessionButton.SetActive (false);
	}

	public void startIntro() {
		EventManager.triggerEvent (Events.EventList.NEW_USER);
        //agentCodePass.SetActive (false);
        //introGreetings.SetActive (false);
        //continueSessionButton.SetActive (false);
        //introInterface.SetActive (false);
        //loginInterface.SetActive (false);
        animationShowHide.hidePanel();

	}
}
