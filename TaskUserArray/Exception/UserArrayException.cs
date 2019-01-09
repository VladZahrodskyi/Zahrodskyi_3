using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskUserArray.Exceptions
{
		public class InitializeArgumentsException : ApplicationException
		{
			public InitializeArgumentsException() : base()
			{ }

			public InitializeArgumentsException(string message) : base(message)
			{ }

			public InitializeArgumentsException(string message, Exception innerException) : base(message, innerException)
			{ }

		}
		public class ConvertableArgumentException : ApplicationException
		{
			public ConvertableArgumentException() : base()
			{ }

			public ConvertableArgumentException(string message) : base(message)
			{ }

			public ConvertableArgumentException(string message, Exception innerException) : base(message, innerException)
			{ }

		}
		public class NotInitializedArrayException : ApplicationException
		{
			public NotInitializedArrayException() : base()
			{ }

			public NotInitializedArrayException(string message) : base(message)
			{ }

			public NotInitializedArrayException(string message, Exception innerException) : base(message, innerException)
			{ }

		}
		public class RemoveElementsException : ApplicationException
		{
			public RemoveElementsException() : base()
			{ }

			public RemoveElementsException(string message) : base(message)
			{ }

			public RemoveElementsException(string message, Exception innerException) : base(message, innerException)
			{ }

		}
		public class IndexIsNotFoundException : ApplicationException
		{
			public IndexIsNotFoundException() : base()
			{ }

			public IndexIsNotFoundException(string message) : base(message)
			{ }

			public IndexIsNotFoundException(string message, Exception innerException) : base(message, innerException)
			{ }

		}
}

