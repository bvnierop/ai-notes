using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace AiNotes.Scripts;

public class SummarizePy
{
    public static string ExecuteAsync(string[] contents)
    {
        // Execute OCR script
        ProcessStartInfo start = new()
        {
            FileName = "Scripts/summarize.py",
            // Arguments = fileName,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardInput = true,
            CreateNoWindow = true,
        };
        var output = new StringBuilder();
        var proc = Process.Start(start);

        foreach (var line in contents)
            proc.StandardInput.WriteLine(line);
        proc.StandardInput.Flush();
        proc.StandardInput.Close();

        using AutoResetEvent outputEvent = new(false);
        proc.OutputDataReceived += (sender, args) => {
            if (args.Data != null) output.AppendLine(args.Data);
            else outputEvent.Set();
        };
        proc.BeginOutputReadLine();

        if (proc.WaitForExit(-1) && outputEvent.WaitOne(-1)) {
            var json = output.ToString();
            return json;
        } else {
            Debug.WriteLine("OCR script timed out");
            proc.Kill();
            proc.WaitForExit();
            return "";
        }
    }
}
