---
title: Multiple return values
layout: post
---

{% requiredcode %}
public interface ICalculator {
	int Add(int a, int b);
	string Mode { get; set; }
}
ICalculator calculator;
[SetUp] public void SetUp() { calculator = Substitute.For<ICalculator>(); }
{% endrequiredcode %}

A call can also be configured to return a different value over multiple calls. The following example shows this for a call to a property, but it works the same way for method calls.

{% examplecode csharp %}
calculator.Mode.Returns("DEC", "HEX", "BIN");
Assert.AreEqual("DEC", calculator.Mode);
Assert.AreEqual("HEX", calculator.Mode);
Assert.AreEqual("BIN", calculator.Mode);
{% endexamplecode %}

This can also be achieved by [returning from a function](/help/return-from-function), but passing multiple values to `Returns()` is simpler and reads better.
