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
     * This project is meant to demonstrate how to make a part with right-click events.
     * 
     * Please see the SimplePartModule example first. This class will not explain anything not
     * pertaining to making right-click events.
     * 
     * To make something show up on the right click menu, create a method with the KSPEvent attribute.
     * 
     * KSPEvent has the following parameters:
     *    active = Controls whether the event is active (or enabled). The default value is true.
     *    guiName = The name to show for the event. The default value is an empty string, which will
     *       make KSP use the method name instead.
     *    guiActive = Controls whether the event is active while controlling the vessel with the
     *       part. The default value is false.
     *    guiActiveUnfocused = Controls whether the event is active while controlling a nearby
     *       vessel. The default value is false.
     *    externalToEVAOnly = Only has an effect if guiActiveUnfocused is true, then it controls
     *       whether the event is active for nearby vessels or only for nearby EVAs. The default
     *       value is true, which means that the event is only active for nearby EVAs and not
     *       for nearby vessels.
     *    unfocusedRange = The maximum range at which the event can be triggered while controlling
     *       a different vessel or an EVA. The default value is 
     *    name = Unknown
     *    category = Unknown
     *    isDefault = Unknown
     *    guiIcon = Unknown
     *    
     * If you want an event to be active for:
     *   the vessel with the part     set guiActive to true
     *   a nearby Kerbal on EVA       set guiActiveUnfocused to true
     *   a nearby vessel              set guiActiveUnfocused to true, and externalToEVAOnly to false
     */
    public class PartRightClick : PartModule
    {
        /*
         * This event is active when controlling the vessel with the part.
         */
        [KSPEvent(guiActive = true, guiName = "Activate")]
        public void ActivateEvent()
        {
            ScreenMessages.PostScreenMessage("Clicked Activate", 5.0f, ScreenMessageStyle.UPPER_CENTER);

            // This will hide the Activate event, and show the Deactivate event.
            Events["ActivateEvent"].active = false;
            Events["DeactivateEvent"].active = true;
        }

        /*
         * This event is also active when controlling the vessel with the part. It starts disabled.
         */
        [KSPEvent(guiActive = true, guiName = "Deactivate", active = false)]
        public void DeactivateEvent()
        {
            ScreenMessages.PostScreenMessage("Clicked Deactivate", 5.0f, ScreenMessageStyle.UPPER_CENTER);

            // This will hide the Deactivate event, and show the Activate event.
            Events["ActivateEvent"].active = true;
            Events["DeactivateEvent"].active = false;
        }

        /*
         * This event is active when controlling a nearby EVA. It can be activated from up to 25
         * meters away.
         */
        [KSPEvent(guiActiveUnfocused = true, unfocusedRange = 25f, guiName = "Nearby EVA")]
        public void NearbyEvaEvent()
        {
            ScreenMessages.PostScreenMessage("Clicked NearbyEvaEvent", 5.0f, ScreenMessageStyle.UPPER_CENTER);
        }

        /*
         * This event is active when controlling a nearby vessel. Note that the event will also be
         * active for nearby EVAs. There is not currently a way to make it only active for nearby
         * vessels.
         */
        [KSPEvent(guiActiveUnfocused = true, externalToEVAOnly = false, unfocusedRange = 25f, guiName = "Nearby Vessel")]
        public void NearbyVesselEvent()
        {
            ScreenMessages.PostScreenMessage("Clicked NearbyVesselEvent", 5.0f, ScreenMessageStyle.UPPER_CENTER);
        }

        /*
         * This event is always active, regardless of which vessel is being controlled.
         */
        [KSPEvent(guiActive = true, guiActiveUnfocused = true, externalToEVAOnly = false, unfocusedRange = 25f, guiName = "Any Event")]
        public void AnyEvent()
        {
            ScreenMessages.PostScreenMessage("Clicked AnyEvent", 5.0f, ScreenMessageStyle.UPPER_CENTER);
        }
    }
}
