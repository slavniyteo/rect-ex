using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using RectEx.Internal;

namespace RectEx {
	public static class RowExtensions {

        public static Rect[] Row(this Rect rect, int count, float space = 5){
            return Row(rect, Enumerable.Repeat(1f, count), Enumerable.Repeat(0f, count), space);
        }

		public static Rect[] Row(this Rect rect, IEnumerable<float> weights, float space = 5){
			return Row(rect, weights, null, space);
		}

		public static Rect[] Row(this Rect rect, IEnumerable<float> weights, IEnumerable<float> widthes, float space = 5) {
            if (weights == null){
                throw new ArgumentException("Weights is null. You must specify it");
            }

            if (widthes == null){
                widthes = weights.Select(x => 0f);
            }

            rect = rect.Abs();
            return RowSafe(rect, weights, widthes, space);
        }

        private static Rect[] RowSafe(Rect rect, IEnumerable<float> weights, IEnumerable<float> widthes, float space = 5) {
            var cells = weights.Merge(widthes, (weight, width) => new Cell(weight, width)).Where( cell => cell.HasWidth);

            float weightUnit = GetWeightUnit(rect.width, cells, space);

            var result = new List<Rect>();
            float nextX = rect.x;
            foreach (var cell in cells) {
                result.Add(new Rect(
                               x: nextX,
                               y: rect.y,
                               width: cell.GetWidth(weightUnit),
                               height: rect.height
                           ));

                nextX += cell.HasWidth ? (cell.GetWidth(weightUnit) + space) : 0;
            }

            return result.ToArray();
        }

        private static float GetWeightUnit(float fullWidth, IEnumerable<Cell> cells, float space) {
            float result = 0;
            float weightsSum = cells.Sum(cell => cell.Weight);

            if (weightsSum > 0) {
                float fixedWidth = cells.Sum(cell => cell.FixedWidth);
                float spacesWidth = (cells.Count(cell => cell.HasWidth) - 1) * space;
                result = (fullWidth - fixedWidth - spacesWidth) / weightsSum;
            }

            return result;
        }

        private class Cell {
            public float Weight { get; private set; }
            public float FixedWidth { get; private set; }

            public Cell(float weight, float fixedWidth) {
                this.Weight = weight;
                this.FixedWidth = fixedWidth;

            }

            public bool HasWidth { get { return FixedWidth > 0 || Weight > 0; } }
            public float GetWidth(float weightUnit) {
                return FixedWidth + Weight * weightUnit;
            }
        }

	}
}