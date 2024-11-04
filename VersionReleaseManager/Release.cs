using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using SevenZip;

namespace VersionReleaseManagerUI
{
    internal class Release
    {
        public string CmakeExePath { get; set; }
            = "D:\\_file\\？？\\cmake-3.30.2-windows-x86_64\\cmake-3.30.2-windows-x86_64\\bin\\cmake.exe";

        public void exec(string repoUrl, string cloneDir,
                         string installDir, string? brachName, string? compileDir, string? tagName)
        {
            // 清空目标目录
            RemoveIfExist(cloneDir);
            Directory.CreateDirectory(cloneDir);

            // 克隆 Git 仓库
            string cmdClone = "clone "
                + (String.IsNullOrEmpty(brachName) ? "" : $" -b {brachName} ")
                + $"{repoUrl} {cloneDir}";
            RunCommand("git", cmdClone);

            // 切换到克隆目录
            Directory.SetCurrentDirectory(cloneDir);

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
            RemoveIfExist(zipPath);
            ZipFile.CreateFromDirectory(installDir, zipPath);

            //Console.WriteLine("编译和打包完成。");

            // 创建标签
            if (String.IsNullOrEmpty(tagName) == false) {
                RunCommand("git", $"tag {tagName}");
                RunCommand("git", $"push origin {tagName}"); // 推送标签到远程
            }
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
                    SetFileAccessNormal(path);
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
