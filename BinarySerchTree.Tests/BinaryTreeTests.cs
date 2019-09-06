using NUnit.Framework;

namespace BinarySerchTree.Tests
{
    public class BinaryTreeTests
    {
        [Test]
        public void PreOrderTraversalTest()
        {
            BinaryTree<int> instance = new BinaryTree<int>();

            instance.Add(8);    //                        8
            instance.Add(5);    //                      /   \
            instance.Add(12);   //                     5    12 
            instance.Add(3);    //                    / \   / \  
            instance.Add(7);    //                   3   7 10 15
            instance.Add(10);
            instance.Add(15);

            BinaryTree<int> expectedResult = new BinaryTree<int>();

            expectedResult.Add(3);
            expectedResult.Add(7);
            expectedResult.Add(5);
            expectedResult.Add(10);
            expectedResult.Add(15);
            expectedResult.Add(12);
            expectedResult.Add(8);

            BinaryTree<int> result = new BinaryTree<int>();

            foreach (var item in instance)
            {
                result.Add(item);
            }

            Assert.AreEqual(expectedResult, result);
        }
    }
}