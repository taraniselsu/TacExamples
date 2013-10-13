/*
 * SimplePartlessPlugin.cs
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
     * This project is meant to be the "Hello World" example showing how to make a part-less plugin.
     * 
     * The main class for your plug-in must implement MonoBehavior.
     * http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.html
     * 
     * It is suggested that you read http://www.richardfine.co.uk/2012/10/unity3d-monobehaviour-lifecycle/
     * along with this class.
     * 
     * KSPAddon is an "attribute" that lets KSP know that this class is a plug-in. When KSP sees
     * the attribute, KSP will create an instance whenever the game loads the specified scene. The
     * second parameter tells KSP whether to create an instance once, or every time it loads the
     * scene. Note that there is a bug in 0.21.1 until ? where only one class can be 
     * 
     * Be careful using true with KSPAddon until this bug gets fixed:
     * http://forum.kerbalspaceprogram.com/threads/45107-KSPAddon-bug-causes-mod-incompatibilities
     */
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SimplePartlessPlugin : MonoBehaviour
    {
        /*
         * The constructor. Called when the scene specified in the KSPAddon attribute is loaded. Do not
         * rely on the constructor much though because Unity doesn't play well with them. Use the Awake() method
         * to initialize your fields instead.
         */
        public SimplePartlessPlugin()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Constructor");
        }

        /*
         * Called after the scene is loaded.
         * Only if the GameObject is active?
         * 
         * "Called when the script instance is being loaded." 
         */
        void Awake()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Awake: " + this.name);
        }

        /*
         * Called next
         */
        void Start()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Start");
        }

        /*
         */
        void Update()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Update");
        }

        /*
         */
        void FixedUpdate()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: FixedUpdate");
        }

        /*
         */
        void LateUpdate()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: LateUpdate");
        }

        /*
         */
        void OnEnable()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnEnable");
        }

        /*
         */
        void OnDisable()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnDisable");
        }

        /*
         */
        void OnDestroy()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnDestroy");
        }
    }
}
