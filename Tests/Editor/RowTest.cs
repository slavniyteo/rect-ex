using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;
using System.Linq;

namespace RectEx {
    public class RowTest {

        protected virtual Rect PrepareRect(Rect rect){
            return rect.Invert();
        }
        protected virtual Rect[] PreparetRects(Rect[] rects){
            return rects.Select(x => x.Invert()).ToArray();
        }

        [Test]
        public void ColumnSimpleTest(){
            var rect = new Rect(10, 20, 10, 110);
            var weights = new float[] {1,1};
            var widthes = new float[] {0,10};
            var expected = new Rect[]{
                new Rect(x:10, y:20, width:10, height:47.5f),
                new Rect(x:10, y: 72.5f, width:10, height:57.5f)
            };
            var actual = rect.Column(weights, widthes, 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ColumnShugarTest(){
            var rect = new Rect(10, 20, 10, 100);
            var expected = new Rect[]{
                new Rect(x:10, y:20, width:10, height:47.5f),
                new Rect(x:10, y: 72.5f, width:10, height:47.5f)
            };
            var actual = rect.Column(2,5);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(WeightsPassSource))]
        public void RowWeightsPass(string caseName, Rect from, float[] weights, float space, Rect[] expected) {
            var actual = from.Row(weights, space);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(WeightsPassSource))]
        public void ColumnWeightsPass(string caseName, Rect from, float[] weights, float space, Rect[] expected) {
            from = PrepareRect(from);
            expected = PreparetRects(expected);

            var actual = from.Column(weights, space);
            Assert.AreEqual(expected, actual);
        }

        class WeightsPassSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] { 
                    "2 weights equal 1",
                    new Rect(x: 0, y:0, width:100, height:100),
                    new float[] {1,1}, 
                    0,
                    new Rect[]{
                        new Rect(x:0, y:0, width:50, height:100),
                        new Rect(x:50, y:0, width:50, height:100)
                    }
                };
                 
                yield return new object[] { 
                    "2 different weights",
                    new Rect(x: 0, y:0, width:100, height:100),
                    new float[] {1,3}, 
                    0,
                    new Rect[]{
                        new Rect(x:0, y:0, width:25, height:100),
                        new Rect(x:25, y:0, width:75, height:100)
                    }
                };
                
                yield return new object[] {
                    "One of weights equal 0",
                    new Rect(x:0, y:0, width:35, height:100),
                    new float[] {0,1,2},
                    5,
                    new Rect[]{
                        new Rect(x:0, y:0, width:10, height:100),
                        new Rect(x:15, y:0, width:20, height:100)
                    }
                };
                
                yield return new object[] { 
                    "Negative position",
                    new Rect(x: -10, y:-15, width:110, height:100),
                    new float[] {2,1,1}, 
                    5,
                    new Rect[]{
                        new Rect(x:-10, y:-15, width:50, height:100),
                        new Rect(x:45, y:-15, width:25, height:100),
                        new Rect(x:75, y:-15, width:25, height:100)
                    }
                };
                
