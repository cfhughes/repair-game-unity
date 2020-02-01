//======= Copyright (c) Valve Corporation, All rights reserved. ===============

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class ButtonEffectCustom : MonoBehaviour
{
    public List<Door> doors;


    public void OnButtonDown(Hand fromHand)
    {
        ColorSelf(Color.cyan);
        fromHand.TriggerHapticPulse(1000);

        foreach(Door door in doors)
        {
            door.Toggle();
        }
    }

    public void OnButtonUp(Hand fromHand)
    {
        ColorSelf(Color.white);
    }

    private void ColorSelf(Color newColor)
    {
        Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
        for (int rendererIndex = 0; rendererIndex < renderers.Length; rendererIndex++)
        {
            renderers[rendererIndex].material.color = newColor;
        }
    }
}