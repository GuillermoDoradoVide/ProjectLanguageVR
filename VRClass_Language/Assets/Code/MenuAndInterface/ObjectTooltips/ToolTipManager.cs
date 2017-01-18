﻿using UnityEngine;
using System.Collections;

public class ToolTipManager : MonoBehaviour, IElement
{
    public Canvas toolTipCanvas;
    public ObjectToolTip objectToolTip;

    public void hoverElement()
    {
        if (!toolTipCanvas.gameObject.activeSelf)
        {
            toolTipCanvas.gameObject.SetActive(true);
        }
        objectToolTip.disableTooltip = false;
    }

    public void selectElement()
    {
    }

    public void resetElement()
    {
    }

}
