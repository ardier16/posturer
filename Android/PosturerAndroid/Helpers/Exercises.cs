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
            int height = options.OutHeight;
            int width = options.OutWidth;
            int inSampleSize = 1;

            if (height > reqHeight || width > reqWidth)
            {
                int heightRatio = height / reqHeight;
                int widthRatio = width / reqWidth;

                inSampleSize = heightRatio < widthRatio ? heightRatio : widthRatio;
            }

            return inSampleSize;
        }
    }
}