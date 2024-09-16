using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using AiNotes.Models;
using AiNotes.TextOverlay;
using Avalonia.Media.Imaging;

namespace AiNotes.ViewModels;

public class AttachmentViewModel(ImageAttachment attachment)
{
    public ImageAttachment Attachment { get; } = attachment;
    private TextOverlayViewModel? _imageWithTextOverlay = null;

    public TextOverlayViewModel? ImageWithTextOverlay
    {
        get
        {
            if (_imageWithTextOverlay == null && Attachment.Type == AttachmentType.Image)
            {
                var image = new Bitmap(Attachment.FilePath);

                _imageWithTextOverlay = new TextOverlayViewModel
                {
                    Image = image,
                    OriginalTextRegions = Attachment.OcrResults.Select(r =>
                        new TextRegion
                        {
                            // 0: topleft (x, then y)
                            // 1: topright (x, then y)
                            // 2: bottomright (x, then y)
                            // 3: bottomleft (x, then y)
                            Text = r.text,
                            X = r.box[0][0],
                            Y = r.box[0][1],
                            Width = r.box[1][0] - r.box[0][0],
                            Height = r.box[3][1] - r.box[0][1],
                        }).ToList(),
                };
                System.Diagnostics.Debug.WriteLine($"Created TextOverlayViewModel for {Attachment.FilePath} with {Attachment.OcrResults.Length} regions");
            }
            return _imageWithTextOverlay;
        }
    }

    public string FilePath => Attachment.FilePath;
    public AttachmentType Type => Attachment.Type;
}
