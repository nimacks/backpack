#Language Integrated Query (LINQ) CheatSheet


>LINQ, or Language Integrated Query, is a set of language and framework features
for writing structured type-safe queries over local object collections and remote data
sources.

- **Lambda Expressions** - Easily pass anonymous functions to methods
- **Extension Methods** - allow you to extend any type with additional methods
- **Anonymous types**- allow you to create new classes with explicitly stating the type
- **Query Expression Syntax** -similar to SQL
- **Generics** - Create classes and methods that can work with any type
- **yield and var keywords**



### Standard Query Operators


####Filtering Sequences

`.Where()` - Filters a sequence based on a condition 

```c#
    int[] nums = new [] {1,2,3,4,5}

//Fluid

    var result = nums.Where(c => c > 3);

//Query Expression  

    var result = from n in names
                 where n > 3
                 select n;
```
`.Skip()` - By passes a specified number of elements in a sequence and returns the remaining elements

```c#
    int[] nums = new [] {1,2,3,4,5}

    var result = nums.Skip(3);

```