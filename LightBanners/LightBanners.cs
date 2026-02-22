using System;
using UnityEngine;

[AttributeUsage(AttributeTargets.Class, Inherited = true, AllowMultiple = false)]
public class LightBanners : Attribute
{
    public string resourcePath;

    public LightBanners(string resourcePath)
    {
        this.resourcePath = resourcePath;
    }
}