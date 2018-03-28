using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Java.IO;
using static Android.Hardware.Camera;

namespace CustomRenderer.Droid
{
    public class PictureCallback : IPictureCallback
    {
        public IntPtr Handle => throw new NotImplementedException();

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void OnPictureTaken(byte[] data, Android.Hardware.Camera camera)
        {
            FileOutputStream outStream = null;
            try
            {
                Bitmap bitmap = BitmapFactory.DecodeByteArray(data, offset, length);

                int[] pix = new int[picw * pich];
                bitmap.getPixels(pix, 0, picw, 0, 0, picw, pich);

                int R, G, B, Y;

                for (int y = 0; y < pich; y++)
                {
                    for (int x = 0; x < picw; x++)
                    {
                        int index = y * picw + x;
                        int R = (pix[index] >> 16) & 0xff;     //bitwise shifting
                        int G = (pix[index] >> 8) & 0xff;
                        int B = pix[index] & 0xff;

                        pix[index] = 0xff000000 | (R << 16) | (G << 8) | B;
                    }
                }


            }
            catch (FileNotFoundException e)
            {
                e.PrintStackTrace();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            finally
            {
            }
        }
    }
    }
}