using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<int> numbersList = GenerateRandomList(10);
        LinkedList<int> numbersLinkedList = new LinkedList<int>(numbersList);

        Console.WriteLine("Исходный список:");
        PrintList(numbersList);

        int firstElement = numbersList.First();
        numbersList.RemoveAll(number => number % firstElement == 0);

        Console.WriteLine("\nСписок после удаления чисел, делящихся на первый элемент:");
        PrintList(numbersList);

        var currentNode = numbersLinkedList.First;

        while (currentNode != null && currentNode.Next != null)
        {
            if (currentNode.Value % 2 == 0 && currentNode.Next.Value % 2 == 0)
            {
                numbersLinkedList.AddAfter(currentNode, 0);
            }
            else if (currentNode.Value % 2 != 0  && currentNode.Next.Value % 2 != 0)
            {
                numbersLinkedList.AddAfter(currentNode,0);
            }
            else
            {
                currentNode = currentNode.Next;
            }

        }
        
        Console.WriteLine("\nСписок после вставки числа 0 между любыми двумя элементами одной четности:");
        PrintList(numbersLinkedList);
    }

    static List<int> GenerateRandomList(int length)
    {
        Random random = new Random();
        return Enumerable.Range(1, length).Select(_ => random.Next(1, 10)).ToList();
    }

    static void PrintList<T>(IEnumerable<T> list)
    {
        Console.WriteLine(string.Join(" ", list));
    }
}
