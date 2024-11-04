using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using SevenZip;

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

        public string CmakeExePath { get { return cmakeExePath; } }
        private string cmakeExePath = "D:\\_file\\？？\\cmake-3.30.2-windows-x86_64\\cmake-3.30.2-windows-x86_64\\bin\\cmake.exe";

        static void Main(string[] args)
        {
            string repoUrl = "https://github.com/zeux/meshoptimizer.git"; // 替换为你的 Git 仓库地址
            string cloneDir = @"D:\path\to\clone"; // 替换为克隆目录
            string installDir = @"D:\path\to\install"; // 替换为安装目录
            string tagName = "v1.0.0"; // 替换为你想要的标签名

            using (var test = new Program()) {
                tagName = "v1,1,1";
            }
            new Program().exec(repoUrl, cloneDir, installDir, "test tag version");
        }

        void exec(string repoUrl, string cloneDir,
                  string installDir, string? compileDir = null, string? tagName = null)
        {
            // 清空目标目录
            Program.RemoveIfExist(cloneDir);
            Directory.CreateDirectory(cloneDir);

            // 克隆 Git 仓库
            RunCommand("git", $"clone {repoUrl} {cloneDir}");

            // 切换到克隆目录
            Directory.SetCurrentDirectory(cloneDir);

            // 创建标签
            if(String.IsNullOrEmpty(tagName) == false) {
                RunCommand("git", $"tag {tagName}");
                RunCommand("git", $"push origin {tagName}"); // 推送标签到远程
            }

            // 生成构建目录
            string buildDir = Path.Combine(cloneDir, "build");
            Directory.CreateDirectory(buildDir);
            Directory.SetCurrentDirectory(buildDir);

            string cmakeDir = compileDir ?? "..";
            cmakeDir = "..";
            // CMake 编译
            RunCommand($"{CmakeExePath}", $"{cmakeDir} -DCMAKE_INSTALL_PREFIX={installDir}");
            RunCommand($"{CmakeExePath}", "--build . --target install");

            // 压缩安装目录
            string zipPath = $"{installDir}.zip";
            Program.RemoveIfExist(zipPath);
            ZipFile.CreateFromDirectory(installDir, zipPath);

            Console.WriteLine("编译和打包完成。");
        }

        static void RunCommand(string command, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = command,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };


            using (var process = Process.Start(processInfo)) {
                process.WaitForExit();

                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (process.ExitCode != 0) {
                    Console.WriteLine($"错误: {error}");
                    throw new Exception($"命令执行失败: {command} {arguments}");
                }

                Console.WriteLine(output);
            }
        }

        string directoryPath = @"D:\path\to\your\directory"; // 替换为你的目录路径

        static void SetFileAccessNormal(string directoryPath)
        {
            try {
                // 获取目录中的所有文件
                string[] files = Directory.GetFiles(directoryPath, "*.*", SearchOption.AllDirectories);

                foreach (var file in files) {
                    // 设置文件属性为 Normal
                    File.SetAttributes(file, FileAttributes.Normal);
                    //Console.WriteLine($"已设置文件属性为 Normal: {file}");
                }

                Console.WriteLine($"所有文件的属性已成功设置为 Normal。{directoryPath}");
            }
            catch (Exception ex) {
                Console.WriteLine($"操作失败: {ex.Message}");
            }
        }

        static void RemoveIfExist(string path)
        {
            try {
                // 检查路径是否存在
                if (File.Exists(path)) {
                    // 如果是文件，删除文件
                    File.SetAttributes(path, FileAttributes.Normal);
                    File.Delete(path);
                    Console.WriteLine($"已删除文件: {path}");
                }
                else if (Directory.Exists(path)) {
                    // 如果是文件夹，删除文件夹及其内容
                    Program.SetFileAccessNormal(path);
                    Directory.Delete(path, true); // true表示递归删除
                    Console.WriteLine($"已删除文件夹: {path}");
                }
                else {
                    Console.WriteLine("指定的路径不存在。");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"操作失败: {ex.Message}");
            }
        }

    }
}
