using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Security.Cryptography.X509Certificates;
using SevenZip;

namespace VersionReleaseManager
{
    public class Release :  IDisposable
    {
        public event Action E_finished;
        public event Action E_begin;
        public event Action<string> E_message;
        void IDisposable.Dispose()
        {
            this.E_begin = null;
            this.E_begin = null;
            this.E_message = null;
        }

        public string CmakeExePath { get; set; }
            = "D:\\_file\\？？\\cmake-3.30.2-windows-x86_64\\cmake-3.30.2-windows-x86_64\\bin\\cmake.exe";

        public void exec(string repoUrl, string cloneDir,
                         string installDir, string? brachName, string? compileDir, string? tagName)
        {
            try {
                this?.E_begin();
                string error_buffer;
                // 清空目标目录
                if (String.IsNullOrEmpty(cloneDir)) {
                    this.E_message?.Invoke("dir to git clone is illegle" + Environment.NewLine);
                    return;
                }
                RemoveIfExist(cloneDir);
                Directory.CreateDirectory(cloneDir);

                // 克隆 Git 仓库
                this?.E_message("[begin] git clone ......" + Environment.NewLine);
                string cmdClone = "clone "
                    + (String.IsNullOrEmpty(brachName) ? "" : $" -b {brachName} ")
                    + $"{repoUrl} {cloneDir}";
                RunCommand("git", cmdClone, out error_buffer);
                this?.E_message("[end] git clone ......" + Environment.NewLine);

                // 切换到克隆目录
                Directory.SetCurrentDirectory(cloneDir);

                // 生成构建目录
                string buildDir = Path.Combine(cloneDir, "build");
                Directory.CreateDirectory(buildDir);
                Directory.SetCurrentDirectory(buildDir);

                string cmakeDir = compileDir ?? "..";
                cmakeDir = "..";
                // CMake 编译
                this?.E_message("[begin] compile ......" + Environment.NewLine);
                RunCommand($"{CmakeExePath}", $"{cmakeDir} -DCMAKE_INSTALL_PREFIX={installDir}", out error_buffer);
                RunCommand($"{CmakeExePath}", "--build . --target install", out error_buffer);
                this?.E_message("[end] compile ......" + Environment.NewLine);


                // 压缩安装目录
                this?.E_message("[begin] compress ......" + Environment.NewLine);
                string zipPath = $"{installDir}.zip";
                RemoveIfExist(zipPath);
                ZipFile.CreateFromDirectory(installDir, zipPath);
                this?.E_message("[end] compress ......" + Environment.NewLine);

                this?.E_message("编译和打包完成。" + Environment.NewLine);

                // 创建标签
                if (String.IsNullOrEmpty(tagName) == false) {
                    this?.E_message("[begin] push tag ......" + Environment.NewLine);
                    if(!RunCommand("git", $"tag {tagName}", out error_buffer)) {
                        this?.E_message(error_buffer);
                        return;
                    }
                    // 推送标签到远程
                    if (!RunCommand("git", $"push origin {tagName}", out error_buffer)) {
                        this?.E_message(error_buffer);
                        return;
                    }
                    this?.E_message("[end] push tag ......" + Environment.NewLine);
                }
            }
            finally {
                this.E_finished?.Invoke();
            }

        }

        static bool RunCommand(string command, string arguments, out string errorMsg)
        {
            errorMsg = string.Empty;
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
                if (process == null) {
                    errorMsg = "cmd进程启动失败";
                    return false;
                }
                process.WaitForExit();
                
                string output = process.StandardOutput.ReadToEnd();
                string error = process.StandardError.ReadToEnd();

                if (process.ExitCode != 0) {
                    errorMsg += ($"错误: {error}" + Environment.NewLine
                               + $"命令执行失败: {command} {arguments}");
                    return false;
                }

                Console.WriteLine(output);
            }

            return true;
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
