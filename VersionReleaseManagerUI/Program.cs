

using VersionReleaseManager;


namespace VersionReleaseManagerUI
{
    class Test
    {
        public event Action? Finished;
        public void FinishedCb()
        {
            Console.WriteLine("FinishdCb -- ");
        }
        public async Task RunA()
        {
            Finished += FinishedCb;
            Console.WriteLine("[begin] RunA -- ");
            var task = Task.Run(() =>
            {
                for (int i = 0; i < 10; i++) {
                    System.Threading.Thread.Sleep(200);
                    Console.WriteLine("Task RunA -- " + i.ToString());
                }
                Finished?.Invoke();
                Console.WriteLine("Task RunA -- ");
            });
            await task;
            Console.WriteLine("[end] RunA -- ");
        }
    }
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //var test = new Test();
            //Task.Run(async () => await test.RunA()).Wait();
            //Console.WriteLine("[end] new Test().RunA()");
            //for (int i = 0; i < 10; i++) {
            //    System.Threading.Thread.Sleep(1000);
            //}
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}