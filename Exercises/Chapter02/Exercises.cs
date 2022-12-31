using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Exercises.Chapter2
{
   static class Exercises
   {
      // 1. Write a function that negates a given predicate: whenever the given predicate
      // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
      //    Clarification: Negating a predicate, where a "predicate" is a delegate that
      //                   returns a bool upon receiving some <T> item passed in.
      //                      public delegate bool Predicate<in T>(T obj);
      //                   
      static Func<T, bool> Negate<T>(this Func<T, bool> self) => t => !self(t);
      //     ^-----------^                                       ^-----------^
      //                                                           |_ 

      [Test] public static void TestNegate()
      {
         Func<int, bool> divBy3 = x => x%3 == 0;
         var actual = divBy3.Negate();
         actual(6).Should().BeFalse();
      }

      static bool Negate<T>(this Predicate<T> self, T input)
      {
         return !self(input);
      }

      [Test] public static void TestNegatePredicate()
      {
         Predicate<int> givenDivisibleByThree = (x) => x % 3 == 0;
         bool actual = givenDivisibleByThree.Negate(6);
         actual.Should().BeFalse();
      }

      // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
      // rather than sorting it in place).
      

      // 3. Generalize your implementation to take a `List<T>`, and additionally a 
      // `Comparison<T>` delegate.

      // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
      // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
      // takes a `Func<IDisposable>` as first
      // parameter, instead of the `IDisposable`. (This can be used to fix warnings
      // given by some code analysis tools about instantiating an `IDisposable` and
      // not disposing it.)
   }
}
