/**
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
    public class SimplePartModule : PartModule
    {
        public SimplePartModule()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Constructor");
        }

        public override void OnAwake()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnAwake: " + this.name);
            base.OnAwake();
        }

        public override void OnActive()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnActive");
            base.OnActive();
        }

        public override void OnStart(PartModule.StartState state)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnStart: " + state);
            base.OnStart(state);
        }

        public override void OnUpdate()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnUpdate");
            base.OnUpdate();
        }

        public override void OnFixedUpdate()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnFixedUpdate");
            base.OnFixedUpdate();
        }

        public override string GetInfo()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: GetInfo");
            return base.GetInfo() + "\nwith the TAC Example - Simple Part Module\n";
        }

        public override void OnInactive()
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnInactive");
            base.OnInactive();
        }

        public override void OnLoad(ConfigNode node)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnLoad: " + node);
            base.OnLoad(node);
        }

        public override void OnSave(ConfigNode node)
        {
            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnSave (before): " + node);
            base.OnSave(node);

            Debug.Log("TAC Examples-SimplePartModule [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnSave (after): " + node);
        }
    }
}
