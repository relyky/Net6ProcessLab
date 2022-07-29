using Microsoft.Extensions.Configuration;
using Net6ProcessLab.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net6ProcessLab
{
  internal class App
  {
    readonly IConfiguration _config;
    readonly RandomService _randSvc;

    public App(IConfiguration config, RandomService randSvc)
    {
      _config = config;
      _randSvc = randSvc;
    }

    /// <summary>
    /// 取代原本 Program.Main() 函式的效用。
    /// </summary>
    public void Run(string[] args)
    {
      using (var proc = new Process())
      {
        proc.StartInfo.FileName = "ping.exe";
        proc.StartInfo.Arguments = "www.google.com -n 2 -l 1024";
        //proc.StartInfo.ArgumentList.Add("www.google.com");
        //proc.StartInfo.ArgumentList.Add("-n");
        //proc.StartInfo.ArgumentList.Add("2");
        //proc.StartInfo.ArgumentList.Add("-l");
        //proc.StartInfo.ArgumentList.Add("1024");
        //
        proc.StartInfo.UseShellExecute = false;
        proc.StartInfo.RedirectStandardOutput = true;
        proc.Start();

        StreamReader sr = proc.StandardOutput;
        string outputMsg = sr.ReadToEnd();

        Console.WriteLine(outputMsg);
      }

      Console.WriteLine("Press any key to continue.");
      Console.ReadKey();
    }
  }
}


//using (var proc = new Process())
//{
//  proc.StartInfo.FileName = "ipconfig.exe";
//  proc.StartInfo.UseShellExecute = false;
//  proc.StartInfo.RedirectStandardOutput = true;
//  proc.Start();
//  StreamReader sr = proc.StandardOutput;
//  string outputMsg = sr.ReadToEnd();
//  Console.WriteLine(outputMsg);
//}
