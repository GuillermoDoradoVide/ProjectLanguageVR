﻿using UnityEngine;
using System.Collections;
[AddComponentMenu("Controllers/menuMainController")]
public class menuMainController : MonoBehaviour {

    public GameObject menus;
    public Transform menusTransform;
    public bool animationIsPlaying = false;
    public bool superiorMenuState = false;

    public float maxAngle;
    public float minAngle;
    public float menuMovementSpeed;

    private enum AnimationActions { Show, Hide, Count };
    private AnimationActions animationActions;
    public delegate void DoMenuAnimations();
    public DoMenuAnimations[] doMenuAnimation;

    public Camera playerCamera;
    private Transform playerCameraTransform;
    private float cameraAngle;
    private float lastCameraAngle;

    private menuController hitMenu;
    private RaycastHit hit;

    //Provisional Debug and Test
    private float pitch = 0.0f;
    private float yaw = 0.0f;

    void Awake()
    {
        menusTransform = menus.GetComponent<Transform>();
        menus.SetActive(false);
        doMenuAnimation = new DoMenuAnimations[(int)AnimationActions.Count]; // init array of delegates
        // Set each action delegate
        animationActions = AnimationActions.Hide;
        doMenuAnimation[(int)AnimationActions.Show] = showAnimation;
        doMenuAnimation[(int)AnimationActions.Hide] = hideAnimation;

        playerCameraTransform = playerCamera.GetComponent<Transform>();
        lastCameraAngle = 0;

        hitMenu = null;
    }

    void Start()
    {
    }

    void Update ()
    {
        input();
        calculateViewRotation();
        playerCameraTransform.eulerAngles = new Vector3(pitch * 2, yaw * 2, 0.0f);
        if (!superiorMenuState)
        {
            if (!checkMenuState())
            {
                if (!animationIsPlaying) this.transform.eulerAngles = new Vector3(0.0f, yaw * 2, 0.0f);
            }
        }
        else
        {
            calculateMenu();
        }

        if (animationIsPlaying) {
            if (doMenuAnimation[(int)animationActions] != null)
            {
                doMenuAnimation[(int)animationActions]();
            }
        }
    }

    private void menuRotation ()
    {
        this.transform.eulerAngles = new Vector3(0.0f, yaw * 2, 0.0f);
    }

    private void input()
    {
        yaw += Input.GetAxis("Mouse X");
        pitch -= Input.GetAxis("Mouse Y");
    }

    private void calculateViewRotation()
    {
        cameraAngle = playerCameraTransform.rotation.eulerAngles.x;
        Debug.DrawLine(playerCameraTransform.position, Vector3.forward, Color.blue);
        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward, Color.green);
    }

    private bool checkMenuState()
    {
        if ((lastCameraAngle > minAngle && lastCameraAngle < maxAngle) && (cameraAngle > maxAngle || cameraAngle < minAngle))
        {
            menuContinue();
        }
        else if ((lastCameraAngle < minAngle || lastCameraAngle > maxAngle) && (cameraAngle < maxAngle && cameraAngle > minAngle))
        {
            menuPause();
        }
        lastCameraAngle = cameraAngle;
        if (cameraAngle < maxAngle && cameraAngle > minAngle)
        {
            checkAnimation(AnimationActions.Show);
            return true;
        }
        else
        {
            checkAnimation(AnimationActions.Hide);
            return false;
        }
    }

    public void menuPause()
    {
        Debug.Log("Pausa");
        EventManager.Instance.EventPause();
    }

    public void menuContinue()
    {
        Debug.Log("Continuar");
        EventManager.Instance.EventContinue();
    }

    private void checkAnimation(AnimationActions animAction)
    {
        if (!animationIsPlaying && animationActions != animAction)
        {
            animationIsPlaying = true;
            animationActions = animAction;
        }
    }

    public void showAnimation()
    {
        if(!menus.activeSelf)menus.SetActive(true);
        if (menusTransform.localPosition.y < -0.65f)
        {
            menus.transform.Translate(Vector3.up * Time.deltaTime * menuMovementSpeed);
        }
        else
        {
            animationIsPlaying = false;
        }
    }

    public void hideAnimation()
    {
        if (menus.activeSelf)
        {
            if (menusTransform.localPosition.y > -1)
            {
                menus.transform.Translate(- Vector3.up * Time.deltaTime * menuMovementSpeed);
            }
            else
            {
                menusTransform.localPosition = new Vector3(menusTransform.localPosition.x, -1, menusTransform.localPosition.z);
                animationIsPlaying = false;
                menus.SetActive(false);
            }
        }
    }

    public void calculateMenu()
    {

    }
}
