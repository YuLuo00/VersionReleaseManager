using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;
using static VersionReleaseManager.Configuration;
using System.Runtime.CompilerServices;
using System.Numerics;

namespace VersionReleaseManager
{
    internal class Configuration
    {
        public List<ConfigUnit> units { get; set; } = new List<ConfigUnit>();
        string DefaultConfigName { get; set; } = "VR_Config.json";

        public void ReadFromFile(string? filePath = null)
        {
            if (string.IsNullOrWhiteSpace(filePath)) {
                filePath = "./" + DefaultConfigName;
            }
            if (!File.Exists(filePath)) {
                return;
            }
            string filePathFull = Path.GetFullPath(filePath);

            string fileText = File.ReadAllText(filePathFull);
            Configuration? config = JsonSerializer.Deserialize<Configuration>(fileText);
            if (config != null) {
                this.CopyFrom(config);
            }
            return;
        }

        public void Dump(string? filePath = null)
        {
            if (string.IsNullOrWhiteSpace(filePath)) {
                filePath = "./" + DefaultConfigName;
            }

            string dumpStr = JsonSerializer.Serialize(this);
            string filePathFull = Path.GetFullPath(filePath);
            File.WriteAllText(filePathFull, dumpStr);
        }

        void CopyFrom(Configuration other)
        {
            this.units = other.units;
        }
    }

    public class ConfigUnit
    {
        public string ProjectName { get; set; }
        public string RepoUrl { get; set; }
        public string? brachName { get; set; }
    }
    //public enum BuildType
    //{
    //    CMakeLists,
    //    MSVC_CPP,
    //    MSVC_CSharp
    //};
}
