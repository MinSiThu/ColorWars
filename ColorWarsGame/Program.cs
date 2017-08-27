﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

namespace ColorWars
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ColorWarsSettings settings;
            try
            {
                settings = Newtonsoft.Json.JsonConvert.DeserializeObject<ColorWarsSettings>(File.ReadAllText("settings.json"));
            }
            catch (FileNotFoundException)
            {
                settings = new ColorWarsSettings();

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(settings, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText("settings.json", json);
            }

            using (var game = new ColorWarsGame(settings))
                game.Run();
        }
    }
}
