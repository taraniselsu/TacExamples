/*
 * KspFieldsModule.cs
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
     * This project is meant to demonstrate what you can do with KSPFields.
     * 
     * Please see the SimplePartModule example first. This class will not explain anything not
     * pertaining to fields.
     * 
     * Create a class variable with the KSPField attribute. *** MAKE SURE IT IS PUBLIC!! ***
     * 
     * KSPField can be used for several different purposes:
     *    1) You can show a value on the part's right-click menu.
     *    2) You can load a value from the part's cfg file.
     *    3) You can persist a value in the game save.
     *    
     * 
     * KSPField has the following parameters:
     *    isPersistant = Controls whether the current value is saved to the persistance file with
     *       the vessel information. The default value is false.
     *    guiActive = Controls whether the current value is shown on the part's right click menu.
     *       The default value is false.
     *    guiName = The name to show with the value on the part's right click menu. The default
     *       value is the variable's name.
     *    guiUnits = A string to show after the value on the part's right click menu that is supposed
     *       to represent the units of the value. The default value is nothing (empty string).
     *    guiFormat = Controls the numeric format. See http://msdn.microsoft.com/en-us/library/dwhawy9k.aspx
     *       and http://msdn.microsoft.com/en-us/library/0c899ak8.aspx . The default value is nothing
     *       (empty string).
     *    category = Unknown
     */
    public class KspFieldsModule : PartModule
    {
        [KSPField(isPersistant = true, guiActive = true)]
        public int anInt = 123;

        [KSPField(isPersistant = true, guiActive = true)]
        public long aLong = 12345;

        [KSPField(isPersistant = true, guiActive = true)]
        public float aFloat = 12.34f;

        [KSPField(isPersistant = true, guiActive = true)]
        public double aDouble = 123.45;

        [KSPField(isPersistant = true, guiActive = true)]
        public bool aBool = false;

        [KSPField(isPersistant = true, guiActive = true)]
        public string aString = "Hello";

        [KSPField(isPersistant = true)]
        public MyType myType;

        public KspFieldsModule()
        {
            if (myType == null)
            {
                myType = new MyType();
            }
            Debug.Log("TAC Examples-KspFields [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: Constructor: " + makeLogString());
        }

        public override void OnAwake()
        {
            Debug.Log("TAC Examples-KspFields [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnAwake: " + makeLogString());
        }

        public override void OnLoad(ConfigNode node)
        {
            Debug.Log("TAC Examples-KspFields [" + this.GetInstanceID().ToString("X") + "][" + Time.time.ToString("0.0000") + "]: OnLoad: " + makeLogString());
        }

        private string makeLogString()
        {
            return "anInt=" + anInt + ", aLong=" + aLong + ", aFloat=" + aFloat + ", aDouble=" + aDouble + ", aBool=" + aBool + ", aString=" + aString + ", myType=" + myType;
        }
    }

    [Serializable]
    public class MyType : IConfigNode
    {
        [SerializeField]
        public float oneFloat = 123.45f;
        [SerializeField]
        public float twoFloat = 234.56f;

        public void Load(ConfigNode node)
        {
            float f;
            if (node.HasValue("oneFloat") && float.TryParse(node.GetValue("oneFloat"), out f))
            {
                oneFloat = f;
            }

            if (node.HasValue("twoFloat") && float.TryParse(node.GetValue("twoFloat"), out f))
            {
                twoFloat = f;
            }
        }

        public void Save(ConfigNode node)
        {
            node.AddValue("oneFloat", oneFloat);
            node.AddValue("twoFloat", twoFloat);
        }

        public override string ToString()
        {
            return "one=" + oneFloat + ", two=" + twoFloat;
        }
    }
}
