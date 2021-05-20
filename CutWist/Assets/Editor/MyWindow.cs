using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <Summary>
/// ウィンドウを作成するサンプルです。
/// </Summary>
public class MyWindow : EditorWindow
{
    /// <Summary>
    /// ウィンドウを表示します。
    /// </Summary>
    [MenuItem("Window/MyWindow")]
    static void Open()
    {
        var window = GetWindow<MyWindow>();
        window.titleContent = new GUIContent("オリジナルのウィンドウ");
    }
}