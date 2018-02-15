using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
    public class MoveToTest {

        [Test]
        [TestCaseSource(typeof(MoveRightSource))]
        public void MoveRight(string name, Rect from, float space, Rect expected) {
            var actual = from.MoveRight(space);
            Assert.AreEqual(expected, actual);
        }

        class MoveRightSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:10),
                    0,
                    new Rect(x:50, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:10),
                    7,
                    new Rect(x:57, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:-13, y:0, width:50, height:10),
                    7,
                    new Rect(x:44, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    7,
                    new Rect(x:17, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    -7,
                    new Rect(x:53, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    -7,
                    new Rect(x:3, y:0, width:50, height:10)
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveRightForSource))]
        public void MoveRightFor(string name, Rect from, float step, float space, Rect expected) {
            var actual = from.MoveRightFor(step, space);
            Assert.AreEqual(expected, actual);
        }

        class MoveRightForSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:10),
                    10,
                    0,
                    new Rect(x:50, y:0, width:10, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:10),
                    20,
                    7,
                    new Rect(x:57, y:0, width:20, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:-13, y:0, width:50, height:10),
                    20,
                    7,
                    new Rect(x:44, y:0, width:20, height:10)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    13,
                    7,
                    new Rect(x:17, y:0, width:13, height:10)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    20,
                    -7,
                    new Rect(x:53, y:0, width:20, height:10)
                };
                yield return new object[] {
                    "Negative step",
                    new Rect(x:0, y:0, width:50, height:10),
                    -20,
                    7,
                    new Rect(x:37, y:0, width:20, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    10,
                    -7,
                    new Rect(x:3, y:0, width:10, height:10)
                };
                yield return new object[] {
                    "Negative space, width, step",
                    new Rect(x:10, y:0, width:-50, height:10),
                    -10,
                    -7,
                    new Rect(x:-7, y:0, width:10, height:10)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveLeftSource))]
        public void MoveLeft(string name, Rect from, float space, Rect expected) {
            var actual = from.MoveLeft(space);
            Assert.AreEqual(expected, actual);
        }

        class MoveLeftSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:100, y:0, width:50, height:10),
                    0,
                    new Rect(x:50, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:100, y:0, width:50, height:10),
                    7,
                    new Rect(x:43, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:-13, y:0, width:50, height:10),
                    7,
                    new Rect(x:-70, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    7,
                    new Rect(x:-97, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    -7,
                    new Rect(x:-33, y:0, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    -7,
                    new Rect(x:-83, y:0, width:50, height:10)
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveLeftForSource))]
        public void MoveLeftFor(string name, Rect from, float step,float space, Rect expected) {
            var actual = from.MoveLeftFor(step, space);
            Assert.AreEqual(expected, actual);
        }

        class MoveLeftForSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:100, y:0, width:50, height:10),
                    10,
                    0,
                    new Rect(x:90, y:0, width:10, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:100, y:0, width:50, height:10),
                    17,
                    7,
                    new Rect(x:76, y:0, width:17, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:-13, y:0, width:50, height:10),
                    13,
                    7,
                    new Rect(x:-33, y:0, width:13, height:10)
                };
                yield return new object[] {
                    "Negative width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    32,
                    7,
                    new Rect(x:-79, y:0, width:32, height:10)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    20,
                    -10,
                    new Rect(x:0, y:0, width:20, height:10)
                };
                yield return new object[] {
                    "Negative step",
                    new Rect(x:100, y:0, width:50, height:10),
                    -17,
                    7,
                    new Rect(x:93, y:0, width:17, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:-50, height:10),
                    57,
                    -7,
                    new Rect(x:-90, y:0, width:57, height:10)
                };
                yield return new object[] {
                    "Negative space, width, step",
                    new Rect(x:10, y:0, width:-50, height:10),
                    -50,
                    -10,
                    new Rect(x:-30, y:0, width:50, height:10)
                };
            
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveUpSource))]
        public void MoveUp(string name, Rect from, float space, Rect expected) {
            var actual = from.MoveUp(space);
            Assert.AreEqual(expected, actual);
        }

        class MoveUpSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:10),
                    0,
                    new Rect(x:0, y:-10, width:50, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:10),
                    7,
                    new Rect(x:0, y:-17, width:50, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:0, y:-13, width:50, height:10),
                    7,
                    new Rect(x:0, y:-30, width:50, height:10)
                };
                yield return new object[] {
                    "Negative height",
                    new Rect(x:10, y:0, width:50, height:-50),
                    7,
                    new Rect(x:10, y:-107, width:50, height:50)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    -7,
                    new Rect(x:10, y:-3, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:50, height:-10),
                    -7,
                    new Rect(x:10, y:-13, width:50, height:10)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveUpForSource))]
        public void MoveUpFor(string name, Rect from, float step, float space, Rect expected) {
            var actual = from.MoveUpFor(step, space);
            Assert.AreEqual(expected, actual);
        }

        class MoveUpForSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:100),
                    10,
                    0,
                    new Rect(x:0, y:-10, width:50, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:100),
                    10,
                    7,
                    new Rect(x:0, y:-17, width:50, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:0, y:-13, width:50, height:100),
                    10,
                    7,
                    new Rect(x:0, y:-30, width:50, height:10)
                };
                yield return new object[] {
                    "Negative height",
                    new Rect(x:10, y:0, width:50, height:-50),
                    20,
                    7,
                    new Rect(x:10, y:-77, width:50, height:20)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    20,
                    -7,
                    new Rect(x:10, y:-13, width:50, height:20)
                };
                yield return new object[] {
                    "Negative step",
                    new Rect(x:0, y:0, width:50, height:100),
                    -10,
                    7,
                    new Rect(x:0, y:-7, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space, height",
                    new Rect(x:10, y:0, width:50, height:-10),
                    30,
                    -7,
                    new Rect(x:10, y:-33, width:50, height:30)
                };
                yield return new object[] {
                    "Negative space, height, step",
                    new Rect(x:10, y:0, width:50, height:-10),
                    -30,
                    -7,
                    new Rect(x:10, y:-3, width:50, height:30)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveDownSource))]
        public void MoveDown(string name, Rect from, float space, Rect expected) {
            var actual = from.MoveDown(space);
            Assert.AreEqual(expected, actual);
        }

        class MoveDownSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:10),
                    0,
                    new Rect(x:0, y:10, width:50, height:10)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:10),
                    7,
                    new Rect(x:0, y:17, width:50, height:10)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:0, y:-13, width:50, height:10),
                    7,
                    new Rect(x:0, y:4, width:50, height:10)
                };
                yield return new object[] {
                    "Negative height",
                    new Rect(x:10, y:0, width:50, height:-50),
                    7,
                    new Rect(x:10, y:7, width:50, height:50)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    -7,
                    new Rect(x:10, y:3, width:50, height:10)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:50, height:-10),
                    -7,
                    new Rect(x:10, y:-7, width:50, height:10)
                };
            }
        }

        [Test]
        [TestCaseSource(typeof(MoveDownForSource))]
        public void MoveDownFor(string name, Rect from, float step, float space, Rect expected) {
            var actual = from.MoveDownFor(step, space);
            Assert.AreEqual(expected, actual);
        }

        class MoveDownForSource : IEnumerable {
            public IEnumerator GetEnumerator() {
                yield return new object[] {
                    "Without space",
                    new Rect(x:0, y:0, width:50, height:10),
                    20,
                    0,
                    new Rect(x:0, y:10, width:50, height:20)
                };
                yield return new object[] {
                    "With space",
                    new Rect(x:0, y:0, width:50, height:10),
                    30,
                    7,
                    new Rect(x:0, y:17, width:50, height:30)
                };
                yield return new object[] {
                    "Negative position",
                    new Rect(x:0, y:-13, width:50, height:10),
                    30,
                    7,
                    new Rect(x:0, y:4, width:50, height:30)
                };
                yield return new object[] {
                    "Negative height",
                    new Rect(x:10, y:0, width:50, height:-50),
                    20,
                    7,
                    new Rect(x:10, y:7, width:50, height:20)
                };
                yield return new object[] {
                    "Negative space",
                    new Rect(x:10, y:0, width:50, height:10),
                    35,
                    -7,
                    new Rect(x:10, y:3, width:50, height:35)
                };
                yield return new object[] {
                    "Negative step",
                    new Rect(x:0, y:0, width:50, height:10),
                    -30,
                    7,
                    new Rect(x:0, y:-13, width:50, height:30)
                };
                yield return new object[] {
                    "Negative space, width",
                    new Rect(x:10, y:0, width:50, height:-10),
                    25,
                    -7,
                    new Rect(x:10, y:-7, width:50, height:25)
                };
                yield return new object[] {
                    "Negative space, width, step",
                    new Rect(x:10, y:0, width:50, height:-10),
                    -25,
                    -7,
                    new Rect(x:10, y:-32, width:50, height:25)
                };
            }
        }
    }
}
