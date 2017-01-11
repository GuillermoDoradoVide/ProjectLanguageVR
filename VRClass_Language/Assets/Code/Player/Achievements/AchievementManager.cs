using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour {

    public Canvas achievementCanvas;
    public GameObject canvasAchievementPanel;
    public TextMesh achievementCanvasName;
    public TextMesh achievementCanvasDescription;
    public Image achievementCanvasSprite;

    public float currentAchievementTimer;
    public float achievementTimer;
    public float lerpPercentage;

    public Transform initPos;
    public Transform finalPos;

    public AchievementData sample;
    public List<AchievementData> achievementsList;

    private void Awake()
    {
        achievementsList = new List<AchievementData>();
        achievementsList.Add(sample);
        EventManager.addAchievementListener(setAchievement);
        EventManager.startListening(Events.EventList.ACHVV_TriggerUnlocked_Achievement, showAchievement);
    }

    private void OnEnable()
    {

    }

    private void OnDisable()
    {
        EventManager.stopListening(Events.EventList.ACHVV_TriggerUnlocked_Achievement, showAchievement);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private void setAchievement(string name)
    {
        AchievementData unlockedAchievementData;
        unlockedAchievementData = achievementsList.Find(x => x.achievementName == name);
        achievementCanvasName.text = unlockedAchievementData.name;
        achievementCanvasDescription.text = unlockedAchievementData.description;
        achievementCanvasSprite.sprite = unlockedAchievementData.image;
    }

    private void showAchievement()
    {
        StartCoroutine(showAchievementUIPanel());
    }

    private IEnumerator showAchievementUIPanel()
    {
        achievementCanvas.gameObject.SetActive(true);
        while (currentAchievementTimer < achievementTimer)
        {
            currentAchievementTimer += Time.deltaTime;
            lerpPercentage = currentAchievementTimer / achievementTimer;
            canvasAchievementPanel.transform.position = Vector3.Lerp(initPos.position, finalPos.position, lerpPercentage);
            yield return true;
        }
        
        yield return new WaitForSeconds(2.0f);
        canvasAchievementPanel.transform.position = initPos.position;
        achievementCanvas.gameObject.SetActive(false);
        lerpPercentage = 0;
        currentAchievementTimer = 0;
    }
}
