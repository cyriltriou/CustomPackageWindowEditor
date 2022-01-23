The package provides a simple window editor to build a unity custom package. 
Be careful!
The package has a strong dependency on the another asset "Odin - Inspector and Serializer". You can buy it from Asset Store here: https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041

Alpha version of this package. To use as a preview with no guaranty.

How to install ?

This package is installed in Unity Editor by selecting the git install. In package manager, click on the "+" button at up corner select in the dropdownlist Add package from git URL. 
Copy past the following Git Url and enter: https://github.com/cyriltriou/CustomPackageWindowEditor.git
For more information about installation of package through git URL consult the page: https://docs.unity3d.com/Manual/upm-git.html#syntax

How to use ?

In fact the system is quiet simple. Open the window editor in menu Tools > Custom Package. A new folder called "ScriptableObjects is created in Assets folder. When you add new custom package the profile of these assets that are Scriptable Objects instances are saved in this folder.

When the Window Edito is displayed, you click the button "Create New" and you fill in the following fields:
- Name
- Version
- Display name
- Description
- Unity 
- Documentation Url
- Changelog Url
- Licenses Url
- Author:
    - Name
    - Email
    - Url

The full description of the package manifest package.json is described in the following page: https://docs.unity3d.com/Manual/upm-manifestPkg.html

The most important field is the field Name. It is required to name your custom package correctly with the right convention: <domain-name-extension>.<company-name>
Detail of naming: https://docs.unity3d.com/Manual/cus-naming.html

Of course, most of fields are not required as explained in the documentation but it makes sense describes your custom package.

Note: 
- The field "Dependencies" can be udpdated from here and might be updated manually directly by opening the file package.json later.
- The field "Keywords" is not managed yet and can be updated also manually later.
- The field "Custom Package Asmdef" is created on the fly then there is nothing to do here.

When all fields are filled in, click on the button "Add Custom Package".

The result is that all the structure to welcome a new custom package has been created in the folder "Packages" according to the recommendations of the Unity documentation (see link above).

You will get a warning, somthing like:
Assembly for Assembly Definition File 'Packages/noovispherestudio.custompackage/Runtime/noovispherestudio.custompackage.Runtime.asmdef' will not be compiled, because it has no scripts associated with it.
UnityEditor.Scripting.ScriptCompilation.EditorCompilationInterface:TickCompilationPipeline (UnityEditor.Scripting.ScriptCompilation.EditorScriptCompilationOptions,UnityEditor.BuildTargetGroup,UnityEditor.BuildTarget,string[])

It is normal! It means that you did not provide scripts into your package yet...

...Now, the last action but the least, you need to copy your scripts in the folders: 
- Runtime: put here all scripts that are not editor 
- Editor: put all Editor scripts

You should also describe your package by completing the following files:
- Readme.md
- License.md
- Changelog

It is a simple window editor and then you can also perform some others manual actions to add a folder for Documentation named "Documentation~". "~" when added at the end of a folder hiddes it in Unity Editor. Then you can places also a file Documentation.md for a more advanced documentation.

In the left panel of the Window Editor you can see the new custom packages listed and their content is displayed when you click the package.

You can also remove one of your custom package profile by clicking the button at the up right corner called "Delete Current".

Example:
- Name = noovisphere.custompackage
- Version = 1.0.0
- Display name = Custom Package Generator
- Description = A simple system to create your owned custom package
- Unity = 2020.3
- Documentation Url = https://noovisphere.com/custompackage/doc
- Changelog Url = https://noovisphere.com/custompackage/changelog
- Licenses Url = https://noovisphere.com/custompackage/licenses
- Author:
    - Name = Cyril TRIOU
    - Email = cyril.triou@gmail.com
    - Url = https://noovisphere.com

How to go further?
Well when you package is finished you can publish it by putting it in a zip archive for a local storage or in github or a "github like" as explained at the end of the video below (7min).

What is the story of this package?

The idea was to automate the manual process that is described on the unity manual: https://docs.unity3d.com/Manual/CustomPackages.html
A video that shows step by step how to build a such package manually: https://www.youtube.com/watch?v=mgsLb3TKljk&t=149s

Next release:
- Be able to update a package 
- Be able to add keywords
- Be able to add dependencies if it is possible to create a dynamic field in json
- Be able to delete the package in packages not only the SO.