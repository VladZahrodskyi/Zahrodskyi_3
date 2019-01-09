using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskForBinaryTree.Tree;
using TaskForBinaryTree.Helper;
using System.Collections.Generic;
namespace TaskBinaryTree.Test
{
	[TestClass]
	public class Add_Method_Tests
	{
		private BinaryTree<Student> students;
		[TestInitialize]
		public void ClassInitialize()
		{
			students = new BinaryTree<Student>()
			{
			new Student() { Name = "1", Mark = 80 },
			new Student() { Name = "2", Mark = 85 },
			new Student() { Name = "3", Mark = 96 },
			new Student() { Name = "4", Mark = 60 },
			new Student() { Name = "5", Mark = 60 },
			new Student() { Name = "6", Mark = 61 },
			new Student() { Name = "7", Mark = 75 },
			new Student() { Name = "8", Mark = 82 },
			new Student() { Name = "9", Mark = 65 },
			new Student() { Name = "10", Mark = 78 }
			};
		}


		[TestMethod]
		public void Was10_Become11_Students()//AddNewStudentToTheCollection
		{
			//Arrange test
			int count;
			int upatedCount;
			Student newStudent = new Student() { Name = "New Student", Mark = 60 };

			//Act test
			count = students.Count;
			students.Add(newStudent);
			upatedCount = students.Count;

			//Assert test

			Assert.AreEqual(count + 1, upatedCount);
		}


