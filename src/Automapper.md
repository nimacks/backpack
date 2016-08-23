## Getting Started With Automapper

Posts in this Series
- Introduction to Automapper
- Mapping Objects With Automapper

#### Introduction
Automapper is a simple library used to map one object into another. 

```c#
public class Car
{
    public string Id {get;set}
    public string Make {get;set;}
    public string Model {get;set;}
}

public class CarViewModel
{
    public string Vin {get;set;}
    public string Name {get;set;}
}

```

For example In order to map the Book class and BookViewModel up above we could manually do this with the following code snippet.

```c#
    CarViewModel = new CarViewModel()
    {
        Vin = car.Id,
        Name = string.Format({0} {1},car.Make,car.Model) 
    }

```

This is pretty straightforward but also very time consuming. In addition, if we added new properties to either The Book class or BookViewModel, we would have to find all instances of where this is used and update them. 

There is a better way using Autompper.

#### Setting up Automapper

Here are the 3 basic steps to get started with Automapper.

- Install in your project via Nuget
- Create an automapperconfig file (which contains mappings)
- Call the RegisterMappings method from your config file in the Global.asax file.


### 1. Install Automapper

First install NuGet. Then install Automapper from the package manager console.

```
PM> Install-Package AutoMapper
```

### 2. Create AutomapperConfig.cs 

A general rule of thumb is to keep as logic out of the Global.asax file as possible. In order to use automapper however, we'll need to register our mappings with the application so it knows how to map our objects.
We therefore, create a new file called AutomapperConfig.cs in the App_Start folder.

|ROOT| -> |App_Start| -> AutomapperConfig.cs

```c#
public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<Car, CarViewModel>().ReverseMap();
            });
        }
    }
```

### 3. Call RegisterMappings in Global.asax

Then, in Global.asax, in the Application_Start() method, add a call to AutoMapperConfig.RegisterMappings()

```c#
     public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
        }
    }
 ```

 In the next lession we'll learn about how to create different types of mappings
 
## Mapping Objects with Automapper

In our first post in the automapper series we looked at how to get started with automapper including how to create mappings and setup up in our Global.asax file.

  Now we want to understand more deeply the basics of automapper and how to create complex object maps.

   ### Automapper Basics

 #### Syntax : `CreateMap`
 The CreateMap method is a static method used to create a mapping between a source and destination object
 ```c#
    AutoMapper.Mapper.CreateMap<SourceClass, DestinationClass>();
  ```

This is a one way mapping which allows us to map a car to a carviewmodel. If we attempted to map a carviewmodel back to a car an
exception would be raised.

##### Usage

```c#
    AutoMapper.Mapper.CreateMap<Car, CarViewModel>();
    var carViewModel = Automapper.Mapper.Map<CarViewModel>(car);
```

If we don't have any custom mapping logic then we can just call ReverseMap
```c#
    AutoMapper.Mapper.CreateMap<Car, CarViewModel>().ReverseMap();
```


#### Syntax : `MapFrom`
 The MapFrom method is used to define complex mappings 
 ```c#
    AutoMapper.Mapper.CreateMap<Car, CarBookViewModel>()
    .ForMember(dest => dest.Name,
               opts => opts.MapFrom(src => string.Format({0} {1},src.Make,src.Model)));
  ```

MapFrom in this instance specifies what the new value of Name will be. That is the string concatenation the properties make and model.

#### Automapper Conventions

##### `Projections`
Since AutoMapper is designed to work generically with any set of classes, it relies on conventions to determine how to map from one object type to another. `One of the most basic conventions is that your type members should have the same names`.

In situations where your source and destination objects do not have the same property names you can project the value of one property onto another property.

```c#
    public class Car
    {
        public string Id {get;set}
        public string Make {get;set;}
        public string Model {get;set;}
    }

    public class CarViewModel
    {
        public string Vin {get;set;}
        public string Name {get;set;}
    }

    AutoMapper.Mapper.CreateMap<Car, CarBookViewModel>()
    .ForMember(dest => dest.Name,
               opts => opts.MapFrom(src => string.Format({0} {1},src.Make,src.Model)));

```

