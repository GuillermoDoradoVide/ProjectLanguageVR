using UnityEngine;
using System.Collections;

public class Background_Conversation_A : MonoBehaviour
{

	public Animator male;
	public Animator female;
	private int random;
	public static int talkingID;

	// Use this for initialization
	void Start ()
	{
		talkingID = Animator.StringToHash ("Talking");
	}

	// Update is called once per frame
	void Update ()
	{
		if (female.GetCurrentAnimatorStateInfo (0).normalizedTime >= 0.9f) {
			random = Random.Range (0, 2);
			if (random == 0) {
				female.SetBool (talkingID, false);
				male.SetBool (talkingID, true);
			}
			else {
				female.SetBool (talkingID, true);
				male.SetBool (talkingID, false);
			}
		}
	}
}

