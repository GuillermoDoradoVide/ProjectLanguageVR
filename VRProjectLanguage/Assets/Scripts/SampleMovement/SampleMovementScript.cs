using UnityEngine;
using System.Collections;

public class SampleMovementScript : stateScript {

    public Transform[] _speechPosition;
    public int _currentNextPosition = 0;
    public float _speed;
    public GameObject _gameObjectToMove;
    public Transform _gameObjectTransform;

    public bool _finished = false;

    // Use this for initialization
    void Start () {
        _gameObjectTransform = _gameObjectToMove.GetComponent<Transform>();
    }

    // Update is called once per frame
   public  override void doUpdate () {
    }

    public bool moveToNext()
    {
        _gameObjectTransform.position = Vector3.MoveTowards(_gameObjectTransform.position, _speechPosition[_currentNextPosition].position, Time.deltaTime * _speed);
        if (_gameObjectTransform.position == _speechPosition[_currentNextPosition].position)
        {
            if (_currentNextPosition < _speechPosition.Length - 1)
            {
                _currentNextPosition++;
            }
            return true;
        }
        else return false;
    }
}
