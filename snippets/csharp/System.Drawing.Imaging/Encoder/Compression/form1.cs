// Snippet for: F:System.Drawing.Imaging.Encoder.Compression
// <snippet2>
using System;
using System.Drawing;
using System.Drawing.Imaging;

class Example_SetTIFFCompression
{
    public static void Main()
    {
        // Create a Bitmap object based on a BMP file.
        using Bitmap myBitmap = new("Shapes.bmp");

        // Get an ImageCodecInfo object that represents the TIFF codec.
        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");

        // Create an Encoder object based on the GUID
        // for the Compression parameter category.
        Encoder myEncoder = Encoder.Compression;

        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one.
        // EncoderParameter object in the array.
        using EncoderParameters myEncoderParameters = new(1);

        // Save the bitmap as a TIFF file with LZW compression.
        using EncoderParameter myEncoderParameter = new(
            myEncoder,
            (long)EncoderValue.CompressionLZW);
        myEncoderParameters.Param[0] = myEncoderParameter;
        myBitmap.Save("ShapesLZW.tif", myImageCodecInfo, myEncoderParameters);
    }

    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
        for (int j = 0; j < encoders.Length; ++j)
        {
            if (encoders[j].MimeType == mimeType)
            {
                return encoders[j];
            }
        }

        return null;
    }
}
// </snippet2>
