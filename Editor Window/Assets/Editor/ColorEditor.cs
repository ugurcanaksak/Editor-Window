using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ColorEditor : EditorWindow
{
    Color matColor = Color.white;

    [MenuItem("Color/Color Change")]
    static void Init()
    {
        EditorWindow window = GetWindow(typeof(ColorEditor));
        window.Show();
    }

    void OnGUI()
    {
        matColor = EditorGUILayout.ColorField("New Color", matColor);

        if (GUILayout.Button("Change!"))
            ChangeColors();
    }

    private void ChangeColors()
    {

        if (Selection.activeGameObject)
            foreach (GameObject t in Selection.gameObjects)
            {
                Renderer rend = t.GetComponent<Renderer>();

                if (rend != null)
                    rend.sharedMaterial.color = matColor;
            }
    }
}

