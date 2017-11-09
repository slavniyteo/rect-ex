using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
    public class GridTest {

        [Test]
        [TestCaseSource(typeof(GridSource))]
        public void Grid(string name, Rect from, int rows, int columns, float vSpace, float hSpace, Rect[,] expected) {
            var actual = from.Grid(rows, columns, vSpace, hSpace);
            Assert.AreEqual(expected, actual);
        }

        class GridSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without spaces",
                    new Rect(x:0, y:0, width:100, height:50),
                    2, 2,
                    0, 0,
                    new Rect[,]{
                        {
                            new Rect(x:0, y:0, width:50, height:25),
                            new Rect(x:50, y:0, width:50, height:25)
                        },
                        {
                            new Rect(x:0, y:25, width:50, height:25),
                            new Rect(x:50, y:25, width:50, height:25)
                        }
                    }
                };
                yield return new object[] {
                    "With spaces",
                    new Rect(x:0, y:0, width:100, height:50),
                    2, 2,
                    10, 20,
                    new Rect[,]{
                        {
                            new Rect(x:0, y:0, width:40, height:20),
                            new Rect(x:60, y:0, width:40, height:20)
                        },
                        {
                            new Rect(x:0, y:30, width:40, height:20),
                            new Rect(x:60, y:30, width:40, height:20)
                        }
                    }
                };
                yield return new object[] {
                    "Single cell",
                    new Rect(x:0, y:0, width:100, height:50),
                    1, 1,
                    10, 20,
                    new Rect[,]{
                        {
                            new Rect(x:0, y:0, width:100, height:50),
                        }
                    }
                };
                yield return new object[] {
                    "4x3 grid",
                    new Rect(x:0, y:0, width:160, height:110),
                    4, 3,
                    10, 20,
                    new Rect[,]{
                        {
                            new Rect(x:0, y:0, width:40, height:20),
                            new Rect(x:60, y:0, width:40, height:20),
                            new Rect(x:120, y:0, width:40, height:20)
                        },
                        {
                            new Rect(x:0, y:30, width:40, height:20),
                            new Rect(x:60, y:30, width:40, height:20),
                            new Rect(x:120, y:30, width:40, height:20)
                        },
                        {
                            new Rect(x:0, y:60, width:40, height:20),
                            new Rect(x:60, y:60, width:40, height:20),
                            new Rect(x:120, y:60, width:40, height:20)
                        },
                        {
                            new Rect(x:0, y:90, width:40, height:20),
                            new Rect(x:60, y:90, width:40, height:20),
                            new Rect(x:120, y:90, width:40, height:20)
                        }

                    }
                };
            }
        }
    }
}
