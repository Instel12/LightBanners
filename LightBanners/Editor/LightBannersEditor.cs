#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
using System;
using System.Reflection;

[CustomEditor(typeof(MonoBehaviour), true)]
public class LightBannersEditor : Editor
{
    private Texture2D banner;
    private bool checkedForBanner;

    public override void OnInspectorGUI()
    {
        if (!checkedForBanner)
        {
            TryLoadBanner();
            checkedForBanner = true;
        }

        DrawBanner();

        DrawDefaultInspector();
    }

    private void DrawBanner()
    {
        GUILayout.Space(6);

        float inspectorWidth = EditorGUIUtility.currentViewWidth - 32f;

        float aspect = (float)banner.width / banner.height;
        float height = inspectorWidth / aspect;

        Rect rect = GUILayoutUtility.GetRect(inspectorWidth, height);
        GUI.DrawTexture(rect, banner, ScaleMode.ScaleToFit);

        GUILayout.Space(4);
    }

    private void TryLoadBanner()
    {
        var type = target.GetType();
        var attr = type.GetCustomAttribute<LightBanners>();

        if (attr != null && !string.IsNullOrEmpty(attr.resourcePath))
        {
            banner = Resources.Load<Texture2D>(attr.resourcePath);
        }
    }
}
#endif