using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using SevenZip;
using VersionReleaseManagerUI;

namespace VersionReleaseManager
{
    internal class Program : IDisposable
    {
        ~Program()
        {
        }
        public void Dispose()
        {
            // 释放资源的代码
        }


        static void Main(string[] args)
        {
            string repoUrl = "https://github.com/YuLuo00/VersionReleaseManager.git"; // 替换为你的 Git 仓库地址
            string cloneDir = @"D:\path\to\clone"; // 替换为克隆目录
            string installDir = @"D:\path\to\install"; // 替换为安装目录
            string tagName = "demo_v1.0.0"; // 替换为你想要的标签名
            new Release().exec(repoUrl, cloneDir, installDir, null, null, tagName);
        }
    }
}
