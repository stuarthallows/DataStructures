using DataStructures.Library;

Console.WriteLine("Hello, World!");

/*
 * Linked lists -
 *      singly linked list,
 *      doubly linked list - supports reverse traversal
 *      sorted linked list
 * Can be used as the underlying data structure for other structures like stacks, queues
 */



var doublyLinkedList = new DoublyLinkedList<int>();
for(var i = 0; i < 10; i++)
{
    doublyLinkedList.AddHead(i);
}
