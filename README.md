> *** Note ***
> This package is useful in Unity 3D Engine context!

# Overview
- [Overview](#overview)
- [Introduction](#introduction)
- [How to install ?](#how-to-install-)
- [How to use ?](#how-to-use-)
- [Manuel actions](#manuel-actions)
- [Example](#example)
- [How to publish your new custom package?](#how-to-publish-your-new-custom-package)
- [How to go further?](#how-to-go-further)
- [The story of this package](#the-story-of-this-package)
- [Next release](#next-release)

# Introduction

The package ***Custom Package Window Editor*** provides a simple window editor that generates a unity custom package. The generated package is equivalent to packages that you can find into Package Manager and when hosted can be accessible anywhere.

> ***Note***
> The package has a strong dependency on the another asset **"Odin - Inspector and Serializer"**.
> You can buy this awesome asset from Asset Store: 
> - <https://assetstore.unity.com/packages/tools/utilities/odin-inspector-and-serializer-89041>

> ***About current Version***
> This is an ***alpha version*** of this package, you can freely use it! But, it might be not free of bugs.

# How to install ?

This package is installed in Unity Editor by selecting the git install in package manager. 
1. Open package manager 
2. Click on the **+** button at up corner select in the dropdownlist Add package from git URL:

![Add package from git URL](./Doc/Add%20package%20from%20git%20URL.png) 

3. Copy past the following Git Url and enter: 
   https://github.com/cyriltriou/CustomPackageWindowEditor.git

![Copy URL](./Doc/Copy%20git%20URL.png)

> ***Note***
>For more information about installation of package through git >URL consult the page: ***[https://docs.unity3d.com/Manual/upm-git.html#syntax](https://docs.unity3d.com/Manual/upm-git.html#syntax)***

# How to use ?

Actually, this custom package is straighforward thanks to the new editor window that is now available from the unity editor menu.

1. Open the window editor in menu Tools > Custom Package: 
   
![Screenshot](./Doc/Custom%20Package%20Editor%20Windows.png)

>***Note***
>A new folder called ***ScriptableObjects*** is created in ***Assets folder***. When you add a new custom package the profile of these assets that are purely ***Scriptable Objects instances*** are saved in this folder.

2. When the Window Editor is displayed, you click the button ***"Create New"*** and you fill in the following fields:
- Required properties:
  - Name
  - Version
- Recommended properties:
  - Display name
  - Description
  - Unity 
- Optional properties:
  - Documentation Url
  - Changelog Url
  - Licenses Url
  - Author:
    - Name
    - Email
    - Url

The full description of the ***package manifest package.json*** is described in the following page:
 
 - [https://docs.unity3d.com/Manual/upm-manifestPkg.html](https://docs.unity3d.com/Manual/upm-manifestPkg.html)


The most important fields are the fields ***Name*** and ***VErsion***. It is required to name your custom package correctly with the right convention and give a version: 

- `com.<domain-name-extension>.<company-name>`

With `<domain-name-extension>` is the name of your domain and `<company-name>` is the name of your company.

The detail of naming convention is described in the following link: 
- [https://docs.unity3d.com/Manual/cus-naming.html](https://docs.unity3d.com/Manual/cus-naming.html)

Of course, most of fields are not required as explained in the documentation but it makes sense to describe your custom package as good as possible.

>***Note*** 
>- The field ***Dependencies*** can be udpdated from here and might be updated manually directly by opening the file ***package.json*** later.
>- The field ***Keywords*** is not managed yet and can be updated also manually later.
>- The field ***Custom Package Asmdef*** is created on the fly by this editor tool then there is nothing to do manually here.

1. When all fields are filled in, click on the button ***Add Custom Package***.

The result is that all the structure welcomes a new custom package that has been created in the folder ***Packages*** according to the recommendations of the Unity documentation (see [link](https://docs.unity3d.com/Manual/upm-manifestPkg.html) provided above).

You will get a warning, something like:

```
Assembly for Assembly Definition File 'Packages/noovispherestudio.custompackage/Runtime/noovispherestudio.custompackage.Runtime.asmdef' will not be compiled, because it has no scripts associated with it.
UnityEditor.Scripting.ScriptCompilation.EditorCompilationInterface:TickCompilationPipeline (UnityEditor.Scripting.ScriptCompilation.EditorScriptCompilationOptions,UnityEditor.BuildTargetGroup,UnityEditor.BuildTarget,string[])
```

It is normal! It means that you did not provide scripts into your package yet...

...Now, the last action but not the least, you need to copy your scripts in the dedicated folders:

- ***Runtime***: put here all scripts that are not editor scripts
- ***Editor***: put all Editor scripts

>***Note***
>You should also describe your package by completing the following files:
>- ***Readme.md***: describe your package to help user to understand its usage. You can use [markdown](https://www.markdownguide.org/basic-syntax/) to beautify the reading.
>- ***License.md***: describe the license information that comes with usage of your package like MIT, Apache, GNU, etc... 
>- ***Changelog***: help your user to keep track of changes of your package.

# Manuel actions

In custom window editor you can also perform some others manual actions like adding a folder for Documentation named **Documentation~**. For information, the tild **~** when added at the end of a folder hiddes it in Unity Editor. Then you can place also a file Documentation.md for a more advanced documentation.

In the left panel of the Window Editor you can see the new custom packages profile listed and their content is displayed when you click the package.

You can also remove one of your custom package profile by clicking the button at the up right corner called "Delete Current".

# Example

The following example shows how you can fill in the fields of your custom package:

- Name = ***noovisphere.custompackage***
- Version = ***1.0.0**
- Display name = ***Custom Package Generator***
- Description = ***A simple system to create your owned custom package***
- Unity = ***2020.3***
- Documentation Url = https://noovisphere.com/custompackage/doc
- Changelog Url = https://noovisphere.com/custompackage/changelog
- Licenses Url = https://noovisphere.com/custompackage/licenses
- Author:
    - Name = ***Cyril TRIOU***
    - Email = ***cyril.triou@gmail.com***
    - Url = ***https://noovisphere.com***

# How to publish your new custom package?

Your custom package has been created in the folder ***Packages*** but it is not visible into the project tree. That is normal. In fact, this package must be installed somewhere else, meaning ouside the project itself. 

The goal is to make it available from package manager for others unity projects. It might be also a suitable way to split your current project to isolate a part of the code as an asset and reimport it through a package.

It also means that the lifecycle of this package will leave in another unity project as it is not possible to change the packages installed in the folder ***Packages*** because it is ***ummutable*** (consult the links below to ***Understand the full picture***).

So, the place where you make your package available is called ***a registry***:
- Read [Sharing your package](https://docs.unity3d.com/Manual/cus-share.html) to see the different possibilities.

# How to go further?

When your package is finished you need to make it available. Then you can publish it by putting it into a ***zip archive*** for a ***local storage*** or ***into github*** or a "***github like***" as **e**xplained at the end of the video below (7min) or in your owned unity registry as mentioned above (see how to create a npm registry for unity on Google).

# The story of this package

What is the story of this package?

The idea was to automate the manual process that is described on the unity manual: 

- [https://docs.unity3d.com/Manual/CustomPackages.html](https://docs.unity3d.com/Manual/CustomPackages.html)

A video that shows step by step how to build a such package manually:

- [https://www.youtube.com/watch?v=mgsLb3TKljk&t=149s](https://www.youtube.com/watch?v=mgsLb3TKljk&t=149s)

Some others useful documentation pages can help you to understand better package management proposed by Unity:

- Asset package with ***.unitypackage*** vs ***custom package*** that is the recommendation to go: [https://docs.unity3d.com/Manual/AssetPackagesCreate.html](https://docs.unity3d.com/Manual/AssetPackagesCreate.html)

- To understand the full picture of Unity’s Package Manager, read the following page: [https://docs.unity3d.com/Manual/Packages.html](https://docs.unity3d.com/Manual/Packages.html)


# Next release

In the next release, some improvments might be proposed like to following ones:

- Be able to update a package 
- Be able to add keywords
- Be able to add dependencies if it is possible to create a dynamic field in json
- Be able to delete the package in packages not only the SO.