                yield return new object[] { 
                    "Negative width",
                    new Rect(x: 10, y:-15, width:-110, height:100),
                    new float[] {2,1,1}, 
                    5,
                    new Rect[]{
                        new Rect(x:-100, y:-15, width:50, height:100),
                        new Rect(x:-45, y:-15, width:25, height:100),
                        new Rect(x:-15, y:-15, width:25, height:100)
                    }
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(WidthesPassSource))]
        public void RowWidthesPass(string caseName, Rect from, float[] weights, float[] widthes, float space, Rect[] expected) {
            var actual = from.Row(weights, widthes, space);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [TestCaseSource(typeof(WidthesPassSource))]
        public void ColumnWidthesPass(string caseName, Rect from, float[] weights, float[] widthes, float space, Rect[] expected) {
            from = PrepareRect(from);
            expected = PreparetRects(expected);

            var actual = from.Column(weights, widthes, space);
            Assert.AreEqual(expected, actual);
        }

        class WidthesPassSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] { 
                    "One of rects has width",
                    new Rect(x: 0, y:0, width:100, height:100),
                    new float[] {1,0},
                    new float[] {0,20}, 
                    3,
                    new Rect[]{
                        new Rect(x:0, y:0, width:77, height:100),
                        new Rect(x:80, y:0, width:20, height:100)
                    }
                };

                yield return new object[] {
                    "Weight and Width on the same part",
                    new Rect(x:0, y:0, width:100, height:100),
                    new float[] {1,1,0},
                    new float[] {0,25,25},
                    5,
                    new Rect[]{
                        new Rect(x:0, y:0, width:20, height:100),
                        new Rect(x:25, y:0, width:45, height:100),
                        new Rect(x:75, y:0, width:25, height:100)
                    }
                };

                yield return new object[] { 
                    "Negative position",
                    new Rect(x: -10, y:0, width:110, height:100),
                    new float[] {1,0},
                    new float[] {0,20}, 
                    3,
                    new Rect[]{
                        new Rect(x:-10, y:0, width:87, height:100),
                        new Rect(x:80, y:0, width:20, height:100)
                    }
                };
                
                yield return new object[] { 
                    "Negative size",
                    new Rect(x: 10, y:-15, width:-110, height:100),
                    new float[] {4,2,1}, 
                    new float[] {10,10,10},
                    5,
                    new Rect[]{
                        new Rect(x:-100, y:-15, width:50, height:100),
                        new Rect(x:-45, y:-15, width:30, height:100),
                        new Rect(x:-10, y:-15, width:20, height:100)
                    }
                };
                 
            }
        }

        [Test, TestCaseSource(typeof(SugarWithoutArraysSource))]
        public void RowSugarWithoutArrays(string name, Rect from, int count, float space, Rect[] expected){
            var actual = from.Row(count, space);
            Assert.AreEqual(expected, actual);
        }

        [Test, TestCaseSource(typeof(SugarWithoutArraysSource))]
        public void ColumnSugarWithoutArrays(string name, Rect from, int count, float space, Rect[] expected){
            from = PrepareRect(from);
            expected = PreparetRects(expected);

            var actual = from.Column(count, space);
            Assert.AreEqual(expected, actual);
        }

        public class SugarWithoutArraysSource : IEnumerable {
            public IEnumerator GetEnumerator(){
                yield return new object[] {
                    "Simple",
                    new Rect(x:-10, y:0, width:100, height:100),
                    1,
                    5,
                    new Rect[]{
                        new Rect(x:-10, y:0, width:100, height:100)
                    }
                };
                yield return new object[] {
                    "Simple with negative size",
                    new Rect(x:10, y:0, width:-100, height:100),
                    1,
                    5,
                    new Rect[]{
                        new Rect(x:-90, y:0, width:100, height:100)
                    }
                };
                yield return new object[] {
                    "Two pieses",
                    new Rect(x:-10, y:0, width:100, height:100),
                    2,
                    5,
                    new Rect[]{
                        new Rect(x:-10, y:0, width:47.5f, height:100),
                        new Rect(x:42.5f, y:0, width:47.5f, height:100),
                    }
                };
                yield return new object[] {
                    "Two pieses with negative size",
                    new Rect(x:10, y:0, width:-100, height:100),
                    2,
                    5,
                    new Rect[]{
                        new Rect(x:-90, y:0, width:47.5f, height:100),
                        new Rect(x:-37.5f, y:0, width:47.5f, height:100),
                    }
                };
                yield return new object[] {
                    "Three pieses",
                    new Rect(x:-10, y:0, width:100, height:100),
                    3,
                    5,
                    new Rect[]{
                        new Rect(x:-10, y:0, width:30, height:100),
                        new Rect(x:25, y:0, width:30, height:100),
                        new Rect(x:60, y:0, width:30, height:100)
                    }
                };
                yield return new object[] {
                    "Three pieses with negative size",
                    new Rect(x:10, y:0, width:-100, height:100),
                    3,
                    5,
                    new Rect[]{
                        new Rect(x:-90, y:0, width:30, height:100),
                        new Rect(x:-55, y:0, width:30, height:100),
                        new Rect(x:-20, y:0, width:30, height:100)
                    }
                };
                yield return new object[] {
                    "Five pieses",
                    new Rect(x:0, y:0, width:120, height:100),
                    5,
                    5,
                    new Rect[]{
                        new Rect(x:0, y:0, width:20, height:100),
                        new Rect(x:25, y:0, width:20, height:100),
                        new Rect(x:50, y:0, width:20, height:100),
                        new Rect(x:75, y:0, width:20, height:100),
                        new Rect(x:100, y:0, width:20, height:100)
                    }
                };
            }
        }
        
        [Test]
        public void RowExceptionOnUnsetWeights(){
            Assert.Throws<System.ArgumentException>(() => new Rect(0,0,10,10).Row(null));
        }

        [Test]
        public void ColumnExceptionOnUnsetWeights(){
            Assert.Throws<System.ArgumentException>(() => new Rect(0,0,10,10).Column(null));
        }

    }
}
