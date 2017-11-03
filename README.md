# Overview

RectEx is an Unity3d asset. *But you will not find RectEx in the AssetStore, I'm going to publish it soon.*

It is designed to make work with GUI easier. 

Stop doing 

```csharp
rect.height = 18;
GUI.LabelField(rect, "First line");
rect.y += rect.height;
GUI.LabelField(rect, "Second line");
rect.y += rect.height;
rect.width = (rect.width - 5) / 2;
GUI.LabelField(rect, "Third line: left part");
rect.x += rect.width + 5;
GUI.LabelField(rect, "Third line: right part");
```

Use **Column** and **Row** instead:

```csharp
var rects = rect.Column(3);

GUI.LabelField(rects[0], "First line");
GUI.LabelField(rects[1], "Second line");

rects = rects[2].Row(2);
GUI.LabelField(rects[0], "Third line: left part");
GUI.LabelField(rects[1], "Third line: right part");
```

# Why do you need it?

Because you don't want to get lost between all these `rect.y += rect.height` and `rect.width = (rect.width - 5) / 2`.

Because you want to draw your GUI elements easy and feel self comfortable.

Because you want to make your code more readable.

Because you can.

# How to use it?

First of all, add *using* statement:

```csharp
using RectEx;
```

There are two base methods:
* `rect.Column(...)` -- makes a column from your rect with horizontal lines.
* `rect.Row(...)` -- makes a row with vertical lines.

There are other methods in RectEx, but Column and Row are the most useful.

Both of them provide two variants of usage:
* pass to method integer **count** of slices and it will cut rect into equal pieces;  
  For example, use `rect.Raw(5);` and you will get a row of 5 cells;
* pass to method array of floats and it will cut rect into differet pieces.  
  For example, use `rect.Raw(new float[]{1,5})` and you will get two cells: a small one and a big one.
  
# What methods does it provide?

* [Row](#row)
* [Column](#column)
* [Grid](#grid)
* [CutFrom](#cutfrom)
* [MoveTo](#moveto)
* [Intend](#intend)
* [Extend](#extend)
* [Union](#union)
* [Invert](#invert)
* [Abs](#abs)

## Row

Method `Row` slices rect into pieces with a vertical separators. Returns an array of pieces.

There are two variants: you may pass to `Row` count of pieses or their relative weights. Look at the example.

![Row Example](mdsrc/rect-ex-row.png)

## Column

Method `Column` slices rect into pieces with a horizontal separators. Returns an array of pieces.

There are two variants: you may pass to `Column` count of pieses or their relative weights. Look at the example.

![Column Example](mdsrc/rect-ex-column.png)

## Grid

## CutFrom

## MoveTo

## Intend

## Extend

## Union

## Invert

## Abs
