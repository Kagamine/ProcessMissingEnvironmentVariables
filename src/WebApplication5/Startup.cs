using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace WebApplication5
{
    public class Startup
    {
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        {
            logger.AddConsole();
            app.UseIISPlatformHandler();
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
                var p = new Process();
                p.StartInfo = new ProcessStartInfo();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.Arguments = "/c build.cmd";
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WorkingDirectory = @"c:\pool\judge\41";
                p.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
                p.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); };
                p.Start();
                p.BeginErrorReadLine();
                p.BeginOutputReadLine();
                p.WaitForExit();
                Console.WriteLine("Exit with " + p.ExitCode);
            });
        }
    }
}
