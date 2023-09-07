using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_LL
{
    public interface ILinkedList<T>
    {
        int Count { get; }
        void AddFirst(T value);
        void InsertAfter(INode<T> value, int index);
        void AddLast(T value);
        void Clear();
        void RemoveFirst();
        void RemoveAt(int index);
        void RemoveLast();
        INode<T>? FindFirst(T value);
        INode<T>[] FindAll(T value);
        INode<T> Head { get; }
        INode<T> Tail { get; }
        IEnumerable<INode<T>> Nodes { get; }
        

    }

    public interface INode<T>
    {
        T Content { get; set; }
        INode<T>? Next();
    }
}
