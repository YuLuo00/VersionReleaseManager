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
    public class Configuration
    {
        public List<ConfigUnit> Units { get; set; } = new List<ConfigUnit>();
        private string DefaultConfigName { get; set; } = "VR_Config.json";

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

        private void CopyFrom(Configuration other)
        {
            this.Units = other.Units;
        }
    }

    public class ConfigUnit
    {
        public string ProjectName { get; set; }
        public string RepoUrl { get; set; }
        public string? BrachName { get; set; }
        /// <summary>
        /// 用于发布的基准文件，CMakeLists.txt, bat，或者其他脚本，可执行文件等（包含路径）
        ///     默认是更目录的CMakeLists.txt
        ///     脚本参数协议:
        ///     --version      版本号
        ///     --tag          发布到git的tag名
        ///     --output_dir   待发布文件的输出路径
        /// </summary>
        public string ReleaseBase { get; set; } = "./CMakeLists.txt";
        /// <summary>
        /// 编译配置，Release/Debug等
        /// </summary>
        public string CompileConfig { get; set; } = "Release";
    }
    //public enum BuildType
    //{
    //    CMakeLists,
    //    MSVC_CPP,
    //    MSVC_CSharp
    //};
}
