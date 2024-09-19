using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AiNotes.Scripts;

public static class TranscribePy
{
    public static string ExecuteAsync(string fileName)
    {
        // Execute OCR script
        ProcessStartInfo start = new()
        {
            FileName = "Scripts/transcribe.py",
            Arguments = fileName,
            UseShellExecute = false,
            RedirectStandardOutput = true,
            CreateNoWindow = true,
        };
        var output = new StringBuilder();
        var proc = Process.Start(start);

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
