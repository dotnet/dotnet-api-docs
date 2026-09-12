// Snippet for: F:System.Drawing.Imaging.Encoder.SaveFlag
// <snippet4>
using System;
using System.Drawing;
using System.Drawing.Imaging;

class Example_MultiFrame
{
    public static void Main()
    {
        // Create three Bitmap objects.
        using Bitmap multi = new("Shapes.bmp");
        using Bitmap page2 = new("Iron.jpg");
        using Bitmap page3 = new("House.png");

        // Get an ImageCodecInfo object that represents the TIFF codec.
        ImageCodecInfo myImageCodecInfo = GetEncoderInfo("image/tiff");

        // Create an Encoder object based on the GUID
        // for the SaveFlag parameter category.
        Encoder myEncoder = Encoder.SaveFlag;

        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        using EncoderParameters myEncoderParameters = new(1);

        // Save the first page (frame).
        EncoderParameter myEncoderParameter = new(
            myEncoder,
            (long)EncoderValue.MultiFrame);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.Save("Multiframe.tiff", myImageCodecInfo, myEncoderParameters);

        // Save the second page (frame).
        myEncoderParameter.Dispose();
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.FrameDimensionPage);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(page2, myEncoderParameters);

        // Save the third page (frame).
        myEncoderParameter.Dispose();
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.FrameDimensionPage);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(page3, myEncoderParameters);

        // Close the multiple-frame file.
        myEncoderParameter.Dispose();
        myEncoderParameter = new EncoderParameter(
            myEncoder,
            (long)EncoderValue.Flush);
        myEncoderParameters.Param[0] = myEncoderParameter;
        multi.SaveAdd(myEncoderParameters);
        myEncoderParameter.Dispose();
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
// </snippet4>
