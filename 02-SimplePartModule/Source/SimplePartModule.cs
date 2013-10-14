/*
 * SimplePartModule.cs
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
     * This project is meant to be a "Hello World" example showing how to make a PartModule plugin.
     * 
     * The main class for your module should implement the PartModule class, which is a KSP class.
     * http://wiki.kerbalspaceprogram.com/wiki/Creating_your_first_module#Extending_PartModule
     * 
     * The lifecycle for PartModules is fairly complicated:
     * 
     * While the game is loading, KSP calls:
     *    Constructor -> OnAwake -> OnLoad -> GetInfo
     * then it "clones" the instance and calls the following on the new instance:
     *    Constructor -> OnAwake
     * One of the above instances is used in the VAB and SPH. The other is made into a prefab part
     * and it is used to create any further instances of your part. The above OnLoad loads the
     * values in the part's cfg file.
     * 
     * When placing the part in the editor, KSP "clones" the prefab part and calls the following on
     * the new instance:
     *    Constructor, OnAwake, OnStart, OnSave
     * 
     * When loading a saved vessel in the editor:
     *    Constructor -> OnAwake -> OnLoad -> OnSave -> OnStart
     * The above OnLoad loads the values in the .craft file.
     * 
     * When launching your craft, KSP again "clones" the prefab part and calls:
     *    Constructor -> OnAwake -> OnLoad -> OnSave -> OnStart -> OnActive -> OnUpdate/OnFixedUpdate (repeated)
     * The above OnLoad loads the values in the .craft file. Going to an existing craft (i.e. from
     * the Tracking Station) does the same, without the OnSave before OnStart, and the OnLoad loads
     * the values from the vessel's entry in the persistence or quicksave file.
     * 
     * Note that the first OnLoad, when KSP is creating the prefab part, loads from the part's cfg
     * file. Thereafter, it loads from the vessel's saved information (either the persistence file
     * or the quicksave file).
     * 
     * Unity uses Serialization a lot, so use the Awake() method to initialize your fields rather
     * than the constructor.
     */
    public class SimplePartModule : PartModule
    {
        private float lastUpdate = 0.0f;
        private float lastFixedUpdate = 0.0f;
        private float logInterval = 5.0f;

        /*
         * Caution: as it says here: http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Awake.html,
         * use the Awake() method instead of the constructor for initializing data because Unity uses
         * Serialization a lot.
         */
        public SimplePartModule()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Constructor");
        }

        /*
         * Called after the scene is loaded.
         */
        public override void OnAwake()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnAwake: " + this.name);
            base.OnAwake();
        }

        /*
         * Called when the part is activated/enabled. This usually occurs either when the craft
         * is launched or when the stage containing the part is activated.
         * You can activate your part manually by calling part.force_activate().
         */
        public override void OnActive()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnActive");
            base.OnActive();
        }

        /*
         * Called after OnAwake.
         */
        public override void OnStart(PartModule.StartState state)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnStart: " + state);
            base.OnStart(state);
        }

        /*
         * Called every frame
         */
        public override void OnUpdate()
        {
            // This is here just to prevent spamming the log file.
            if ((Time.time - lastUpdate) > logInterval)
            {
                lastUpdate = Time.time;
                Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                    + "][" + Time.time.ToString("0.0000") + "]: OnUpdate");
            }
            base.OnUpdate();
        }

        /*
         * Called at a fixed time interval determined by the physics time step.
         */
        public override void OnFixedUpdate()
        {
            // This is here just to prevent spamming the log file.
            if ((Time.time - lastFixedUpdate) > logInterval)
            {
                lastFixedUpdate = Time.time;
                Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                    + "][" + Time.time.ToString("0.0000") + "]: OnFixedUpdate");
            }
            base.OnFixedUpdate();
        }

        /*
         * KSP adds the return value to the information box in the VAB/SPH.
         */
        public override string GetInfo()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: GetInfo");
            return base.GetInfo() + "\nContains the TAC Example - Simple Part Module\n";
        }

        /*
         * Called when the part is deactivated. Usually because it was destroyed.
         */
        public override void OnInactive()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnInactive");
            base.OnInactive();
        }

        /*
         * Called when the game is loading the part information. It comes from: the part's cfg file,
         * the .craft file, the persistence file, or the quicksave file.
         */
        public override void OnLoad(ConfigNode node)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnLoad: " + node);
            base.OnLoad(node);
        }

        /*
         * Called when the game is saving the part information.
         */
        public override void OnSave(ConfigNode node)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnSave: " + node);
            base.OnSave(node);
        }
    }
}
