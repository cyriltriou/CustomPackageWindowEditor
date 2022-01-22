using UnityEngine;
using UnityEditor;
using System.IO;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

public class CustomPackageEditor : OdinMenuEditorWindow
{
    [MenuItem("Tools/Custom Package")]
    private static void OpenWindow()
    {
        GetWindow<CustomPackageEditor>().Show();
    }

    private CreateNewCustomPackage createNewCustomPackage;

    protected override void OnDestroy()
    {
        base.OnDestroy();

        if(createNewCustomPackage != null)
            DestroyImmediate(createNewCustomPackage.customPackage);
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();

        createNewCustomPackage = new CreateNewCustomPackage();
        tree.Add("Create New", createNewCustomPackage);
        tree.AddAllAssetsAtPath("Custom Package", "Assets/Scripts", typeof(CustomPackage));

        return tree;    
    }

    protected override void OnBeginDrawEditors()
    {
        OdinMenuTreeSelection selected = this.MenuTree.Selection;

        SirenixEditorGUI.BeginHorizontalToolbar();
        {
            GUILayout.FlexibleSpace();

            if(SirenixEditorGUI.ToolbarButton("Delete Current"))
            {
                CustomPackage asset = selected.SelectedValue as CustomPackage;
                string path = AssetDatabase.GetAssetPath(asset);
                AssetDatabase.DeleteAsset(path);
                AssetDatabase.SaveAssets();
            }
        }

        SirenixEditorGUI.EndHorizontalToolbar();
    }

    public class CreateNewCustomPackage
    {
        public CreateNewCustomPackage()
        {
            customPackage = ScriptableObject.CreateInstance<CustomPackage>();
            customPackage.name = "New Custom Package";
            
        }

        [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
        public CustomPackage customPackage;
        public CustomPackageAsmdef customPackageAsmdef;

        [Button("Add new CustomPackage SO")]
        private void CreateNewCustomPackageSO()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
            string parent = directoryInfo.Parent.ToString();
            string packagesPath = parent + "\\Packages\\";
            Directory.CreateDirectory(packagesPath + customPackage.name);
            string json = JsonUtility.ToJson(customPackage);
            File.WriteAllText(packagesPath + customPackage.name + "\\package.json", json);
            File.WriteAllText(packagesPath + customPackage.name + "\\CHANGELOG.md", string.Empty);
            File.WriteAllText(packagesPath + customPackage.name + "\\LICENSE.md", string.Empty);
            File.WriteAllText(packagesPath + customPackage.name + "\\README.md", string.Empty);
            Directory.CreateDirectory(packagesPath + customPackage.name + "\\Runtime");
            customPackageAsmdef = AssetDatabase.LoadAssetAtPath<CustomPackageAsmdef>("Assets/Scripts/Editor/CustomPackageAsmdef.asset");
            customPackageAsmdef.name = customPackage.name + ".Runtime";
            string jsonAsmdef = JsonUtility.ToJson(customPackageAsmdef);
            File.WriteAllText(packagesPath + customPackage.name + "\\Runtime\\" + customPackage.name + ".Runtime.asmdef", jsonAsmdef);
            Directory.CreateDirectory(packagesPath + customPackage.name + "\\Editor");
            customPackageAsmdef.name = customPackage.name + ".Editor";
            jsonAsmdef = JsonUtility.ToJson(customPackageAsmdef);
            File.WriteAllText(packagesPath + customPackage.name + "\\Editor\\" + customPackage.name + ".Editor.asmdef", jsonAsmdef);

            //Debug.Log(json);
            AssetDatabase.CreateAsset(customPackage, "Assets/Scripts/" + customPackage.name + ".asset");
            AssetDatabase.SaveAssets();

            // Create new instance of the SO
            customPackage = ScriptableObject.CreateInstance<CustomPackage>();
            customPackage.name = "New Custom Package";
           
        }
    }
    
}
