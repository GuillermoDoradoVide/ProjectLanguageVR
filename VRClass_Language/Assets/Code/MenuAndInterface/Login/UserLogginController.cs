using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UserLogginController : MonoBehaviour {

	public Text userIDvalue;

	public GameObject firstValue;
	public GameObject secondValue;
	public GameObject thirdValue;

	public GameObject agentCodePass;
	public GameObject greetings;

	public EditUserID EditUserFirstValue;
	public EditUserID EditUserSecondValue;
	public EditUserID EditUserThirdValue;
	public int userID;
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
		checkUser (userID);
	}

	private void getValues() {
		userID = EditUserFirstValue.currentValue * 100 + EditUserSecondValue.currentValue * 10 + EditUserThirdValue.currentValue;
	}

	public void newAgent() {
		SessionManager.Instance.createNewUser ();
		checkUser (SessionManager.Instance.userID);
	}

	private void checkUser(int ID) {
		SessionManager.Instance.loadUserProfileAndData (ID);
		agentCodePass.SetActive (false);
		greetings.SetActive (true);
		userIDvalue.text = ID.ToString();
		userIDvalue.text.PadLeft (3, '0');
	}
}
