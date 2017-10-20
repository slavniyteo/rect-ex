using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
	public class RowTest {

		[Test]
		[TestCaseSource(typeof(Source))]
		public void Weights(string caseName, Rect from, float[] weights, float space, Rect[] expected) {
			var actual = from.Row(weights, space);
			Assert.AreEqual(expected, actual);
		}

		class Source : IEnumerable {
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

	}
}