using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Provides access to configuration data
/// </summary>
public static class ConfigurationUtils
{
    static private ConfigurationData data;
    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public static float PaddleMoveUnitsPerSecond
    {
        get { return data.PaddleMoveUnitsPerSecond; }
    }

    public static float BallImpulseForce
    {
        get { return data.BallImpulseForce; }
    }
    #endregion

    /// <summary>
    /// Initializes the configuration utils
    /// </summary>
    public static void Initialize()
    {
        data = new ConfigurationData();
        Console.WriteLine("aaa");
    }
}
