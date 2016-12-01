using UnityEngine;
using System.Collections;

public class PetCharacterController : MonoBehaviour {

    public StateMachine _PetstateMachine;
    public GameObject _Pet;
    public SampleDialogScript _Dialog;
    public SampleMovementScript _Movement;
    public delegate void action();
    public int[] _actionSequence;
    public int _currentActionSequence = 0;
    action _currentAction;

	// Use this for initialization
	void Start () {
        _PetstateMachine = GetComponent<StateMachine>();
        getnextAction();
    }
	
	// Update is called once per frame
	void Update () {
        _currentAction();
        if (Input.anyKey) Application.Quit();
	}

    void move()
    {
        if(_Movement.moveToNext())
        {
            getnextAction();
        }
    }

    void talk()
    {
        if (_Dialog.playSound())
        {
            getnextAction();
        }
    }

    void nextMoveAction()
    {
        _currentAction = move;
    }

    void nextTalkAction()
    {
        _currentAction = talk;
        _Dialog.StartNextSound();
    }

    void getnextAction()
    {
        Debug.Log(_currentActionSequence);
        if (_currentActionSequence <= _actionSequence.Length - 1) { 
            switch (_actionSequence[_currentActionSequence])
            {
                case 0:
                    {
                        nextMoveAction();
                        break;
                    }
                case 1:
                    {
                        nextTalkAction();
                        break;
                    }
                default:
                    {
                        nextMoveAction();
                        break;
                    }
            }
            _currentActionSequence++;
        }
        else
        {
           _currentAction = doNothing;
        }
    }

    void doNothing()
    {
        Debug.Log("Terminado");
    }
}
