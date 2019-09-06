using System;

namespace BinarySerchTree
{
    class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="value"></param>
        public BinaryTreeNode(TNode value)
        {
            Value = value;
        }

        /// <summary>
        /// Left subtree.
        /// </summary>
        public BinaryTreeNode<TNode> Left
        {
            get;
            set;
        }

        /// <summary>
        /// Right subtree.
        /// </summary>
        public BinaryTreeNode<TNode> Right
        {
            get;
            set;
        }

        /// <summary>
        /// The value of the tree element.
        /// </summary>
        public TNode Value
        {
            get;
            private set;
        }

        /// <summary>
        /// Comparator.
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(TNode other)
        {
            return Value.CompareTo(other);
        }
    }
}