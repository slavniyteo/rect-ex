using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using RectEx.Internal;

namespace RectEx {
	public static class MiscellaniousExtensions {
        public static Rect Abs(this Rect rect){
            if (rect.width < 0) {
                rect.x += rect.width;
                rect.width *= -1;
            }
            if (rect.height < 0) {
                rect.y += rect.height;
                rect.height *= -1;
            }
            return rect;
        }

        public static Rect Invert(this Rect rect){
            return new Rect(
                x: rect.y,
                y: rect.x,
                width: rect.height,
                height: rect.width
            );
        }

	}
}