The package provides a simple window editor to build a unity custom package. 

Alpha version of this package. To use as a preview with no guaranty.

How to install ?

This package is installed in Unity by selecting the git install. In the + button at up corner select in the dropdownlist Add package from git URL. 
Copy past the following Git Url: https://github.com/cyriltriou/CustomPackageWindowEditor.git
For more information about installation of package through git URL consult the page: https://docs.unity3d.com/Manual/upm-git.html#syntax

The package has a dependency on Odin - Inspector and Serializer. You can buy it from Asset Store here: https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041

How to use ?

In fact the system is quiet simple. You start by creating a folder "Scripts" and inside create a new folder called "Editor". After you create a SO instance in Unity menu Assets > Create > Noovisphere Studio > Custom Package > New asmdef.
Place this SO asset in the folder have just created before if it is not already there.

Now you can open the window editor in menu Tools > Custom Package. 

Click the button "Create New" and fill in the following fields:
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

The most important field is the field Name. It is required to name it correctly with the right convention: <domain-name-extension>.<company-name>
Detail of naming: https://docs.unity3d.com/Manual/cus-naming.html

Note: 
- The field "Dependencies" can be udpdated from here and might be updated manually directly by opening the file package.json later.
- The field "Keywords" is not managed yet and can be updated also manually later.
- The field "Custom Package Asmdef" must still be empty because it is assigned directly from the script.

When all fields are filled in, click on the button "Add new custom package SO".

All the structure to welcome a new custom package has been created in the folder "Packages".

Now, you need to copy your scripts in the folders: 
- Runtime 
- Editor

You can also write the following files to decribe your package:
- Readme.md
- License.md
- Changelog

It is a simple window editor and then you can also perform some others manual actions to add a folder for Documentation named "Documentation~". "~" when added at the end of a folder hiddes it in Unity Editor. Then you can places also a file Documentation.md for a more advanced documentation.

In the left panel of the Window Editor you can see the new custom packages listed and their content is displayed when you click the package.

You can also remove one our your profile for Custom Package by clicking the button at the up right corner called "Delete Current".

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