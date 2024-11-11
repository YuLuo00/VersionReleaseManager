using VersionReleaseManager;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;
using System.Reflection;

namespace VersionReleaseManagerUI
{
    public partial class Form1 : Form
    {

        VersionReleaseManager.VRManager VRManager { get; set; } = new VersionReleaseManager.VRManager();
        public Form1()
        {
            InitializeComponent();
            VersionReleaseManager.Configuration configuration = new VersionReleaseManager.Configuration();
            configuration.Units.AddRange(new List<ConfigUnit>
            {
                new ConfigUnit
                {
                    ProjectName = "123",
                    BrachName = "12",
                    ReleaseBase = "",
                    RepoUrl = "11111111111",
                },
                new ConfigUnit
                {
                    ProjectName = "hhhh",
                    BrachName = "2222",
                    ReleaseBase = "",
                    RepoUrl = "0000000000000",
                },
            });
            configuration.Dump();

            VRManager.Configuration.ReadFromFile();
            for (int i = 0; i < VRManager.Configuration.Units.Count; i++) {
                var unit = VRManager.Configuration.Units[i];
                u_cb_ProjectName.Items.Add(unit.ProjectName);
            }
        }

        public event EventHandler<string>? TaskCompleted;
        private async void RunReleaseTask()
        {
            // 在后台线程执行任务
            string result = await Task.Run(() =>
            {
                new VersionReleaseManager.Release().exec("", "", "", null, null, null);
                System.Threading.Thread.Sleep(3000); // 模拟3秒钟的延迟
                return "任务完成！";
            });

            // 任务完成后通过事件通知主线程更新 UI
            TaskCompleted?.Invoke(this, result);
        }

        private void b_release_Click(object sender, EventArgs e)
        {
            string repoUri = this.u_tb_repoUr.Text;
            string branch = this.u_cb_brachName.Text;
            string tagName = this.u_tb_tagName.Text;

            //this.VRManager.Release(repoUri, branch, tagName);
            RunReleaseTask();
            ManualResetEventSlim releaserHadBeenLinked = new ManualResetEventSlim(false);
            var result = Task.Run(() =>
            {
                using(Release releaser = new VersionReleaseManager.Release())
                {
                    releaser.E_begin += () => this.addMsg("开始");
                    releaserHadBeenLinked.Set();
                    releaser.exec("", "", "", null, null, null);
                }
            });
            releaserHadBeenLinked.Wait();
            addMsg("正在后台执行发布任务");
        }

        private void addMsg(string msg) {
            u_tb_msg?.AppendText(msg);
        }
        public class MyClass
        {
            public event Action? MyEvent;

            public void RaiseEvent()
            {
                MyEvent?.Invoke();
            }
        }
        public static void Mainsss()
        {
            var myObject = new MyClass();

            // 订阅事件
            myObject.MyEvent += () =>
            {
                Console.WriteLine("Event handler 1");
            };
            myObject.MyEvent += () => Console.WriteLine("Event handler 2");

            // 使用反射获取并移除所有订阅者
            var fieldInfo = typeof(MyClass).GetField("MyEvent", BindingFlags.NonPublic | BindingFlags.Instance);
            var eventDelegate = fieldInfo?.GetValue(myObject) as Delegate;

            if (eventDelegate != null) {
                // 获取当前所有订阅者并遍历移除
                foreach (var subscriber in eventDelegate.GetInvocationList()) {
                    myObject.MyEvent -= (Action)subscriber;  // 移除订阅
                    Console.WriteLine($"Removed subscriber: {subscriber.Method.Name}");
                }
            }

            // 触发事件（没有任何输出，订阅者已被移除）
            myObject.RaiseEvent();
        }

        private void u_b_testConfig_Click(object sender, EventArgs e)
        {
            VersionReleaseManager.Configuration configuration = new();
            configuration.Units.AddRange( [
                new ConfigUnit
                {
                    ProjectName = "projectName1",
                    BrachName = "master",
                    ReleaseBase = "./CMakeLists.txt",
                    RepoUrl = "www.git.com/aaaaaaa",
                    CompileConfig="release",
                },
                new ConfigUnit
                {
                    ProjectName = "projectName2",
                    BrachName = "dev",
                    ReleaseBase = "./release.sh",
                    RepoUrl = "www.git.com/bbbbb",
                    CompileConfig="debug",
                },
            ]);
            configuration.Dump("./config_example.json");
        }
    }
}
