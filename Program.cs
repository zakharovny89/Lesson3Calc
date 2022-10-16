using System.Collections;
using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;


double firstValue = 0;
double secondValue = 0;
string sign = "+";
double result = 0;
string instance;
Queue FiveLastTask= new Queue(5);
bool end = false;

while (!end)
{    
    Console.WriteLine("If you want to solve the Next task, click 'N'\r\n" +
        "If you want to see the Last five decisions, click 'L'\r\n" +
        "If you want to Exit, click 'E'");
    string WhatsNext = Console.ReadLine();
    switch (WhatsNext)
    {
        case "N":
            InputData();
            Solution(firstValue, secondValue, sign);
            Console.WriteLine(OutputData(firstValue, secondValue, sign));
            Console.WriteLine();
            break;
        case "L":
            foreach (string task in FiveLastTask)
            {
                Console.WriteLine(task);
            }
            Console.WriteLine();
            break;
        case "E":
            end = true;
            break;
        default:
            Console.WriteLine("Something wrong");
            Console.WriteLine();
            break;
    }
}

void InputData()
{
    string a; //variable to store input values
    bool b = true; //variable for loop operation
    while (b) // first value check
    {
        Console.WriteLine("Input first value:");
        a = Console.ReadLine();
        if (double.TryParse(a, out firstValue))
        {
            b = false;
        }
        else
        {
            Console.WriteLine("Please, enter the number");
        }
    }
    b = true;
    while (b) // second value check
    {
        Console.WriteLine("Input second value:");
        a = Console.ReadLine();
        if (double.TryParse(a, out secondValue))
        {
            b = false;
        }
        else
        {
            Console.WriteLine("Please, enter the number");
        }
    }
    b = true;
    while (b) // sign check
    {
        Console.WriteLine("Input '+', '-', '*', or '/'");
        a = Console.ReadLine();
        if (a == "+" || a == "-" || a == "*" || a == "/")
        {
            sign = a;
            b = false;
        }
        else
        {
            Console.WriteLine("Please, enter '+', '-', '*', or '/'");
        }
    }
}

double Solution(double firstValue, double secondValue, string sign)
{
    switch (sign)
    {
        case "+":
            return result = firstValue + secondValue;
        case "-":
            return result = firstValue - secondValue;
        case "*":
            return result = firstValue * secondValue;
        case "/":
            return result = firstValue / secondValue;
    }
    return result;
}

string OutputData(double firstValue, double secondValue, string sign)
{
    instance = $"{firstValue} {sign} {secondValue} = {result}";
    FiveLastTask.Enqueue(instance);
    if (FiveLastTask.Count > 5)
    {
        FiveLastTask.Dequeue();
    }
    return instance;
}