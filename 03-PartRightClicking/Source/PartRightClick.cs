/*
 * PartRightClick.cs
 * 
 * Part of the KSP modding examples from Thunder Aerospace Corporation.
 * 
 * (C) Copyright 2013, Taranis Elsu
 * 
 * Kerbal Space Program is Copyright (C) 2013 Squad. See http://kerbalspaceprogram.com/. This
 * project is in no way associated with nor endorsed by Squad.
 * 
 * This code is licensed under the Apache License Version 2.0. See the LICENSE.txt and NOTICE.txt
 * files for more information.
 * 
 * Note that Thunder Aerospace Corporation is a ficticious entity created for entertainment
 * purposes. It is in no way meant to represent a real entity. Any similarity to a real entity
 * is purely coincidental.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Tac
{
    /*
     * This project is meant to demonstrate how to make a part with right-click options.
     * 
     * Please see the SimplePartModule example first. This class will not explain anything not
     * pertaining to making right-click options.
     * 
     * To make something show up on the right click menu, create a method with the KSPEvent attribute.
     * 
     * Open the Debug console when running this example. On Windows, you press Alt+F2 while in game.
     * For other OS'es, use the appropriate modifier and F2.
     */
    public class PartRightClick : PartModule
    {
        /*
         * This first event is almost as simple as you can get. We want it to show on the menu, so
         * we set a guiName and set guiActive to true.
         */
        [KSPEvent(guiActive = true, guiName = "Event 1")]
        public void Event1()
        {
            Debug.Log("TAC Examples-PartRightClick [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Event1");
            ScreenMessages.PostScreenMessage("Clicked Event 1", 10.0f, ScreenMessageStyle.UPPER_CENTER);
        }

        /*
         * This event is clickable when the part is not on the active ship, i.e. from a near-by ship or EVA.
         */
        [KSPEvent(guiActive = true, guiName = "Event 2", guiActiveUnfocused = true, unfocusedRange = 100.0f)]
        public void Event2()
        {
            Debug.Log("TAC Examples-PartRightClick [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Event2");
            ScreenMessages.PostScreenMessage("Clicked Event 2", 10.0f, ScreenMessageStyle.UPPER_CENTER);
        }

        /*
         * externalToEVAOnly makes it only work while on EVA.
         */
        [KSPEvent(guiActive = true, guiName = "Event 3", guiActiveUnfocused = true, unfocusedRange = 100.0f, externalToEVAOnly = false)]
        public void Event3()
        {
            Debug.Log("TAC Examples-PartRightClick [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Event3");
            ScreenMessages.PostScreenMessage("Clicked Event 3", 10.0f, ScreenMessageStyle.UPPER_CENTER);
        }
    }
}
