using Avalonia.Data.Converters;

using Avalonia;
using System;
using System.Globalization;
using AiNotes.Models;

namespace AiNotes.Converters;

public class AttachmentTypeToVisibilityConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is AttachmentType attachmentType && parameter is string targetTypeString)
        {
            switch (targetTypeString)
            {
                case "Image":
                    return attachmentType == AttachmentType.Image;
                case "Video":
                    return attachmentType == AttachmentType.Video;
                case "Audio":
                    return attachmentType == AttachmentType.Audio;
                default:
                    return false;
            }
        }

        return false;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
