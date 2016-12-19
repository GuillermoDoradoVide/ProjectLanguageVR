using UnityEngine;
using System.Collections;
using System;

public class SampleMovementScript : StateScript {

    public Transform[] _speechPosition;
    public Camera playerCamera;
    public int _currentNextPosition = 0;
    public float _speed;
    public GameObject _gameObjectToMove;
    public Transform _gameObjectTransform;

    public bool _finished = false;

    // Use this for initialization
    private  void Start()
    {
        _gameObjectTransform = _gameObjectToMove.GetComponent<Transform>();
    }

    public override void atInit()
    {
    }

    public override void atPause()
    {
    }
    // Update is called once per frame
    public override void atUpdate () {
        moveToNext();
    }

    public override void atContinue()
    {
        throw new NotImplementedException();
    }

    public void moveToNext()
    {
        _gameObjectTransform.position = Vector3.MoveTowards(_gameObjectTransform.position, _speechPosition[_currentNextPosition].position, Time.deltaTime * _speed);
        if (_gameObjectTransform.position == _speechPosition[_currentNextPosition].position)
        {
           
            _gameObjectTransform.rotation = _speechPosition[_currentNextPosition].rotation;
            if (_currentNextPosition < _speechPosition.Length - 1)
            {
                _currentNextPosition++;
            }
            changeThisStateToFinished();
        }
    }
}
