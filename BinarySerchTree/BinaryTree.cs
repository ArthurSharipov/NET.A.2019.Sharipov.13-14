using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BinarySerchTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        private BinaryTreeNode<T> _head;

        private int _count;

        /// <summary>
        /// Adding a new tree node.
        /// </summary>
        /// <param name="value"></param>
        public void Add(T value)
        {
            if (_head == null)
            {
                _head = new BinaryTreeNode<T>(value);
            }

            else
            {
                AddTo(_head, value);
            }
            _count++;
        }

        /// <summary>
        /// Recursive adding algorithm.
        /// </summary>
        /// <param name="node"></param>
        /// <param name="value"></param>
        private void AddTo(BinaryTreeNode<T> node, T value)
        {
            if (value.CompareTo(node.Value) < 0)
            {
                if (node.Left == null)
                {
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {             
                    AddTo(node.Left, value);
                }
            }

            else
            {
                if (node.Right == null)
                {
                    node.Right = new BinaryTreeNode<T>(value);
                }

                else
                {
                    AddTo(node.Right, value);
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return PreOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Symmetric binary tree traversal order:
        /// 1. Go into the left subtree.
        /// 2. Go to the root.
        /// 3. Go to the right subtree.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> InOrderTraversal()
        {
            if (_head != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _head;
                bool goLeftNext = true;

                stack.Push(current);

                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }

                    yield return current.Value;

                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }

        /// <summary>
        /// Reverse binary tree traversal order:
        /// 1. Go into the left subtree.
        /// 2. Go to the right subtree.
        /// 3. Go to the root.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> PostOrderTraversal()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = _head;
            bool goLeftNext = true;

            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        yield return current.Value;

                        stack.Push(current);
                        current = current.Left;
                    }
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }

                else
                {
                    yield return current.Value;

                    current = stack.Pop();
                    goLeftNext = false;
                }
            }
        }

        /// <summary>
        /// Direct binary tree traversal order:
        /// 1. Go to the root.
        /// 2. Go into the left subtree.
        /// 3. Go to the right subtree
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> PreOrderTraversal()
        {
            Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
            BinaryTreeNode<T> current = _head;
            bool goLeftNext = true;

            Stack<BinaryTreeNode<T>> temp = new Stack<BinaryTreeNode<T>>();
            stack.Push(current);

            while (stack.Count > 0)
            {
                if (goLeftNext)
                {
                    while (current.Left != null)
                    {
                        stack.Push(current);
                        current = current.Left;
                    }

                    yield return current.Value;

                    if (temp.Count != 0)
                        yield return temp.Pop().Value;
                }

                if (current.Right != null)
                {
                    current = current.Right;
                    goLeftNext = true;
                }

                else
                {
                    current = stack.Pop();

                    if (current != _head)
                        temp.Push(current);

                    goLeftNext = false;

                    if (stack.Count == 0)
                        yield return _head.Value;
                }
            }
        }
    }
}