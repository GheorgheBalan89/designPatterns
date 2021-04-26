using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures
{
    public class QueueDataType
    {
        public class Client
        {
            private int Id { get; }

            public Client(int id)
            {
                Id = id;
            }
        }
        //static void Main(string[] args)
        //{
        //    //FIFO
        //    Queue myQueue = new Queue();
        //    //the queue is non - generic so we can add elements of any type
                
        //    myQueue.Enqueue(new Client(1));
        //    myQueue.Enqueue(new Client(2));
        //    myQueue.Enqueue(new Client(31));
        //    myQueue.Enqueue("This is my string");
        //    myQueue.Enqueue(null);
        //    myQueue.Enqueue("last");

        //    Console.WriteLine($"Num of elements = {myQueue.Count}");
            
        //    //iterate
        //    //foreach (var element in myQueue)
        //    //{
        //    //    Console.WriteLine(element);
        //    //}

        //    //dequeue - retrieves the topmost element in a queue and removes it too 
        //    //calling the dequeue on an empty queue throws an invalid operation exception

        //    //while (myQueue.Count > 0)
        //    //{
        //    //    Console.WriteLine(myQueue.Dequeue());
        //    //}

        //    //get the element without removing it - peek
        //    Console.WriteLine($"THe peek of myQueue is {myQueue.Peek()}");
        //    // check if value exists
        //    var last = "last 3266";
        //    Console.WriteLine($"Value last exists => {myQueue.Contains(last)}");
        //    Console.WriteLine($"Num of elements = {myQueue.Count}");
        //}
    }
}
