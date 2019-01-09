using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForBinaryTree.Helper
{
	public class Student: IComparable<Student>
	{
		public string Name { get; set; }
		public string TestName { get; set; }
		public DateTime TestData { get; set; }
		public double Mark { get; set; }

		public int CompareTo<T>(T instanse)
		{
			Student student = instanse as Student;
			if (student != null)
			{
				return this.Mark.CompareTo(student.Mark);
			}
			else
			{
				throw new NotSupportedException();
			}
		}

		public int CompareTo(Student other)
		{
			if (other != null)
			{
				return this.Mark.CompareTo(other.Mark);
			}
			else
			{
				throw new NullReferenceException();
			}
		}
		public override string ToString()
		{
			return Name+"\t"+Mark.ToString()+ "\t" + TestName+ "\t" + TestData.ToString();
		}
		public override bool Equals(object ob)
		{
			Student student = (Student)ob;
			if (student != null)
			{
				if (this.Mark==student.Mark&&this.Name==student.Name
					&&this.TestData==student.TestData&&this.TestName==student.TestName)
				{
					return true;
				}
			}
			return false;
			
		}
	}
}
