using NUnit.Framework;

namespace JCMG.JTween.Editor.Tests
{
	[TestFixture]
	internal class FastListTests
	{
		private FastList<int> _fastList;

		[SetUp]
		public void Setup()
		{
			_fastList = new FastList<int>();
		}

		[Test]
		public void AssertThatRangeCanBeAdded()
		{
			var oneArray = new int[5];
			for (var i = 0; i < oneArray.Length; i++)
			{
				oneArray[i] = 1;
			}

			_fastList.AddRange(oneArray);
			Assert.AreEqual(5, _fastList.Length);

			_fastList.AddRange(oneArray);
			Assert.AreEqual(10, _fastList.Length);

			_fastList.AddRange(oneArray);
			Assert.AreEqual(15, _fastList.Length);

			for (var i = 0; i < _fastList.Length; i++)
			{
				Assert.AreEqual(1, _fastList.buffer[i]);
			}
		}

		[Test]
		public void AssertThatRangeCanBeRemoved()
		{
			var oneArray = new int[5];
			for (var i = 0; i < oneArray.Length; i++)
			{
				oneArray[i] = 1;
			}

			var twoArray = new int[5];
			for (var i = 0; i < twoArray.Length; i++)
			{
				twoArray[i] = 2;
			}

			_fastList.AddRange(twoArray);
			_fastList.AddRange(oneArray);
			_fastList.AddRange(twoArray);

			_fastList.RemoveRange(5, 5);

			Assert.AreEqual(10, _fastList.Length);

			for (var i = 0; i < 10; i++)
			{
				Assert.AreEqual(2, _fastList.buffer[i]);
			}
		}
	}
}
