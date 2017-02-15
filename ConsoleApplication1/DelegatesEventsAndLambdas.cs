using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 
/// Summary for a Lynda course
/// 
/// 
/// Delegates introduced in C# 1.0
/// Anonymous functions using delegate keyword in C# 2.0
/// Lambda expressions introduced in C# 3.0
/// 
/// Delegates: 
///     Placeholders for functions. (A function in a variable)
///     Can be dynamically chained together and called in order, one after the other.
/// 
/// Events: 
///     Used to broadcast and listen to messages.
///     Event broadcaster acts if a criteria has been met. 
///     Other applications or internal event listeners can then act upon this information.
///     (Useful when you need stuff to happen asynchronously)
/// 
/// Lambdas: 
///     Functionally the same as regular delegates
///     Written using a more concise syntax that can be easier to read
///     Used to implement a syntax called "anonymous functions" (Nameless functions)
///     
/// 
/// Common Scenarios: 
///     Delegates
///         Program Logic -> Location x, y, z (Nightmare if the company has thousands or tens of thousands of destinations with different setups.)
///                       -> Each location determines it's appropriate function, Locations are responsible for it's own fees and rules.
///     Events
///         The program listens for an event, where it acts if there is a change.
///     Lambdas later.
///         
/// Delegates functions like callbacks
///     Type safe: checks signatures.
///     Can be used to define callback functions
///     Can be dynamically switched at runtime
/// 
/// Basic Delegates
///     public delegate int MyDelegate(int i, string s);
/// 
///     int MyFunc(int i, string s) {
///         -- delegate implementation goes here
///     }
///     ...
///     -- Somewhere else in the code
///     MyDelegate f = MyFunc;
///     // later, call the delegate
///         int result = f(250, "Hello World");
/// 
/// Anonymous Delegates
///     public delegate int MyDelegate(int i, string s);
///     
///     {
///         ...
///         -- Somewhere in the code
///         MyDelegate f = delegate(int i, string s) {
///             -- implementation code goes here, right inline
///         };
///         
///         -- later, call the delegate
///         int result = f(250, "Hello World");
///     }
/// 
/// Composable Delegates
///     Functions: foo, bar and baz.
///     MyDelegate f1 = foo, f2 = bar, f3 = baz;
///     MyDelegate all = f1 + f2;
///     MyDelegate all += f3;
/// 
///     int result = all(250, "Hello!");
///     all -= f2;
///     
///     result = all(100, "Goodbye!");
///     
///     Unhandled exceptions will skip remaining delegates.
///     Only the last return value will be returned to the calling function
///     To pass results from one delegate to another, use ref variables.
/// 
/// </summary>

namespace ConsoleApplication1
{
    public delegate void MyDelegate(int arg1, int arg2);

    class DelegatesEventsAndLambdas
    {
        static void func1(int arg1, int arg2)
        {
            string result = (arg1 + arg2).ToString();
            Console.WriteLine("The number is: " + result);
        }

        static void func2(int arg1, int arg2)
        {
            string result = (arg1 * arg2).ToString();
            Console.WriteLine("The number is: " + result);
        }

        static void Main(string[] args)
        {
            MyDelegate f1 = func1;
            MyDelegate f2 = func2;
            MyDelegate f1f2 = f1 + f2;

            Console.WriteLine("Calling the first delegate");
            f1(10, 20);
            Console.WriteLine("Calling the second delegate");
            f2(10, 20);
            Console.WriteLine("Calling the chained delegate");
            f1f2(10, 20);
            Console.WriteLine("\nPress Enter Key to Continue");
            Console.ReadLine();
        }
    }
}
