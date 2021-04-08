using System;
using System.Diagnostics;
using FlaUI.Core;
using FlaUI.UIA3;

var processStartInfo = new ProcessStartInfo("winforms")
{
    RedirectStandardOutput = true,
};

var process = new Process
{
    StartInfo = processStartInfo
};

process.OutputDataReceived += (obj, args) => Console.WriteLine(args.Data);
process.Start();
process.BeginOutputReadLine();

System.Threading.Thread.Sleep(1000); // stdout being produced

var application = Application.Attach(process);
var window = application.GetMainWindow(new UIA3Automation()); // this will Dispose process, stdout of winforms will stop
Console.WriteLine(window.Title);

process.WaitForExit(); // any interaction with process will throw System.InvalidOperationException: No process is associated with this object