using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using SevenZip;

namespace VersionReleaseManager
{
    public class VRManager : IDisposable
    {
        ~VRManager()
        {
        }
        public void Dispose()
        {
            // 释放资源的代码
        }

        public Configuration Configuration { get; set; } = new Configuration();

        public void Main(string[] args)
        {
            string repoUrl = "https://github.com/YuLuo00/VersionReleaseManager.git"; // 替换为你的 Git 仓库地址
            string cloneDir = @"D:\path\to\clone"; // 替换为克隆目录
            string installDir = @"D:\path\to\install"; // 替换为安装目录
            string tagName = "demo_v1.0.0"; // 替换为你想要的标签名
            new Release().exec(repoUrl, cloneDir, installDir, null, null, tagName);
        }

        public bool Release(string repoUri, string branch, string tagName)
        {


            return true;
        }
    }
}
