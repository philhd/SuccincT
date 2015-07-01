## Succinc\<T\> ##
#### Discriminated unions, pattern matching and partial applications for C#  ####
[![Build Status](https://travis-ci.org/DavidArno/SuccincT.svg?branch=master)](https://travis-ci.org/DavidArno/SuccincT) &nbsp;[![NuGet](https://img.shields.io/nuget/v/SuccincT.svg)](http://www.nuget.org/packages/SuccincT)
----------
### Introduction ###
Succinc\<T\> is a small .NET framework that started out as a means of providing an elegant solution to the problem of functions that need return a success state and value, or a failure state. Initially, it consisted of a few `Parse` methods that returned an `ISuccess<T>` result. Then I started learning F#...

Now Succinc\<T\> has grown into a library that provides discriminated unions, pattern matching and partial applications for C#, in addition to providing a set of value parsers that do away with the need for `out` parameters and exceptions, and instead return return an `Option<T>`.

### Current Release ###
The current release of Succinc\<T\> is 1.3.2, which is [available as a nuget package](https://www.nuget.org/packages/SuccincT/). 

This is a bug fix release that addresses two bugs ([Union<T1, T2> comparisons are broken](https://github.com/DavidArno/SuccincT/issues/1) and [value equality for Union\<T1, T2, T3\> and Union\<T1, T2, T3\> hasn't been implemented](https://github.com/DavidArno/SuccincT/issues/2)) as well as offering 1.3.0 enhancements:

1. `Union<T1,T2,T3,T4>` now supports pattern matching.
2. For patterns that return a value (and thus invoke a `Func<>` on match) now support both lambdas/methods and simple expressions for both `Do` and `Else`. See the new [Pattern Matching Section of the wiki](PatternMatching) for more details.
3. Simple union creator factories have been implemented that require the type parameters for multiple unions of the same type to be specified just once. Please see the [Union Creator wiki page](UnionCreators) for more info (don't worry, no singletons or service locators were used in creating this feature!).
4. Various code improvements, including trying to consistently using `TResult` instead of `TReturn` and better comments.
5. The wiki has been significantly expanded. This isn't strictly part of the release, but is published at the same time.
6. Finally, I have remembered to tag the git repos for both the code and the wiki with 1.3.0, so in future I'll know what changed after the release.

### Coming next ####
1. The documentation is improving, but needs some more work. The wiki is well under way, but needs completing.
2. Next up, I plan on experimenting with tuples, to see if Succinc\<T\> can offer an improvement on the current clunky `Tuple` classes, maybe through some sort of `ITuple` interface that can allow any value object to be treated as a tuple. Watch this space for that one. 

### Features ###
#### Discriminated Unions ####
Succinc\<T\> provides a set of union types ([`Union<T1, T2>`](https://github.com/DavidArno/SuccincT/wiki/UnionT1T2), [`Union<T1, T2, T3>`](https://github.com/DavidArno/SuccincT/wiki/UnionT1T2T3) and [`Union<T1, T2, T3, T4>`](https://github.com/DavidArno/SuccincT/wiki/UnionT1T2T3T4)) where an instance will hold exactly one value of one of the specified types. In addition, it provides the likes of [`Option<T>`](https://github.com/DavidArno/SuccincT/wiki/Option_T_) that can have the value `Some<T>` or `None`.

Succinc\<T\> uses [`Option<T>`](https://github.com/DavidArno/SuccincT/wiki/Option_T_) to provide replacements for the .NET basic types' `TryParse()` methods and `Enum.Parse()`. In all cases, these are extension methods to `string` and they return `Some<T>` on a successful parse and `None` when the string is not a valid value for that type. No more `out` parameters!

#### Pattern Matching ####
Succinc\<T\> can pattern match values, unions etc in a way similar to F#'s pattern matching features. It uses a fluent syntax to achieve this as shown by the following example:
```csharp
public static void PrintColorName(Color color)
{
    color.Match()
         .With(Color.Red).Do(x => Console.WriteLine("Red"))
         .With(Color.Green).Do(x => Console.WriteLine("Green"))
         .With(Color.Blue).Do(x => Console.WriteLine("Blue"))
         .Exec();
}
```

See the [Succinc\<T\> pattern matching guide](https://github.com/DavidArno/SuccincT/wiki/PatternMatching) for more details.

#### Partial Applications ####
Succinc\<T\> supports partial function applications. A parameter can be supplied to a multi-parameter method and a new function will be returned that takes the remaining parameters. For example:

```csharp
Func<int,int> times = (p1, p2) => p1 * p2;
var times8 = times.Apply(8);
var result = times8(9); // <- result == 72
```

See the [Succinc\<T\> partial applications guide](https://github.com/DavidArno/SuccincT/wiki/PartialFunctionApplications) for more details.
