// Copyright (c) 2012-2021 FuryLion Group. All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Editor.Toolbar
{
    [InitializeOnLoad]
    public static class ToolbarExtender
    {
        public static readonly List<Action> LeftToolbarGUI = new();
        public static readonly List<Action> RightToolbarGUI = new();

        private static GUIStyle _CommandStyle;

        static ToolbarExtender()
        {
            ToolbarCallback.OnToolbarGUILeft = GUILeft;
            ToolbarCallback.OnToolbarGUIRight = GUIRight;
        }

        private static void GUILeft()
        {
            GUILayout.BeginHorizontal();
            foreach (var handler in LeftToolbarGUI)
            {
                handler();
            }

            GUILayout.EndHorizontal();
        }

        private static void GUIRight()
        {
            GUILayout.BeginHorizontal();
            foreach (var handler in RightToolbarGUI)
            {
                handler();
            }

            GUILayout.EndHorizontal();
        }
    }
}