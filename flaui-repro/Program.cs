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

System.Threading.Thread.Sleep(1000);

var application = Application.Attach(process);
// this will dispoce process
var window = application.GetMainWindow(new UIA3Automation());
Console.WriteLine(window.Title);


process.WaitForExit(); // will throw System.InvalidOperationException: No process is associated with this object