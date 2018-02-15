using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
    public class MiscellaniousTest {

        [Test]
        [TestCaseSource(typeof(AbsSource))]
        public void Abs(string name, Rect from, Rect expected) {
            var actual = from.Abs();
            Assert.AreEqual(expected, actual);
        }

        class AbsSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "No action",
                    new Rect(x:0, y:0, width:50, height:10),
                    new Rect(x:0, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:1, y:3, width:-10, height: 20),
                    new Rect(x:-9, y:3, width:10, height:20)
                };
                yield return new object[] {
                    "Negative height",
                    new Rect(x:1, y:3, width:10, height: -20),
                    new Rect(x:1, y:-17, width:10, height:20)
                };
                yield return new object[] {
                    "Double minuses",
                    new Rect(x:-10, y:-30, width:-50, height:10),
                    new Rect(x:-60, y:-30, width:50, height:10)
                };
                yield return new object[] {
                    "Negative width and height", 
                    new Rect(x:0, y:0, width:-50, height:-10),
                    new Rect(x:-50, y:-10, width:50, height:10)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(InvertSource))]
        public void Invert(string name, Rect from, Rect expected) {
            var actual = from.Invert();
            Assert.AreEqual(expected, actual);
        }

        class InvertSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple",
                    new Rect(x:5, y:10, width:50, height:10),
                    new Rect(x:10, y:5, width:10, height:50)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:-5, y:10, width:50, height:10),
                    new Rect(x:10, y:-5, width:10, height:50)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:5, y:10, width:-50, height:10),
                    new Rect(x:10, y:5, width:10, height:-50)
                };
                yield return new object[] {
                    "Zero rect",
                    new Rect(x:0, y:0, width:0, height:0),
                    new Rect(x:0, y:0, width:0, height:0)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(UnionSource))]
        public void Union(string name, Rect from, Rect[] other, Rect expected) {
            var actual = from.Union(other);
            Assert.AreEqual(expected, actual);
        }

        class UnionSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Intersected rects", 
                    new Rect(x:0, y:0, width:100, height:100),
                    new Rect[] {
                        new Rect(x:90, y:90, width:20, height:20)
                    },
                    new Rect(x:0, y:0, width:110, height:110)
                };
                yield return new object[] {
                    "Dublicated intersected rects",
                    new Rect(x:0, y:0, width:100, height:100),
                    new Rect[] {
                        new Rect(x:90, y:90, width:20, height:20),
                        new Rect(x:90, y:90, width:20, height:20)
                    },
                    new Rect(x:0, y:0, width:110, height:110)
                };
                yield return new object[] {
                    "Intercected rect and moved away one",
                    new Rect(x:0, y:0, width:100, height:100),
                    new Rect[] {
                        new Rect(x:90, y:90, width:20, height:20),
                        new Rect(x:190, y:190, width:20, height:20)
                    },
                    new Rect(x:0, y:0, width:210, height:210)
                };
                yield return new object[] {
                    "Alone",
                    new Rect(x:0, y:0, width:100, height:100),
                    null,
                    new Rect(x:0, y:0, width:100, height:100)
                };
                yield return new object[] {
                    "With itself",
                    new Rect(x:0, y:0, width:100, height:100),
                    new Rect[] {
                        new Rect(x:0, y:0, width:100, height:100)
                    },
                    new Rect(x:0, y:0, width:100, height:100)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(IntendSource))]
        public void Intend(string name, Rect from, float border, Rect expected) {
            var actual = from.Intend(border);
            Assert.AreEqual(expected, actual);
        }

        class IntendSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple", 
                    new Rect(x:0, y:0, width:100, height:100),
                    3,
                    new Rect(x:3, y:3, width:94, height:94)
                };
                yield return new object[] {
                    "Bound is less than width", 
                    new Rect(x:0, y:0, width:10, height:100),
                    6,
                    new Rect(x:5, y:6, width:0, height:88)
                };
                yield return new object[] {
                    "Bound is less than height", 
                    new Rect(x:0, y:0, width:100, height:10),
                    6,
                    new Rect(x:6, y:5, width:88, height:0)
                };
                yield return new object[] {
                    "Negative border", 
                    new Rect(x:0, y:0, width:100, height:100),
                    -3,
                    new Rect(x:-3, y:-3, width:106, height:106)
                };
                yield return new object[] {
                    "Negative Width", 
                    new Rect(x:0, y:0, width:-100, height:100),
                    3,
                    new Rect(x:-97, y:3, width:94, height:94)
                };
                yield return new object[] {
                    "Negative Height", 
                    new Rect(x:0, y:0, width:100, height:-100),
                    3,
                    new Rect(x:3, y:-97, width:94, height:94)
                };
                yield return new object[] {
                    "Negative position, border and Width and Height", 
                    new Rect(x:-10, y:-24, width:-100, height:-100),
                    -3,
                    new Rect(x:-113, y:-127, width:106, height:106)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(ExtendSource))]
        public void Extend(string name, Rect from, float border, Rect expected) {
            var actual = from.Extend(border);
            Assert.AreEqual(expected, actual);
        }

        class ExtendSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[]{
                    "Zero rect",
                    new Rect(x:0, y:0, width:0, height:0),
                    7,
                    new Rect(x:-7, y:-7, width:14, height:14)
                };
                yield return new object[]{
                    "Negative border",
                    new Rect(x:10, y:20, width:100, height:110),
                    -17,
                    new Rect(x:27, y:37, width:66, height:76)
                };
                yield return new object[]{
                    "Negative width",
                    new Rect(x:0, y:30, width:-100, height:110),
                    7,
                    new Rect(x:-107, y:23, width:114, height:124)
                };
                yield return new object[]{
                    "Negative width with negative space",
                    new Rect(x:-10, y:20, width:110, height:-100),
                    -7,
                    new Rect(x:-3, y:-73, width:96, height:86)
                };
            }
        }
        [Test]
        [TestCaseSource(typeof(FirstLineSource))]
        public void FirstLine(string name, Rect from, float height, Rect expected) {
            var actual = from.FirstLine(height);
            Assert.AreEqual(expected, actual);
        }

        class FirstLineSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[]{
                    "Simple",
                    new Rect(x:0, y:0, width:100, height:230),
                    8,
                    new Rect(x:0, y:0, width:100, height:8)
                };
                yield return new object[]{
                    "Zero rect",
                    new Rect(x:0, y:0, width:0, height:0),
                    8,
                    new Rect(x:0, y:0, width:0, height:8)
                };
                yield return new object[]{
                    "Negative line height",
                    new Rect(x:10, y:20, width:100, height:110),
                    -17,
                    new Rect(x:10, y:3, width:100, height:17)
                };
                yield return new object[]{
                    "Negative rect height",
                    new Rect(x:10, y:20, width:110, height:-100),
                    17,
                    new Rect(x:10, y:-80, width:110, height:17)
                };
            }
        }
    }
}
