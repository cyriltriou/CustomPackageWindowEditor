using System;
using UnityEngine;

public class CustomPackage: ScriptableObject
{
    public new string name;
    public string version;
    public string displayName;
    public string description;
    public string unity;
    public string documentationUrl;
    public string changelogUrl;
    public string licensesUrl;
    public Dependencies dependencies;
    public Keyword[] keywords;
    public Author author;
}

[Serializable]
public class Dependencies
{

}

[Serializable]
public class Keyword
{

}

[Serializable]
public class Author
{
    public string name;
    public string email;
    public string url;
}