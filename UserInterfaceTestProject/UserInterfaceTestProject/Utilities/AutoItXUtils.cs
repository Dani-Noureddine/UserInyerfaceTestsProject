using AutoIt;

namespace UserInterfaceTestProject
{
    public static class AutoItXUtils
    {
        public static void UploadFile(string path)
        {
            AutoItX.WinActivate("Open");
            AutoItX.Send(path);
            Thread.Sleep(1000);
            AutoItX.Send("{Enter}");
        }
    }
}
