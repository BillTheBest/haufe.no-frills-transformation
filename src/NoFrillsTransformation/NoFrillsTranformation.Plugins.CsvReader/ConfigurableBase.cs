﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoFrillsTranformation.Plugins.Csv
{
    public class ConfigurableBase
    {
        protected void ReadConfig(string config)
        {
            if (string.IsNullOrWhiteSpace(config))
                return;

            string[] configPairs = config.Split(' ');
            foreach (var configPair in configPairs)
            {
                string[] parts = configPair.Split('=');
                if (parts.Length != 2)
                    throw new ArgumentException("Configuration part '" + configPair + "' does not have the correct format (<configuration>=<setting>)");

                string parameter = parts[0].ToLowerInvariant();
                string configuration = parts[1].Trim();
                if (configuration.StartsWith("'") && configuration.EndsWith("'"))
                    configuration = configuration.Substring(1, configuration.Length - 2); // Strip ''
                SetConfig(parameter, configuration);
            }
        }

        protected virtual void SetConfig(string parameter, string configuration)
        {
            // Empty here.
        }
    }
}
