using System;
using UnityEngine;

namespace RectEx {
    public static class CutFromExtensions {

        public static Rect[] CutFromRight(this Rect rect, float width, float space = 5){
            var first = Rect.MinMaxRect(
                xmin:rect.xMin,
                xmax:rect.xMax - (space + width),
                ymin:rect.yMin,
                ymax:rect.yMax
            );
            var second = Rect.MinMaxRect(
                xmin:first.xMax + space,
                xmax:rect.xMax,
                ymin:first.yMin,
                ymax:first.yMax
            );
            return new Rect[]{first, second};
        }

    }
}