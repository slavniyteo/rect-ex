using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
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
	}
}