		[TestMethod]
		public void Add_Student_Mark_68_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "11", Mark = 68 },//EXPECTED ELEMENT
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "11", Mark = 68 },//EXPECTED ELEMENT
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 68 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_60_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "11", Mark = 60 },//EXPECTED ELEMENT
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "11", Mark = 60 },//EXPECTED ELEMENT
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 60 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_63_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "11", Mark = 63 },//EXPECTED ELEMENT
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "11", Mark = 63 },//EXPECTED ELEMENT
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 63 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_76_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "11", Mark = 76 },//EXPECTED ELEMENT
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "11", Mark = 76 },//EXPECTED ELEMENT
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 76 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_79_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "11", Mark = 79 },//EXPECTED ELEMENT
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "11", Mark = 79 },//EXPECTED ELEMENT
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 79 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_81_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "11", Mark = 81 },//EXPECTED ELEMENT
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "11", Mark = 81 },//EXPECTED ELEMENT
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 81 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_83_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "11", Mark = 83 },//EXPECTED ELEMENT
					new Student() { Name = "3", Mark = 96 }
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "11", Mark = 83 },//EXPECTED ELEMENT
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 83 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		[TestMethod]
		public void Add_Student_Mark_90_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 },
					new Student() { Name = "11", Mark = 90 }//EXPECTED ELEMENT
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "11", Mark = 90 },//EXPECTED ELEMENT
					new Student() { Name = "3", Mark = 96 }
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 90 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}
		public void Add_Student_Mark_100_Rightly()//
		{
			//Arrange test

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 },
					new Student() { Name = "11", Mark = 100 }//EXPECTED ELEMENT
				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 },
					new Student() { Name = "11", Mark = 100 }//EXPECTED ELEMENT
				};
			//Act Test
			students.Add(new Student() { Name = "11", Mark = 100 });//ADD EXPECTED ELEMENT
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());
			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expectedFromPreOrderTraversal, actualFromPreOrderTraversal);
			CollectionAssert.AreEqual(expectedFromInOrderTraversal, actualFromInOrderTraversal);
		}

	}
	[TestClass]
	public class Remove_Method_Tests
	{
		private BinaryTree<Student> students;

		[TestInitialize]
		public void ClassInitialize()
		{
			students = new BinaryTree<Student>()
			{
			new Student() { Name = "1", Mark = 80 },
			new Student() { Name = "2", Mark = 85 },
			new Student() { Name = "3", Mark = 96 },
			new Student() { Name = "4", Mark = 60 },
			new Student() { Name = "5", Mark = 60 },
			new Student() { Name = "6", Mark = 61 },
			new Student() { Name = "7", Mark = 75 },
			new Student() { Name = "8", Mark = 82 },
			new Student() { Name = "9", Mark = 65 },
			new Student() { Name = "10", Mark = 78 }
			};
		}
		[TestMethod]
		public void Still10_Students_Because_Remove_NOT_Exist_Student()
		{
			//Arrange test
			int count;
			int upatedCount;
			Student newStudent = new Student() { Name = "New Student", Mark = 0 };//Not exist

			//Act test
			count = students.Count;
			students.Remove(newStudent);
			upatedCount = students.Count;//Same with variable count

			//Assert test

			Assert.AreEqual(count, upatedCount);
		}
		[TestMethod]
		public void Was10_Become9_Students_Because_Remove_Student()
		{
			//Arrange test
			int count;
			int upatedCount;
			Student newStudent = new Student() { Name = "7", Mark = 80 };//Exist

			//Act test
			count = students.Count;
			students.Remove(newStudent);
			upatedCount = students.Count;//count-1

			//Assert test

			Assert.AreEqual(count - 1, upatedCount);
		}
		[TestMethod]
		public void Head_80_WasRemoved_82_Become_NewHead()
		{
			//Arrange test
			int count;
			int upatedCount;

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					//new Student() { Name = "1", Mark = 80 }, Deleted Head
					new Student() { Name = "8", Mark = 82 },//New Head
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 },

				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					//new Student() { Name = "1", Mark = 80 }, Deleted Head
					new Student() { Name = "8", Mark = 82 },//New Head
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 },

				};

			//Act test
			count = students.Count;
			students.Remove(new Student() { Name = "1", Mark = 80 });
			upatedCount = students.Count;//count-1

			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());

			//Assert test
			Assert.AreEqual(count, upatedCount + 1);//count = 10, updateCount = 9
			CollectionAssert.AreEqual(actualFromInOrderTraversal, expectedFromInOrderTraversal, "InOrderTraversal fail");
			CollectionAssert.AreEqual(actualFromPreOrderTraversal, expectedFromPreOrderTraversal, "PreOrderTraversal fail");

		}
		[TestMethod]
		public void Remove_Student4_And_Student5_Become_NewLeftOfTHeHead()
		{
			//Arrange test
			int count;
			int upatedCount;

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 }, 
					//new Student() { Name = "4", Mark = 60 },//Deleted
					new Student() { Name = "5", Mark = 60 },//New Position
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 },

				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					//new Student() { Name = "4", Mark = 60 },//Deleted
					new Student() { Name = "5", Mark = 60 },//New Position
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 },

				};

			//Act test
			count = students.Count;
			students.Remove(new Student() { Name = "4", Mark = 60 });
			upatedCount = students.Count;//count-1

			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());

			//Assert test
			Assert.AreEqual(count, upatedCount + 1);//count = 10, updateCount = 9
			CollectionAssert.AreEqual(actualFromInOrderTraversal, expectedFromInOrderTraversal, "InOrderTraversal fail");
			CollectionAssert.AreEqual(actualFromPreOrderTraversal, expectedFromPreOrderTraversal, "PreOrderTraversal fail");

		}
		[TestMethod]
		public void Remove_Student2_And_Student3_Become_NewRightOfTHeHead()
		{
			//Arrange test
			int count;
			int upatedCount;

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					//new Student() { Name = "2", Mark = 85 },//Deleted
					new Student() { Name = "3", Mark = 96 },//New Position
					new Student() { Name = "8", Mark = 82 },


				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					//new Student() { Name = "2", Mark = 85 },//Deleted
					new Student() { Name = "3", Mark = 96 },//New Position

				};

			//Act test
			count = students.Count;
			students.Remove(new Student() { Name = "2", Mark = 85 });
			upatedCount = students.Count;//count-1

			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());

			//Assert test
			Assert.AreEqual(count, upatedCount + 1);//count = 10, updateCount = 9
			CollectionAssert.AreEqual(actualFromInOrderTraversal, expectedFromInOrderTraversal, "InOrderTraversal fail");
			CollectionAssert.AreEqual(actualFromPreOrderTraversal, expectedFromPreOrderTraversal, "PreOrderTraversal fail");

		}
		[TestMethod]
		public void Remove_Student7_And_Student10_Become_HisPosition()
		{
			//Arrange test
			int count;
			int upatedCount;

			List<Student> actualFromPreOrderTraversal = new List<Student>();
			List<Student> actualFromInOrderTraversal = new List<Student>();

			List<Student> expectedFromPreOrderTraversal = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					//new Student() { Name = "7", Mark = 75 },//Deleted
					new Student() { Name = "10", Mark = 78},//New Position
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 },


				};
			List<Student> expectedFromInOrderTraversal = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					//new Student() { Name = "7", Mark = 75 },//Deleted
					new Student() { Name = "10", Mark = 78 },//New Position
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 },

				};

			//Act test
			count = students.Count;
			students.Remove(new Student() { Name = "7", Mark = 75 });
			upatedCount = students.Count;//count-1

			actualFromInOrderTraversal.AddRange(students.InOrderTraversal());
			actualFromPreOrderTraversal.AddRange(students.PreOrderTraversal());

			//Assert test
			Assert.AreEqual(count, upatedCount + 1);//count = 10, updateCount = 9
			CollectionAssert.AreEqual(actualFromInOrderTraversal, expectedFromInOrderTraversal, "InOrderTraversal fail");
			CollectionAssert.AreEqual(actualFromPreOrderTraversal, expectedFromPreOrderTraversal, "PreOrderTraversal fail");

		}
	}
	[TestClass]
	public class Traversals_Tests
	{
		private BinaryTree<Student> students;

		[TestInitialize]
		public void ClassInitialize()
		{
			students = new BinaryTree<Student>()
			{
			new Student() { Name = "1", Mark = 80 },
			new Student() { Name = "2", Mark = 85 },
			new Student() { Name = "3", Mark = 96 },
			new Student() { Name = "4", Mark = 60 },
			new Student() { Name = "5", Mark = 60 },
			new Student() { Name = "6", Mark = 61 },
			new Student() { Name = "7", Mark = 75 },
			new Student() { Name = "8", Mark = 82 },
			new Student() { Name = "9", Mark = 65 },
			new Student() { Name = "10", Mark = 78 }
			};
		}
		[TestMethod]
		public void Right_Work_Of_InOrderTraversal()
		{
			//Arrange test


			List<Student> actual = new List<Student>();
			List<Student> expected = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};

			//Act Test

			actual.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expected, actual);

		}
		[TestMethod]
		public void Right_Work_Of_InOrderTraversal_With_Not_Right_Sample_Of_Expected()
		{
			//Arrange test

			List<Student> actual = new List<Student>();
			List<Student> expected = new List<Student>
				{
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 68 },//Wrong, have to be 61
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "10", Mark = 78 },
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "3", Mark = 96 }
				};

			//Act Test

			actual.AddRange(students.InOrderTraversal());

			//Assert test

			CollectionAssert.AreNotEqual(expected, actual);
		}

		[TestMethod]
		public void Right_Work_Of_PreOrderTraversal()
		{
			//Arrange test

			List<Student> actual = new List<Student>();
			List<Student> expected = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 60 },
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};

			//Act Test

			actual.AddRange(students.PreOrderTraversal());

			//Assert test

			CollectionAssert.AreEqual(expected, actual);

		}
		[TestMethod]
		public void Right_Work_Of_PreOrderTraversal_With_Not_Right_Sample_Of_Expected()
		{
			//Arrange test

			List<Student> actual = new List<Student>();
			List<Student> expected = new List<Student>
				{
					new Student() { Name = "1", Mark = 80 },
					new Student() { Name = "4", Mark = 60 },
					new Student() { Name = "5", Mark = 69 },//Wrong, must be 60
					new Student() { Name = "6", Mark = 61 },
					new Student() { Name = "7", Mark = 75 },
					new Student() { Name = "9", Mark = 65 },
					new Student() { Name = "10", Mark = 78},
					new Student() { Name = "2", Mark = 85 },
					new Student() { Name = "8", Mark = 82 },
					new Student() { Name = "3", Mark = 96 }
				};

			//Act Test

			actual.AddRange(students.PreOrderTraversal());

			//Assert test

			CollectionAssert.AreNotEqual(expected, actual);
		}

		[TestMethod]
		[ExpectedException(typeof(NotImplementedException))]
		public void Catch_Foreach_Exception()
		{
			//Arrange test


			//Act Test

			foreach (var newStudent in students)
			{
				
			}

			//Assert test


		}
	}

	[TestClass]
	public class OtherMethods_Tests
	{
		private BinaryTree<Student> students;

		[TestInitialize]
		public void ClassInitialize()
		{
			students = new BinaryTree<Student>()
			{
			new Student() { Name = "1", Mark = 80 },
			new Student() { Name = "2", Mark = 85 },
			new Student() { Name = "3", Mark = 96 },
			new Student() { Name = "4", Mark = 60 },
			new Student() { Name = "5", Mark = 60 },
			new Student() { Name = "6", Mark = 61 },
			new Student() { Name = "7", Mark = 75 },
			new Student() { Name = "8", Mark = 82 },
			new Student() { Name = "9", Mark = 65 },
			new Student() { Name = "10", Mark = 78 }
			};
		}
		[TestMethod]
		public void Tree_Contain_Student7()
		{
			//Arrange test
			
			bool actual = false;

			//Act test
			actual = students.Contains(new Student() { Name = "7", Mark = 75 });//true


			//Assert test

			Assert.IsTrue(actual);

		}
		[TestMethod]
		public void Tree_Not_Contain_Student()
		{
			//Arrange test

			bool actual = true;

			//Act test
			actual = students.Contains(new Student() { Name = "89", Mark = 89 });//false


			//Assert test

			Assert.IsFalse(actual);

		}
		[TestMethod]
		public void Tree_Deleted_Count_0()
		{
			//Arrange test
			int actualCount;
			int expectedCount = 0;


			//Act test
			students.Clear();
			actualCount = students.Count;

			//Assert test

			Assert.AreEqual(actualCount, expectedCount);

		}
	}
}
