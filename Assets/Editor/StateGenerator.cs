using UnityEngine;
using UnityEditor;
using System.IO;
using System.Text.RegularExpressions;

public class StateGenerator : EditorWindow
{
    private string stateName = "";

    [MenuItem("Tools/State Generator")]
    public static void ShowWindow()
    {
        GetWindow<StateGenerator>("State Generator");
    }

    private void OnGUI()
    {
        GUILayout.Label("ステート名を入力してください", EditorStyles.boldLabel);

        stateName = EditorGUILayout.TextField("ステート名", stateName);

        if (GUILayout.Button("ステートスクリプトを生成"))
        {
            if (!string.IsNullOrEmpty(stateName))
            {
                if (!IsStateNameExists(stateName))
                {
                    GenerateStateCode(stateName);
                    AddStateToEnum(stateName);
                    UpdateStateMachineClass(stateName);
                    AssetDatabase.Refresh();
                }
                else
                {
                    EditorUtility.DisplayDialog("エラー", "このステート名は既に存在します。異なる名前を入力してください。", "OK");
                }
            }
            else
            {
                EditorUtility.DisplayDialog("エラー", "有効なステート名を入力してください。", "OK");
            }
        }
    }

    private void GenerateStateCode(string stateName)
    {
        string className = stateName + "State";
        string code = $"using UnityEngine;\n\nnamespace Game\n{{\n\tpublic class {className} : IState\n\t{{\n\t\tprivate GameScene Scene;\n\n\t\tpublic {className}(GameScene scene)\n\t\t{{\n\t\t\tScene = scene;\n\t\t}}\n\n\t\tpublic void Enter()\n\t\t{{\n\t\t\t// Enter method code here\n\t\t}}\n\n\t\tpublic void MainUpdate()\n\t\t{{\n\t\t\t// MainUpdate method code here\n\t\t}}\n\n\t\tpublic void Exit()\n\t\t{{\n\t\t\t// Exit method code here\n\t\t}}\n\t}}\n}}";



        string directoryPath = Application.dataPath + "/Scripts/Game/GameState";
        if (!Directory.Exists(directoryPath))
        {
            Directory.CreateDirectory(directoryPath);
        }
        string path = Path.Combine(directoryPath, className + ".cs");

        File.WriteAllText(path, code);
    }

    private void AddStateToEnum(string stateName)
    {
        string enumPath = "Assets/Scripts/Game/StateMachine/StateName.cs";

        if (File.Exists(enumPath))
        {
            string content = File.ReadAllText(enumPath);

            // Find the position just before the closing curly brace
            int insertIndex = content.LastIndexOf('}');

            if (insertIndex >= 0)
            {
                // Insert the new state
                string newContent = content.Insert(insertIndex, $"\t{stateName},\n");

                // Write the modified content back to the file
                File.WriteAllText(enumPath, newContent);
            }
            else
            {
                EditorUtility.DisplayDialog("エラー", "enumファイルを解析できませんでした。", "OK");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("エラー", "enumファイルが見つかりません。", "OK");
        }
    }

    private bool IsStateNameExists(string stateName)
    {
        string enumPath = "Assets/Scripts/Game/StateMachine/StateName.cs";

        if (File.Exists(enumPath))
        {
            string content = File.ReadAllText(enumPath);
            return Regex.IsMatch(content, $@"\b{stateName}\b");
        }
        return false;
    }

    private void UpdateStateMachineClass(string stateName)
    {
        string stateMachinePath = "Assets/Scripts/Game/StateMachine/StateMachine.cs";

        if (File.Exists(stateMachinePath))
        {
            string content = File.ReadAllText(stateMachinePath);

            // Find the position just before the closing curly brace of the constructor
            int insertIndex = content.IndexOf("//StateDictに代入");

            if (insertIndex >= 0)
            {
                // Insert the new instance creation and adding to StateDict
                string toInsert = $"\n\t\t\tStateDict[StateName.{stateName}] = new {stateName}State(scene);";

                string newContent = content.Insert(insertIndex + "//StateDictに代入".Length, toInsert);

                // Write the modified content back to the file
                File.WriteAllText(stateMachinePath, newContent);
            }
            else
            {
                EditorUtility.DisplayDialog("エラー", "StateMachineクラスを解析できませんでした。", "OK");
            }
        }
        else
        {
            EditorUtility.DisplayDialog("エラー", "StateMachineクラスが見つかりません。", "OK");
        }
    }
}
