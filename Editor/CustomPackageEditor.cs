using System.IO;
using UnityEngine;
using UnityEditor;
using Sirenix.OdinInspector;
using Sirenix.OdinInspector.Editor;
using Sirenix.Utilities.Editor;

namespace NoovisphereStudio { 
    public class CustomPackageEditor : OdinMenuEditorWindow
    {
        [MenuItem("Tools/Noovisphere Studio/Custom Package")]
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
            tree.AddAllAssetsAtPath("Custom Package", "Assets/ScriptableObjects", typeof(CustomPackage));

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

                if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
                {
                    var SoFolder = AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
                }

                customPackageAsmdef = AssetDatabase.LoadAssetAtPath<CustomPackageAsmdef>("Assets/ScriptableObjects/CustomPackageAsmdef.asset");
                if (customPackageAsmdef == null)
                {                    
                    customPackageAsmdef = ScriptableObject.CreateInstance<CustomPackageAsmdef>();
                    customPackageAsmdef.name = "CustomPackageAsmdef";
                    AssetDatabase.CreateAsset(customPackageAsmdef, "Assets/ScriptableObjects/CustomPackageAsmdef.asset");
                    AssetDatabase.SaveAssets();
                    customPackageAsmdef = AssetDatabase.LoadAssetAtPath<CustomPackageAsmdef>("Assets/ScriptableObjects/CustomPackageAsmdef.asset");
                }
            }

            [InlineEditor(ObjectFieldMode = InlineEditorObjectFieldModes.Hidden)]
            public CustomPackage customPackage;
            public CustomPackageAsmdef customPackageAsmdef;            

            [Button("Add Custom Package")]
            private void CreateNewCustomPackageSO()
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Application.dataPath);
                string parent = directoryInfo.Parent.ToString();
                string packagesPath = parent + "\\Packages\\";
                //string packagesPath = parent + "\\Assets\\";
                Directory.CreateDirectory(packagesPath + customPackage.name);
                string json = JsonUtility.ToJson(customPackage);
                File.WriteAllText(packagesPath + customPackage.name + "\\package.json", json);
                File.WriteAllText(packagesPath + customPackage.name + "\\CHANGELOG.md", string.Empty);
                File.WriteAllText(packagesPath + customPackage.name + "\\LICENSE.md", string.Empty);
                File.WriteAllText(packagesPath + customPackage.name + "\\README.md", string.Empty);
                Directory.CreateDirectory(packagesPath + customPackage.name + "\\Runtime");
            
                customPackageAsmdef.name = customPackage.name + ".Runtime";
                string jsonAsmdef = JsonUtility.ToJson(customPackageAsmdef);
                File.WriteAllText(packagesPath + customPackage.name + "\\Runtime\\" + customPackage.name + ".Runtime.asmdef", jsonAsmdef);
                Directory.CreateDirectory(packagesPath + customPackage.name + "\\Editor");
                customPackageAsmdef.name = customPackage.name + ".Editor";
                jsonAsmdef = JsonUtility.ToJson(customPackageAsmdef);
                File.WriteAllText(packagesPath + customPackage.name + "\\Editor\\" + customPackage.name + ".Editor.asmdef", jsonAsmdef);
                
                AssetDatabase.CreateAsset(customPackage, "Assets/ScriptableObjects/" + customPackage.name + ".asset");
                AssetDatabase.SaveAssets();
                
                customPackage = ScriptableObject.CreateInstance<CustomPackage>();
                customPackage.name = "New Custom Package";           
            }
        }    
    }
}
