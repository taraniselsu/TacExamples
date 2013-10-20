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
     * This project is meant to be a "Hello World" example showing how to make a part-less plugin.
     * 
     * The main class for your plug-in should implement MonoBehavior, which is a Unity class.
     * http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.html
     * 
     * KSPAddon is an "attribute" that lets KSP know that this class is a plug-in. KSP will create
     * an instance of the class whenever the game loads the specified scene. The second parameter
     * tells KSP whether to create an instance once, or every time it loads the scene.
     * 
     * Do not use true for the second parameter until this bug gets fixed:
     * http://forum.kerbalspaceprogram.com/threads/45107-KSPAddon-bug-causes-mod-incompatibilities
     * That link has a workaround, but prefer to use false unless your needs dictate otherwise.
     * 
     * The lifecycle for KSP comes from Unity with a few differences:
     *    
     *    Constructor -> Awake() -> Start() -> Update/FixedUpdate() [repeats] -> OnDestroy()
     * 
     * When the specified game scene loads, first KSP will construct your MonoBehaviour class and
     * call Awake(). When it finishes doing that for all the mods, then it calls Start(). After
     * that, it will call Update() every frame and FixedUpdate() every physics time step. Just
     * before exiting the scene, the game will call OnDestroy() which gives you the opportunity to
     * save any settings.
     * 
     * Unity uses Serialization a lot, so use the Awake() method to initialize your fields rather
     * than the constructor. And you can use OnDestroy() to do some of the things you would do in
     * a destructor.
     * 
     * Also see http://www.richardfine.co.uk/2012/10/unity3d-monobehaviour-lifecycle/ for more
     * information about the Unity lifecycle.
     * 
     * This plugin does not actually do anything beyond logging to the Debug console, which you
     * can access by pressing Alt+F2 or Alt+F12 (on Windows, for OSX use Opt and for Linux use
     * Right Shift). You can also look at the debug file, which you can find at
     * {KSP}/KSP_Data/output_log.txt.
     */
    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class SimplePartlessPlugin : MonoBehaviour
    {
        private float lastUpdate = 0.0f;
        private float lastFixedUpdate = 0.0f;
        private float logInterval = 5.0f;

        /*
         * Caution: as it says here: http://docs.unity3d.com/Documentation/ScriptReference/MonoBehaviour.Awake.html,
         * use the Awake() method instead of the constructor for initializing data because Unity uses
         * Serialization a lot.
         */
        public SimplePartlessPlugin()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Constructor");
        }

        /*
         * Called after the scene is loaded.
         */
        void Awake()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Awake: " + this.name);
        }

        /*
         * Called next.
         */
        void Start()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: Start");
        }

        /*
         * Called every frame
         */
        void Update()
        {
            if ((Time.time - lastUpdate) > logInterval)
            {
                lastUpdate = Time.time;
                Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                    + "][" + Time.time.ToString("0.0000") + "]: Update");
            }
        }

        /*
         * Called at a fixed time interval determined by the physics time step.
         */
        void FixedUpdate()
        {
            if ((Time.time - lastFixedUpdate) > logInterval)
            {
                lastFixedUpdate = Time.time;
                Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                    + "][" + Time.time.ToString("0.0000") + "]: FixedUpdate");
            }
        }

        /*
         * Called when the game is leaving the scene (or exiting). Perform any clean up work here.
         */
        void OnDestroy()
        {
            Debug.Log("TAC Examples-SimplePartlessPlugin [" + this.GetInstanceID().ToString("X")
                + "][" + Time.time.ToString("0.0000") + "]: OnDestroy");
        }
    }
}
