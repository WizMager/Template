using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Editor.Toolbar
{
    [InitializeOnLoad]
    public class PlayFromFirstScene
    {
        static PlayFromFirstScene()
        {
            ToolbarExtender.RightToolbarGUI.Add(OnToolbarGUI);
        }

        private static void OnToolbarGUI()
        {
            if (EditorApplication.isPlaying)
                return;

            if (EditorBuildSettings.scenes.Length == 0)
                return;

            if (GUILayout.RepeatButton(Icons.Play, Styles.ToolbarButton))
            {
                void SceneLoaded(Scene scene, OpenSceneMode mode)
                {
                    EditorApplication.isPlaying = true;

                    EditorSceneManager.sceneOpened -= SceneLoaded;
                }

                EditorSceneManager.sceneOpened += SceneLoaded;
                EditorSceneManager.OpenScene(EditorBuildSettings.scenes[0].path, OpenSceneMode.Single);
            }
        }

        private static class Icons
        {
            public static readonly GUIContent Play;

            static Icons()
            {
                Play = new GUIContent(EditorGUIUtility.IconContent("d_preAudioAutoPlayOff@2x"));
            }
        }

        private static class Styles
        {
            public static readonly GUIStyle ToolbarButton;

            static Styles()
            {
                ToolbarButton = new GUIStyle("toolbarbutton")
                {
                    fixedWidth = 30,
                    imagePosition = ImagePosition.ImageAbove
                };
            }
        }
    }
}