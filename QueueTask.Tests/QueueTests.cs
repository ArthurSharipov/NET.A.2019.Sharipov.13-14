using NUnit.Framework;

namespace QueueTask.Tests
{
    public class QueueTests
    {
        [Test]
        [TestCase(ExpectedResult = 5)]
        public int DequeueFirstTest()
        {
            Queue<int> queue = new Queue<int>();

            queue.EnqueueFirst(1);
            queue.EnqueueFirst(2);
            queue.EnqueueFirst(3);
            queue.EnqueueFirst(4);
            queue.EnqueueFirst(5);

            return queue.DequeueFirst();
        }

        [Test]
        [TestCase(ExpectedResult = "5")]
        public string DequeueLastTest()
        {
            Queue<string> queue = new Queue<string>();

            queue.EnqueueLast("1");
            queue.EnqueueLast("2");
            queue.EnqueueLast("3");
            queue.EnqueueLast("4");
            queue.EnqueueLast("5");

            return queue.DequeueLast();
        }

        [Test]
        [TestCase(ExpectedResult = 15)]
        public int EnumeratorTestInt32()
        {
            Queue<int> queue = new Queue<int>();
            int sumOfQueueValues = 0;

            queue.EnqueueLast(1);
            queue.EnqueueLast(2);
            queue.EnqueueLast(3);
            queue.EnqueueLast(4);
            queue.EnqueueLast(5);

            foreach (var item in queue)
            {
                sumOfQueueValues += item;
            }

            return sumOfQueueValues;
        }

        [Test]
        [TestCase(ExpectedResult = "54321")]
        public string EnumeratorTestString()
        {
            Queue<string> queue = new Queue<string>();
            string concatOfQueueValues = null;

            queue.EnqueueFirst("1");
            queue.EnqueueFirst("2");
            queue.EnqueueFirst("3");
            queue.EnqueueFirst("4");
            queue.EnqueueFirst("5");

            foreach (var item in queue)
            {
                concatOfQueueValues += item;
            }

            return concatOfQueueValues;
        }
    }
}