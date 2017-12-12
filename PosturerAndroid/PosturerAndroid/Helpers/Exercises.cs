using System;
using System.Collections.Generic;

using Android.Graphics;

namespace PosturerAndroid.Helpers
{
    public static class Exercises
    {
        private static Random RANDOM = new Random();
        
        public static int RandomCheeseDrawable
        {
            get
            {
                switch (RANDOM.Next(5))
                {
                    default:
                    case 0:
                        return Resource.Drawable.Icon;
                    case 1:
                        return Resource.Drawable.Icon;
                    case 2:
                        return Resource.Drawable.Icon;
                    case 3:
                        return Resource.Drawable.Icon;
                    case 4:
                        return Resource.Drawable.Icon;
                }
            }
        }        
        public static List<string> ExerciseStrings
        {
            get
            {
                return new List<string>()
                {
                    "Exercise 1",
                    "Exercise 2",
                    "Exercise 3",
                    "Exercise 4",
                    "Exercise 5",
                    "Exercise 6",
                    "Exercise 7",
                    "Exercise 8",

                };
            }        
        }

        public static int CalculateInSampleSize(BitmapFactory.Options options, int reqWidth, int reqHeight)
        {
            // Raw height and width of image
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > reqHeight || width > reqWidth)
            {

                // Calculate ratios of height and width to requested height and
                // width
                int heightRatio = height / reqHeight;
                int widthRatio = width / reqWidth;

                // Choose the smallest ratio as inSampleSize value, this will
                // guarantee
                // a final image with both dimensions larger than or equal to the
                // requested height and width.
                inSampleSize = heightRatio < widthRatio ? heightRatio : widthRatio;
            }

            return inSampleSize;
        }
    }
}