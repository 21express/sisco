using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Devenlab.Common.Helpers
{
	public class FileHelpers
	{
		public static byte[] GetBytesFormImage(string filename)
		{
			var fInfo = new FileInfo(filename);
			if (!fInfo.Exists)
			{
				return null;
			}
			using (var fs = new FileStream(filename, FileMode.Open, FileAccess.Read))
			{
				var bin = new BinaryReader(fs);
				var rawImage = new byte[fs.Length];
				bin.Read(rawImage, 0, (int) fs.Length);
				fs.Close();
				return rawImage;
			}
		}

        public static byte[] GetBytesFormImage(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, ImageFormat.Jpeg);
                return ms.ToArray();
            }
        }

		public static Image GetBitmap(byte[] source)
		{
			using (var strm = new MemoryStream(source, true))
			{
				strm.Write(source, 0, source.Length);
				Image im = new Bitmap(strm);
				im.RotateFlip(RotateFlipType.Rotate90FlipNone);
				strm.Close();
				return im;
			}
		}

		public static Image GetBitmap(byte[] source, RotateFlipType rotate)
		{
			using (var strm = new MemoryStream(source, true))
			{
				strm.Write(source, 0, source.Length);
				Image im = new Bitmap(strm);
				im.RotateFlip(rotate);
				strm.Close();
				return im;
			}
		}

		public static void SetBytesToFile(byte[] source, string fileNames)
		{
			var image = GetBitmap(source);
			image.Save(fileNames,ImageFormat.Jpeg);
			//using (var fs = File.Create(fileNames))
			//{
			//    fs.Write(source, 0, source.Length);
			//    fs.Close();
			//}
		}

		public static string GetFileName(string prefix, string extension)
		{
			return string.Format("{0}{1}{2}", prefix, DateTime.Now.ToString("_yyyy_MM_dd_hh_mm_ss."), extension);
		}

        /// <summary>
        /// Compress Image Into 70L
        /// </summary>
        /// <param name="path">Full Path with end [/]</param>
        /// <param name="filename">Name Of File JPG</param>
        /// <param name="outputFile">Result Image Compressed</param>
        public static void CompressImage(string path, string filename, out string outputFile)
        {
            var image = new Bitmap(path + filename);

            var jgpEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoder = Encoder.Quality;
            var newfileName = filename.Replace(".jpg", "") + "-compressed.jpg";
            outputFile = newfileName;
            var myEncoderParameters = new EncoderParameters(1);
            var myEncoderParameter = new EncoderParameter(myEncoder, 70L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            image.Save(path + newfileName, jgpEncoder, myEncoderParameters);
        }

        private static ImageCodecInfo GetEncoder(ImageFormat format)
        {

            var codecs = ImageCodecInfo.GetImageDecoders();

            return codecs.FirstOrDefault(codec => codec.FormatID == format.Guid);
        }

        public static Image ResizeImage(Image image, Size size, bool preserveAspectRatio = true)
        {
            int newWidth;
            int newHeight;
            if (preserveAspectRatio)
            {
                var originalWidth = image.Width;
                var originalHeight = image.Height;
                var percentWidth = size.Width / (float)originalWidth;
                var percentHeight = size.Height / (float)originalHeight;
                var percent = percentHeight < percentWidth ? percentHeight : percentWidth;
                newWidth = (int)(originalWidth * percent);
                newHeight = (int)(originalHeight * percent);
            }
            else
            {
                newWidth = size.Width;
                newHeight = size.Height;
            }
            Image newImage = new Bitmap(newWidth, newHeight);
            using (var graphicsHandle = Graphics.FromImage(newImage))
            {
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphicsHandle.DrawImage(image, 0, 0, newWidth, newHeight);
            }
            return newImage;
        }
	}
}
