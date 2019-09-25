using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class CreateScene : EditorWindow
{
    private static bool s_isActive = true;

    static CreateScene()
    {
        UnityEditor.SceneManagement.EditorSceneManager.newSceneCreated += EditorSceneManager_newSceneCreated;
        UnityEditor.SceneManagement.EditorSceneManager.sceneOpened += EditorSceneManager_sceneOpened;
    }

    private static void SetupScene(bool _isNew)
    {
        GameObject oldMainCam = Camera.main.gameObject;
        if (_isNew && oldMainCam != null)
        {
            DestroyImmediate(oldMainCam);
        }

        GameObject sceneSettings = FindObjectOfType<UnityEngine.Experimental.Rendering.HDPipeline.StaticLightingSky>()?.gameObject;
        if (!sceneSettings)
        {
            var tmp = Resources.Load<GameObject>("_SceneSetups/SceneSettings");

            tmp.name = "Scene Settings";
            Instantiate(tmp);
        }

        GameObject player = FindObjectOfType<CC>()?.gameObject;
        if (!player)
        {
            var tmp = Resources.Load<GameObject>("_SceneSetups/Player");
            Instantiate(tmp);
            tmp.name = "Player";
        }
    }

    private static void EditorSceneManager_newSceneCreated(UnityEngine.SceneManagement.Scene scene, UnityEditor.SceneManagement.NewSceneSetup setup, UnityEditor.SceneManagement.NewSceneMode mode)
    {
        SetupScene(true);
    }

    private static void EditorSceneManager_sceneOpened(UnityEngine.SceneManagement.Scene scene, UnityEditor.SceneManagement.OpenSceneMode mode)
    {
        SetupScene(false);
    }
}
