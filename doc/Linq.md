**Linq CheatSheet**

```c#
    public void foo
    {
        var isAnyPeople = (from p in people 
                   where p.Gender == Gender.Unknown 
                   select p).Any (); 
    }
```