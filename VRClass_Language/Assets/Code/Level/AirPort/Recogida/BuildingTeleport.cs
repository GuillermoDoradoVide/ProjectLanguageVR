using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BuildingTeleport : MonoBehaviour
{

    public List<Transform> tiles;
    public List<Transform> tilesToDisplace;

    public float _speed;

    public bool startLoop;
    // Use this for initialization
    private void Start()
    {
        startLoop = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (startLoop)
        {
            loopZoneTiles();
        }
    }

    void loopZoneTiles()
    {
        foreach (Transform _t in tiles)
        {
            _t.position = new Vector3(_t.position.x, _t.position.y, _t.position.z - _speed);
            if (_t.localPosition.z <= -200)
            {
                tilesToDisplace.Add(_t);
                _t.position = new Vector3(_t.position.x, _t.position.y, _t.GetComponent<NextBuildingElement>()._next.GetChild(0).position.z);
            }
        }
        foreach (Transform _t in tilesToDisplace)
        {
            tiles.Remove(_t);
            tiles.Add(_t);
        }
    }
}

