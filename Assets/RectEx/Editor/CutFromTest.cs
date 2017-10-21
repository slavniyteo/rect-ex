using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
	public class CutFromTest {

		[Test]
		[TestCaseSource(typeof(AbsSource))]
		public void CutFromRight(Rect from, float width, float space, Rect[] expected) {
			var actual = from.CutFromRight(width, space);
			Assert.AreEqual(expected, actual);
		}

		class AbsSource : IEnumerable {
			public IEnumerator GetEnumerator() {
				yield return new object[] {
					new Rect(x:0, y:0, width:50, height:10),
					7,
					3,
					new Rect[] {
						new Rect(x:0, y:0, width:40, height:10),
						new Rect(x:43, y:0, width:7, height:10)
					}
				};
			}
		}
	}
}