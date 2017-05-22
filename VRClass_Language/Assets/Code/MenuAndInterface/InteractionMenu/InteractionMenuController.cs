using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System.Collections;

public class InteractionMenuController : MonoBehaviour
{

    public GameObject[] dialogGameObject;
    public Button[] dialogButton;
    public Text[] dialog;
    public bool[] optionSelected;
    public Transform player;
    public Color normal;
    public Color highligted;
    public Color normalSelected;
    public Color highligtedSelected;

    public GameObject interactionMenuObject;

    private static InteractionMenuController interactionMenu;
    public GvrPointerGraphicRaycaster gvrRaycast;

    public static InteractionMenuController Instance()
    {
        if (!interactionMenu)
        {
            interactionMenu = FindObjectOfType(typeof(InteractionMenuController)) as InteractionMenuController;
            if (!interactionMenu)
            {
                Debugger.printErrorLog("There is not an active InteractionMenuController GameObject in the scene");
            }
        }
        return interactionMenu;
    }

    private void Awake()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        gvrRaycast = GetComponentInChildren(typeof(GvrPointerGraphicRaycaster), true) as GvrPointerGraphicRaycaster;
        for (int x = 0; x < dialogGameObject.Length; x++)
        {
            dialogButton[x] = dialogGameObject[x].GetComponentInChildren<Button>();
            dialog[x] = dialogGameObject[x].GetComponentInChildren<Text>();
            //optionSelected[x] = false;
        }
        EventManager.startListening(Events.EventList.STATE_Pause, pauseIsOn);
        EventManager.startListening(Events.EventList.STATE_Continue, pauseIsOff);
        //EventManager.startListening(Events.EventList.DIALOG_Selected, setOptionXSelected);
    }

    private void OnEnable()
    {
        EventManager.Instance.AddListener<DialogOptionSelectedEvent>(dialogHasBeenSelected);
    }

    private void OnDisable()
    {
        EventManager.Instance.RemoveListener<DialogOptionSelectedEvent>(dialogHasBeenSelected);
    }

    public void resetOptionStates()
    {
        for (int x = 0; x < dialogGameObject.Length; x++)
        {
            ColorBlock cb = dialogButton[x].colors;
            cb.normalColor = normal;
            cb.highlightedColor = highligted;
            dialogButton[x].colors = cb;
        }
    }

    //show dialog event action
    public void addDialogTriggerAction(int optionNumber, string boxDialog, UnityAction dialogTriggerEvent)
    {
        interactionMenuObject.SetActive(true);
        dialogGameObject[optionNumber].SetActive(true);
        dialogButton[optionNumber].onClick.RemoveAllListeners();
        dialogButton[optionNumber].onClick.AddListener(dialogTriggerEvent);
        dialog[optionNumber].text = boxDialog;
    }

    public void closeInteractionMenu()
    {
        interactionMenuObject.SetActive(false);
    }

    public void movePanelTo(Transform newPosition)
    {
        if (newPosition != null)
            gameObject.transform.position = newPosition.position;
        transform.LookAt (player.position);
		transform.RotateAround (transform.position, Vector3.up, 180);
    }

    private void dialogHasBeenSelected(DialogOptionSelectedEvent e)
    {
        ColorBlock cb = dialogButton[e.Dialog].colors;
        cb.normalColor = normalSelected;
        cb.highlightedColor = highligtedSelected;
        dialogButton[e.Dialog].colors = cb;
    }

    private void pauseIsOn()
    {
        gvrRaycast.enabled = false;
    }

    private void pauseIsOff()
    {
        gvrRaycast.enabled = true;
    }
}
