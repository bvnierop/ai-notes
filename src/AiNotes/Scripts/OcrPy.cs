using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AiNotes.Scripts;

public static class OcrPy
{
    public class OcrResult
    {
        public string text { get; set; }
        public int[][] box { get; set; } // TopLeft -> BottomLeft -> BottomRight -> TopRight
        public double confidence { get; set; }
    }

    public static OcrResult[] ExecuteAsync(string fileName)
    {
        // Execute OCR script
        ProcessStartInfo start = new()
        {
            FileName = "Scripts/ocr.py",
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
            var result = JsonSerializer.Deserialize<OcrResult[]>(json);
            return result;
        } else {
            Debug.WriteLine("OCR script timed out");
            proc.Kill();
            proc.WaitForExit();
            return [];
        }
    }
}
