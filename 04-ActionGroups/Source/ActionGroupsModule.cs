/*
 * ActionGroupsModule.cs
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
     * This project is meant to demonstrate how to make a part with events that can be added to
     * action groups.
     * 
     * Please see the SimplePartModule example first. This class will not explain anything not
     * pertaining to making action group events.
     * 
     * To make something show up on the action groups tab, create a method with the KSPAction
     * attribute.
     * 
     * KSPAction has the following parameters:
     *    guiName = The name to show for the action. Required.
     *    actionGroup = Automatically adds the action to the specified Action Group when adding the
     *       part to your vessel. Defaults to KSPActionGroup.None.
     */
    public class ActionGroupsModule : PartModule
    {
        /*
         * A simple action.
         */
        [KSPAction("Simple Action")]
        public void SimpleAction(KSPActionParam param)
        {
            ScreenMessages.PostScreenMessage("Simple Action", 5.0f, ScreenMessageStyle.UPPER_CENTER);
            Debug.Log("TAC Example -- SimpleAction: group=" + param.group + ", type=" + param.type + ", cooldown=" + param.Cooldown);
        }

        /*
         * This event is automatically added to the "Light" action group. That means that any time
         * you toggle the lights, this action will also get triggered.
         */
        [KSPAction("Lights Action", KSPActionGroup.Light)]
        public void LightsAction(KSPActionParam param)
        {
            string mode = (param.type == KSPActionType.Activate) ? "on" : "off";
            ScreenMessages.PostScreenMessage("Lights Action: did you toggle the lights " + mode + "?", 5.0f, ScreenMessageStyle.UPPER_CENTER);
            Debug.Log("TAC Example -- LightsAction: group=" + param.group + ", type=" + param.type + ", cooldown=" + param.Cooldown);
        }
    }
}
