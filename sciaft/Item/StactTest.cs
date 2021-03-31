using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StactTest : MonoBehaviour
{
    void Start()
    {
        Stack<int> numbers = new Stack<int>();
        numbers.Push(1);
        numbers.Push(2);
        numbers.Push(3);
        numbers.Push(4);
        numbers.Push(5);
        print(numbers.Count);
        /*
        print(numbers.Count);
        print(numbers.Pop());
        print(numbers.Count);
        print(numbers.Peek());
        print(numbers.Count);*/

        printout(numbers);

        numbers.Pop();
        numbers.Pop();
        printout(numbers);
    }

    void printout(Stack<int> nums)
    {
        print("Stack list:");
        foreach (int num in nums)
        {
            print(num);
        }
    }

}
