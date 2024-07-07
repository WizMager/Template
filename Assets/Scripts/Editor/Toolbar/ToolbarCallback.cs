using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace Editor.Toolbar
{
    public static class ToolbarCallback
    {
        public static Action OnToolbarGUILeft;
        public static Action OnToolbarGUIRight;
        
        private static readonly Type ToolbarType = typeof(UnityEditor.Editor).Assembly.GetType("UnityEditor.Toolbar");

        private static ScriptableObject _CurrentToolbar;

        static ToolbarCallback()
        {
            EditorApplication.update -= OnUpdate;
            EditorApplication.update += OnUpdate;
        }

        static void OnUpdate()
        {
            if (_CurrentToolbar == null)
            {
                var toolbars = Resources.FindObjectsOfTypeAll(ToolbarType);
                _CurrentToolbar = toolbars.Length > 0 ? (ScriptableObject) toolbars[0] : null;
                if (_CurrentToolbar != null)
                {
                    var rootType = _CurrentToolbar.GetType();
                    var root = rootType.GetField("m_Root", BindingFlags.NonPublic | BindingFlags.Instance);
                    var rawRoot = root.GetValue(_CurrentToolbar);
                    var mRoot = rawRoot as VisualElement;
                    
                    RegisterCallback("ToolbarZoneLeftAlign", OnToolbarGUILeft);
                    RegisterCallback("ToolbarZoneRightAlign", OnToolbarGUIRight);

                    void RegisterCallback(string root, Action cb)
                    {
                        var toolbarZone = mRoot.Q(root);

                        var parent = new VisualElement
                        {
                            style =
                            {
                                flexGrow = 1,
                                flexDirection = FlexDirection.Row,
                            }
                        };
                        
                        var container = new IMGUIContainer();
                        
                        container.onGUIHandler += () => { cb?.Invoke(); };
                        parent.Add(container);
                        toolbarZone.Add(parent);
                    }
                }
            }
        }
    }
}