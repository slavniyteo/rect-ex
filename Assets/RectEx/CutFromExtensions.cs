using System;
using UnityEngine;

namespace RectEx {
    public static class CutFromExtensions {

        public static Rect[] CutFromRight(this Rect rect, float width, float space = 5){
            rect = rect.Abs();
            float min = Math.Min(rect.xMin, rect.xMax - (space + width));

            var first = Rect.MinMaxRect(
                xmin:min,
                xmax:rect.xMax - (space + width),
                ymin:rect.yMin,
                ymax:rect.yMax
            ).Abs();
            var second = Rect.MinMaxRect(
                xmin:first.xMax + space,
                xmax:rect.xMax,
                ymin:first.yMin,
                ymax:first.yMax
            ).Abs();
            return new Rect[]{first, second};
        }

        public static Rect[] CutFromLeft(this Rect rect, float width, float space = 5){
            var first = Rect.MinMaxRect(
                xmin:rect.xMin,
                xmax:rect.xMin + width,
                ymin:rect.yMin,
                ymax:rect.yMax
            );
            float max = Math.Max(rect.xMax, first.xMax + space);
            var second = Rect.MinMaxRect(
                xmin:first.xMax + space,
                xmax:max,
                ymin:rect.yMin,
                ymax:rect.yMax
            );
            return new Rect[]{first, second};
        }

        public static Rect[] CutFromTop(this Rect rect, float height, float space = 5){
            var first = Rect.MinMaxRect(
                xmin:rect.xMin,
                xmax:rect.xMax,
                ymin:rect.yMin,
                ymax:height
            );
            float max = Math.Max(rect.yMax, first.yMax + space);
            var second = Rect.MinMaxRect(
                xmin:rect.xMin,
                xmax:rect.xMax,
                ymin:first.yMax + space,
                ymax:max
            );
            return new Rect[]{first, second};
        }
    }
}