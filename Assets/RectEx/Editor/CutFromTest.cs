using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
    public class CutFromTest {

        [Test]
        [TestCaseSource(typeof(CutFromRightSource))]
        public void CutFromRight(string name, Rect from, float width, float space, Rect[] expected) {
            var actual = from.CutFromRight(width, space);
            Assert.AreEqual(expected, actual);
        }

        class CutFromRightSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple",
                    new Rect(x:0, y:0, width:50, height:10),
                    7,
                    3,
                    new Rect[] {
                        new Rect(x:0, y:0, width:40, height:10),
                        new Rect(x:43, y:0, width:7, height:10)
                    }
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:0, y:0, width:50, height:10),
                    10,
                    -1,
                    new Rect[] {
                        new Rect(x:0, y:0, width:41, height:10),
                        new Rect(x:40, y:0, width:10, height:10)
                    }
                };
                yield return new object[] {
                    "Width > rect.width",
                    new Rect(x:0, y:0, width:50, height:10),
                    55,
                    5,
                    new Rect[] {
                        new Rect(x:-10, y:0, width:0, height:10),
                        new Rect(x:-5, y:0, width:55, height:10)
                    }
                };
                yield return new object[] {
                    "Negative space AND width > rect.width",
                    new Rect(x:0, y:0, width:50, height:10),
                    55,
                    -15,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:10),
                        new Rect(x:-5, y:0, width:55, height:10)
                    }
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(CutFromLeftSource))]
        public void CutFromLeft(string name, Rect from, float width, float space, Rect[] expected) {
            var actual = from.CutFromLeft(width, space);
            Assert.AreEqual(expected, actual);
        }

        class CutFromLeftSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple",
                    new Rect(x:0, y:0, width:50, height:10),
                    7,
                    3,
                    new Rect[] {
                        new Rect(x:0, y:0, width:7, height:10),
                        new Rect(x:10, y:0, width:40, height:10)
                    }
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:0, y:0, width:50, height:10),
                    10,
                    -1,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:10),
                        new Rect(x:9, y:0, width:41, height:10)
                    }
                };
                yield return new object[] {
                    "Width > rect.width",
                    new Rect(x:0, y:0, width:50, height:10),
                    55,
                    5,
                    new Rect[] {
                        new Rect(x:0, y:0, width:55, height:10),
                        new Rect(x:60, y:0, width:0, height:10)
                    }
                };
                yield return new object[] {
                    "Negative space AND width > rect.width",
                    new Rect(x:0, y:0, width:50, height:10),
                    55,
                    -15,
                    new Rect[] {
                        new Rect(x:0, y:0, width:55, height:10),
                        new Rect(x:40, y:0, width:10, height:10)
                    }
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(CutFromTopSource))]
        public void CutFromTop(string name, Rect from, float width, float space, Rect[] expected) {
            var actual = from.CutFromTop(width, space);
            Assert.AreEqual(expected, actual);
        }

        class CutFromTopSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple",
                    new Rect(x:0, y:0, width:10, height:50),
                    7,
                    3,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:7),
                        new Rect(x:0, y:10, width:10, height:40)
                    }
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:0, y:0, width:10, height:50),
                    10,
                    -1,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:10),
                        new Rect(x:0, y:9, width:10, height:41)
                    }
                };
                yield return new object[] {
                    "Width > rect.width",
                    new Rect(x:0, y:0, width:10, height:50),
                    55,
                    5,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:55),
                        new Rect(x:0, y:60, width:10, height:0)
                    }
                };
                yield return new object[] {
                    "Negative space AND width > rect.width",
                    new Rect(x:0, y:0, width:10, height:50),
                    55,
                    -15,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:55),
                        new Rect(x:0, y:40, width:10, height:10)
                    }
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(CutFromBottomSource))]
        public void CutFromBottom(string name, Rect from, float width, float space, Rect[] expected) {
            var actual = from.CutFromBottom(width, space);
            Assert.AreEqual(expected, actual);
        }

        class CutFromBottomSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Simple",
                    new Rect(x:0, y:0, width:10, height:50),
                    7,
                    3,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:40),
                        new Rect(x:0, y:43, width:10, height:7)
                    }
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:0, y:0, width:10, height:50),
                    10,
                    -1,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:41),
                        new Rect(x:0, y:40, width:10, height:10)
                    }
                };
                yield return new object[] {
                    "Width > rect.width",
                    new Rect(x:0, y:0, width:10, height:50),
                    55,
                    5,
                    new Rect[] {
                        new Rect(x:0, y:-10, width:10, height:0),
                        new Rect(x:0, y:-5, width:10, height:55)
                    }
                };
                yield return new object[] {
                    "Negative space AND width > rect.width",
                    new Rect(x:0, y:0, width:10, height:50),
                    55,
                    -15,
                    new Rect[] {
                        new Rect(x:0, y:0, width:10, height:10),
                        new Rect(x:0, y:-5, width:10, height:55)
                    }
                };
            
            }
        }
    }
}
