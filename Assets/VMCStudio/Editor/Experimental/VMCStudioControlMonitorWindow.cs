﻿using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEditor.Experimental.UIElements;


public class VMCStudioControlMonitorWindow : EditorWindow
{
    [MenuItem("Window/Experimental/VMCStudio Control")]
    public static void ShowExample()
    {
        VMCStudioControlMonitorWindow wnd = GetWindow<VMCStudioControlMonitorWindow>();
        wnd.titleContent = new GUIContent("VMCStudioControlMonitorWindow");
    }

    public void OnEnable()
    {
        // Each editor window contains a root VisualElement object
        VisualElement root = this.GetRootVisualContainer();

        // Import UXML
        var visualTree = AssetDatabase.LoadAssetAtPath("Assets/VMCStudio/Editor/Experimental/VMCStudioControlMonitorWindow.uxml", typeof(VisualTreeAsset)) as VisualTreeAsset;
        VisualElement labelFromUXML = visualTree.CloneTree(null);
        root.Add(labelFromUXML);


        int i = 0;
        root.Query<Foldout> ("foldout")
            .Children<Button> ()
            .ForEach (button => {
                int x = i++;
                button.clickable.clicked += () => Debug.Log ($"ボタン{x}が押された");
            });
    }

}