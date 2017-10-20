using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

namespace RectEx {
	public class RowTest {

		[Test]
		[TestCaseSource(typeof(WeightsPassSource))]
		public void WeightsPass(string caseName, Rect from, float[] weights, float space, Rect[] expected) {
			var actual = from.Row(weights, space);
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
		public void WidthesPass(string caseName, Rect from, float[] weights, float[] widthes, float space, Rect[] expected) {
			var actual = from.Row(weights, widthes, space);
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
					"Negative width",
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
		public void SugarWithoutArrays(Rect from, int count, float space, Rect[] expected){
			var actual = from.Row(count, space);
			Assert.AreEqual(expected, actual);
		}

		public class SugarWithoutArraysSource : IEnumerable {
			public IEnumerator GetEnumerator(){
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					1,
					5,
					new Rect[]{
						new Rect(x:0, y:0, width:100, height:100)
					}
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					2,
					5,
					new Rect[]{
						new Rect(x:0, y:0, width:47.5f, height:100),
						new Rect(x:52.5f, y:0, width:47.5f, height:100),
					}
				};
				yield return new object[] {
					new Rect(x:0, y:0, width:100, height:100),
					3,
					5,
					new Rect[]{
						new Rect(x:0, y:0, width:30, height:100),
						new Rect(x:35, y:0, width:30, height:100),
						new Rect(x:70, y:0, width:30, height:100)
					}
				};
				yield return new object[] {
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
		
		[Test, ExpectedException(typeof(System.ArgumentException))]
		public void ExceptionOnUnsetWeights(){
			new Rect(0,0,10,10).Row(null);
		}

	}
}