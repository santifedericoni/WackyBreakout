using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// A container for the configuration data
/// </summary>
public class ConfigurationData
{
    #region Fields

    const string ConfigurationDataFileName = "ConfigurationData.csv";

    // configuration data
     float paddleMoveUnitsPerSecond = 10;
     float ballImpulseForce = 200;
    static String paddleMoveUnitsPerSecondName = "paddleMoveUnitsPerSecond";
    static String ballImpulseForceName = "ballImpulseForce";
    #endregion

    #region Properties

    /// <summary>
    /// Gets the paddle move units per second
    /// </summary>
    /// <value>paddle move units per second</value>
    public float PaddleMoveUnitsPerSecond
    {
        get { return paddleMoveUnitsPerSecond; }
    }

    /// <summary>
    /// Gets the impulse force to apply to move the ball
    /// </summary>
    /// <value>impulse force</value>
    public float BallImpulseForce
    {
        get { return ballImpulseForce; }    
    }

    #endregion

    #region Constructor

    /// <summary>
    /// Constructor
    /// Reads configuration data from a file. If the file
    /// read fails, the object contains default values for
    /// the configuration data
    /// </summary>
    public ConfigurationData()
    {
        try
        {
            String fileName = Path.Combine(Application.streamingAssetsPath, ConfigurationDataFileName);
            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    String[] values = line.Split('=');
                    if (values[0] == paddleMoveUnitsPerSecondName)
                    {
                        paddleMoveUnitsPerSecond = float.Parse(values[1]);

                    }
                    else if (values[0] == ballImpulseForceName)
                    {
                        ballImpulseForce = float.Parse(values[1]);
                    }
                    else {
                        throw new Exception("can't parse data");
                    }
                }

            }

                //leer desde el archivo y separar las comas, y asignar valores a las variables en esta clase
            }
        catch (Exception e)
        {
            Console.WriteLine("aaa");
            //asignar a las variables los valores por default (static)
        }
        
    }

    #endregion
}
