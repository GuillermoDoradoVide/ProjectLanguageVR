﻿using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class PlayerGazeInteraction : MonoBehaviour {
    private RaycastHit hit;
    public Transform playerPosition;
    public GameObject targetGazedObject;
    private void Awake()
    {
        playerPosition = GetComponent<Transform>();
        targetGazedObject = null;
    }
	// Use this for initialization
	private void Start () {
	
	}
	
	// Update is called once per frame
	private void Update () {
        drawGaze();
        playerGaze();
	}

    private void playerGaze()
    {
        if (Physics.Raycast(playerPosition.position, playerPosition.forward, out hit))
        {
            targetGazedObject = hit.transform.gameObject;
            if (ExecuteEvents.CanHandleEvent<IElement>(targetGazedObject))
            {
                ExecuteEvents.Execute(targetGazedObject, null, (IElement element, BaseEventData data) => element.hoverElement());
            }
        }
    }

    private void drawGaze()
    {
        Debug.DrawRay(playerPosition.position, playerPosition.forward, Color.red);
        Debug.DrawLine(playerPosition.position, playerPosition.forward, Color.green);
    }
}
