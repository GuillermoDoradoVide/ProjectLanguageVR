using UnityEngine;
using System.Collections;

public class InitOptimizactionConfg : MonoBehaviour {

	// Use this for initialization
	void Start () {
		QualitySettings.antiAliasing = 4;
		Application.targetFrameRate = 60;
		QualitySettings.vSyncCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
