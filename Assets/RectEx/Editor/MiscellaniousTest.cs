using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
	public class MiscellaniousTest {

		[Test]
		[TestCaseSource(typeof(AbsSource))]
		public void Abs(Rect from, Rect expected) {
			var actual = from.Abs();
			Assert.AreEqual(expected, actual);
		}

		class AbsSource : IEnumerable {
			public IEnumerator GetEnumerator() {
				yield return new object[] {
					new Rect(x:0, y:0, width:50, height:10),
					new Rect(x:0, y:0, width:50, height:10)
				};
				yield return new object[] {
					new Rect(x:1, y:3, width:-10, height: 20),
					new Rect(x:-9, y:3, width:10, height:20)
				};
				yield return new object[] {
					new Rect(x:1, y:3, width:10, height: -20),
					new Rect(x:1, y:-17, width:10, height:20)
				};
				yield return new object[] {
					new Rect(x:-10, y:-30, width:-50, height:10),
					new Rect(x:-60, y:-30, width:50, height:10)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:-50, height:-10),
					new Rect(x:-50, y:-10, width:50, height:10)
				};
			}
		}

		[Test]
		[TestCaseSource(typeof(InvertSource))]
		public void Invert(Rect from, Rect expected) {
			var actual = from.Invert();
			Assert.AreEqual(expected, actual);
		}

		class InvertSource : IEnumerable {
			public IEnumerator GetEnumerator() {
				yield return new object[] {
					new Rect(x:5, y:10, width:50, height:10),
					new Rect(x:10, y:5, width:10, height:50)
				};
				yield return new object[] {
					new Rect(x:-5, y:10, width:50, height:10),
					new Rect(x:10, y:-5, width:10, height:50)
				};
				yield return new object[] {
					new Rect(x:5, y:10, width:-50, height:10),
					new Rect(x:10, y:5, width:10, height:-50)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:0, height:0),
					new Rect(x:0, y:0, width:0, height:0)
				};
			}
		}

		[Test]
		[TestCaseSource(typeof(UnionSource))]
		public void Union(Rect from, Rect[] other, Rect expected) {
			var actual = from.Union(other);
			Assert.AreEqual(expected, actual);
		}

		class UnionSource : IEnumerable {
			public IEnumerator GetEnumerator() {
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					new Rect[] {
						new Rect(x:90, y:90, width:20, height:20)
					},
					new Rect(x:0, y:0, width:110, height:110)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					new Rect[] {
						new Rect(x:90, y:90, width:20, height:20),
						new Rect(x:90, y:90, width:20, height:20)
					},
					new Rect(x:0, y:0, width:110, height:110)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					new Rect[] {
						new Rect(x:90, y:90, width:20, height:20),
						new Rect(x:190, y:190, width:20, height:20)
					},
					new Rect(x:0, y:0, width:210, height:210)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					null,
					new Rect(x:0, y:0, width:100, height:100)
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					new Rect[] {
						new Rect(x:0, y:0, width:100, height:100)
					},
					new Rect(x:0, y:0, width:100, height:100)
				};
			}
		}
	}
}