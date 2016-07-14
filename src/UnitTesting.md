## Unit tests Best practices

### Basics
The main objective in unit testing is to test  distinct pieces of functionality 
that are in a method contained .
The number of tests you create is dependent on the code paths found in a method.
For example

```c# 
Public class Calculator
{
	public int Add(int x, int y){
		// one code path
		return x + y;
	}
}
```
Because there is one code path and no other code banches you could create a simple test as illustrated below

```c#
[TestFixture]
public class CalculatorFixture
{
	public void Should_Add_Two_Numbers()
	{
		var sut = new Calculator();
		var actual = sut.Add(4,4);
		Assert.AreEqual(actual,8);	
	}
}
```


### Naming Your Unit Tests

>Where there are multiple code paths then it is expected that you write a test for every possible outcome of each code path.


### Unit testing with Dependencies (aka Mocking)
There are occasions when a class takes a dependency on a class or interface. Since each class should have associated unit tests we only need to mock the dependency and focus on the specific piece of functionality we're interested in.

Say we had a class GradeCalculator, which took a dependency on ICaculator. We would not need to worry about creating a concrete implmentation of Icalculator.We should merely mock it.

> Mock objects and classes which are dependent to test a classs

>Write tests about the desired effects and not the implementions details

Example 1

```c#
public void Added_Item_Increases_CacheCount() [Recommended]
public void Add_Item_To_Cache()
```

Example 2

```c#
public void Item_WhenSearched_IsFound() [Recommended]
public void SearchItem()
```

> Don't Moq everything. Moq objects with cascading dependencies

Moqqing objects are most beneficial when you have objects with cascading dependencies.
If you're testing an object, say a dictionary being used as a cache you don't need
to mock this. You can simple create a new instance of the dictionary


#### Integration tests.


http://www.developerhandbook.com/unit-testing/writing-unit-tests-with-nunit-and-moq/
http://www.developerhandbook.com/category/unit-testing/
https://github.com/Moq/moq4/wiki/Quickstart
