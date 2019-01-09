using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TaskUserArray.Exceptions;

namespace TaskUserArray.Library
{
	public class UserArray<T> : IEnumerable<T>
	{
		T[] _ArrayIndecesAboveZero;//Array for saving elements with positive index
		T[] _ArrayIndecesLessZero;//Array for saving elements with negative index

		// Count the elements in the array
		private int _countIdecesAboveZerro = 0;
		private int _countIdecesLessZerro = 0;
		public int CountIdecesAboveZero
		{
			get { return _countIdecesAboveZerro; }
			protected set
			{
				if (value >= 0)
					_countIdecesAboveZerro = value;
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		public int CountIdecesLessZero
		{
			get { return _countIdecesLessZerro; }
			protected set
			{
				if (value >= 0)
					_countIdecesLessZerro = value;
				else
				{
					throw new ArgumentOutOfRangeException();
				}
			}
		}
		public int Count
		{
			get { return CountIdecesAboveZero + CountIdecesLessZero; }
		}
		//Tells about nature of Indeces.
		private bool _hasIndecesLessZero;	
		public bool HasIndecesLessZero
		{
			get
			{
				return _hasIndecesLessZero;
			}
			protected set
			{
				if (value == true&&_ArrayIndecesLessZero==null)
				{
					_ArrayIndecesLessZero = new T[0];
					
				}
				_hasIndecesLessZero = value;
			}
		}

		#region Consrtuctors
		// Default constructor.
		public UserArray() : this(0,-1)
		{

		}

		// Constructor with parameter.
		public UserArray(int length)
		{
			if (length < 0)
			{
				Initialize(0, (uint)(-length), true);
			}
			else
			{
				Initialize( (uint)length, 0, false);
			}
		}
		// Constructor with parameter.
		public UserArray(uint amountElmentsForArray, bool IsIndecesLessZero)
		{
			if (IsIndecesLessZero == true)
			{
				Initialize(0, (uint)amountElmentsForArray, IsIndecesLessZero);
			}
			else
			{
				Initialize((uint)(amountElmentsForArray), 0 , IsIndecesLessZero);
			}
			HasIndecesLessZero = IsIndecesLessZero;
		}

		// Constructor with parameter. Uint for first parametr for safety
		public UserArray(uint amountElmentsAboveZero, int amountElmentsLessZero)//Or make both parameters uint Type and Add Bool parametr?(not approved way)
		{
			if (amountElmentsLessZero < 0 && amountElmentsAboveZero <= MaxValue)
			{
				Initialize(amountElmentsAboveZero, (uint)-amountElmentsLessZero, true);
			}
			else if ((amountElmentsLessZero >= 0 && amountElmentsAboveZero <= MaxValue))
			{
				Initialize(amountElmentsAboveZero, (uint)amountElmentsLessZero, true);
			}
			else
			{
				throw new InitializeArgumentsException("You initialize your array in not allowed way, read documentation");
			}
		}
		
		// Constructor with parameter.
		public UserArray(ICollection<T> list) : this(list, false)	{ }
		// Constructor with parameter.
		public UserArray(ICollection<T> list, bool IsIndecesLessZero)
		{
			//int index = 0;
			HasIndecesLessZero = IsIndecesLessZero;
			if (IsIndecesLessZero == true)
			{
				if (ConvertArrayIndexToNegativeIndex(list.Count) >= MinValue)
				{
					_ArrayIndecesLessZero = new T[list.Count];
					SetElementsFromCollection(ref _ArrayIndecesLessZero, list);
					CountIdecesLessZero = list.Count();
					//LengthLessZero = (uint)list.Count();
				}
				else
				{
					throw new IndexOutOfRangeException("You have tried to add massive that have more elements than allowed to put");
				}
			}
			else
			{
				if (list.Count <= MaxValue)
				{
					_ArrayIndecesAboveZero = new T[list.Count];
					SetElementsFromCollection(ref _ArrayIndecesAboveZero, list);
					CountIdecesAboveZero = list.Count();
					
				}
				else
				{
					throw new IndexOutOfRangeException("You have tried to add massive that have more elements than allowed to put");
				}
			}
			
			
		}
		#endregion

		private void SetElementsFromCollection(ref T[] _array, ICollection<T> _list)
		{
			int index = 0;

			foreach (var element in _list)
			{
				_array[index++] = element;

			}
		}

		//Normilize Index for working with _ArrayIndecesLessZero as a usual (not negative) Array.
		private int ConvertNegativeIndexToArrayIndex(int _negIndex)
		{
			if (_negIndex < 0)
				return (-_negIndex) - 1;
			else
				throw new ConvertableArgumentException();
		}

		//Normilize Index to working with _ArrayIndecesLessZero as a negative Array.
		private int ConvertArrayIndexToNegativeIndex(int _positiveIndex)
		{
			if (_positiveIndex >= 0)
				return (-_positiveIndex) - 1;
			else
				throw new ConvertableArgumentException();
		}

		// The private method is called from constructor to create the instance.
		private void Initialize(uint _amountElmentsAboveZero, uint _amountElmentsLessZero, bool __hasIndecesLessZero )
		{
			
			if (_amountElmentsAboveZero <= MaxValue && _amountElmentsLessZero >= MinValue)//we can use the array index only between 2147483647 to -2147483648.
			{
				if (__hasIndecesLessZero == true)
				{
					_ArrayIndecesLessZero = new T[_amountElmentsLessZero];
					CountIdecesLessZero = (int)_amountElmentsLessZero;
				}
				else
				{
					if (_amountElmentsLessZero > 0)
					{
						throw new InitializeArgumentsException("You tried enter a value to not allowed thing," +
							" Use the third parametr true, if you want" +
							"to initialize a negative array");
					}
				}
				_ArrayIndecesAboveZero = new T[_amountElmentsAboveZero];
				CountIdecesAboveZero = (int)_amountElmentsAboveZero;
				HasIndecesLessZero = __hasIndecesLessZero;
				
			}
			else
			{
				throw new ArgumentOutOfRangeException("You tried initialize a lenth out of range");
			}
		}
		public T this[int index]
		{
			get
			{
				if (index < 0)
				{
					//index = (-index) - 1;
					index = ConvertNegativeIndexToArrayIndex(index);//Call normilises method to prepare to get element by index from ArrayIndecesLessZero.

					if (index<=CountIdecesLessZero)//Is not allowed access to not initialize part, cause it is default. We have auto-expznding array.
					{
						
						return _ArrayIndecesLessZero[index];
					}
					throw new IndexOutOfRangeException("You have tried to have access to non-existing element");
				}
				else
				{
					if (index <= CountIdecesAboveZero)//Is not allowed access to not initialize part, cause it is default. We have auto-expznding array.
					{
						return _ArrayIndecesAboveZero[index];
					}
					else
					{
						throw new IndexOutOfRangeException("You have tried to have access to non-existing element");
					}
				}
			}
			set
			{
				if (index < 0)
				{
					//index = (-index) - 1;
					index = ConvertNegativeIndexToArrayIndex(index);//Call normilises method to prepare to set element by index from ArrayIndecesLessZero.
					if (index < CountIdecesLessZero)
					{
						_ArrayIndecesLessZero[index] = value;
					}
					else
					{
						throw new IndexOutOfRangeException("You have tried to set a value to non-existing element, if you want" +
							"you can add element by using Add method");
					}
				}
				else if(index>=0)
				{
					if (index < CountIdecesAboveZero)
					{
						_ArrayIndecesAboveZero[index] = value;
					}
					else
					{
						throw new IndexOutOfRangeException("You have tried to set a value to non-existing element, if you want" +
							"you can add element by using Add method");
					}
				}
			}
		}

		// Calculate the size of the array.
		public int SizeArrayAboveZero
		{
			get { return _ArrayIndecesAboveZero.Length; }
			//internal set;
		}
		public int SizeArrayLessZero
		{
			get { return ConvertArrayIndexToNegativeIndex(_ArrayIndecesLessZero.Length); }//return the size.
			//internal set;
		}
		public int Size
		{
			get { return _ArrayIndecesAboveZero.Length + _ArrayIndecesLessZero.Length; }
		}
		public int MaxValue
		{
			get
			{
				return Int32.MaxValue;
			}
		}
		public int MinValue
		{
			get
			{
				return Int32.MinValue;
			}
		}

		// The method adds a new element to the end of the positive array.
		public void Add(T element) 
		{
			Add(element, false);
		}

		// The method adds a new element to the end of the selected array.
		public void Add(T element, bool _toArrayWithNegativeIndex)
		{
			if (_toArrayWithNegativeIndex == true)
			{
				{
					if (_ArrayIndecesLessZero.Length == CountIdecesLessZero)
					{
						GrowArraySize(_toArrayWithNegativeIndex);
					}

					_ArrayIndecesLessZero[CountIdecesLessZero++] = element;
				}
			}
			else
			{
				{
					if (_ArrayIndecesAboveZero.Length == CountIdecesAboveZero)
					{
						GrowArraySize(_toArrayWithNegativeIndex);
					}

					_ArrayIndecesAboveZero[CountIdecesAboveZero++] = element;
				}
			}
		}

		// Expand Array
		private void GrowArraySize(bool _whereIdecesLessZero)
		{
			if (_whereIdecesLessZero == true)
			{
				int newLength = _ArrayIndecesLessZero.Length == 0 ? 4 : _ArrayIndecesLessZero.Length << 1; // 0000 0100 => 0000 1000
				T[] newArray = new T[newLength];
				_ArrayIndecesLessZero.CopyTo(newArray, 0);
				_ArrayIndecesLessZero = newArray;
			}
			else
			{
				int newLength = _ArrayIndecesAboveZero.Length == 0 ? 4 : _ArrayIndecesAboveZero.Length << 1; // 0000 0100 => 0000 1000
				T[] newArray = new T[newLength];
				_ArrayIndecesAboveZero.CopyTo(newArray, 0);
				_ArrayIndecesAboveZero = newArray;
			}
		}
		// Decrease array
		private void CutArraySize(bool _whereIdecesLessZero)
		{
			if (_whereIdecesLessZero == true)
			{
				int newLength = _ArrayIndecesLessZero.Length >> 1;   //  0000 1000 => 0000 0100
				T[] newArray = new T[newLength];
				_ArrayIndecesLessZero.CopyTo(newArray, 0);
				_ArrayIndecesLessZero = newArray;
			}
			else
			{
				int newLength = _ArrayIndecesAboveZero.Length >> 1;  //  0000 1000 => 0000 0100
				T[] newArray = new T[newLength];
				_ArrayIndecesAboveZero.CopyTo(newArray, 0);
				_ArrayIndecesAboveZero = newArray;
			}
		}
		
		public void Insert(int index, T element)
		{
			if (index < 0)
			{
				if (_ArrayIndecesLessZero != null)
				{
					int _newIndex = ConvertNegativeIndexToArrayIndex(index); //_newIndex = (-index)-1
					if (_newIndex >= CountIdecesLessZero)
					{
						throw new IndexOutOfRangeException();
					}

					// Expand the array.
					if (_ArrayIndecesLessZero.Length == CountIdecesLessZero)
					{
						GrowArraySize(true);
					}

					// Shift all elements, after inserting an element, to the right.
					Array.Copy(_ArrayIndecesLessZero, _newIndex, _ArrayIndecesLessZero, _newIndex + 1, CountIdecesLessZero - _newIndex);

					_ArrayIndecesLessZero[_newIndex] = element;
					CountIdecesLessZero++;
				}
				else
				{
					throw new NotInitializedArrayException("Initialize the Negative part of Array for using");
				}
			}
			else
			{
				if (_ArrayIndecesAboveZero != null)
				{
					if (index > CountIdecesAboveZero)
					{
						throw new IndexOutOfRangeException();
					}

					// Expand the array.
					if (_ArrayIndecesAboveZero.Length == CountIdecesAboveZero)
					{
						GrowArraySize(false);
					}

					// Shift all elements, after inserting an element, to the right.
					Array.Copy(_ArrayIndecesAboveZero, index, _ArrayIndecesAboveZero, index + 1, CountIdecesAboveZero - index);

					_ArrayIndecesAboveZero[index] = element;
					CountIdecesAboveZero++;
				}
				else
				{
					throw new NotInitializedArrayException("Initialize the Positive part of Array for using");
				}
			}
		}
		public void RemoveAt(int index)
		{
			if (index < 0)
			{
				int _newIndex;
				//_newIndex= (-index) - 1;
				_newIndex = ConvertNegativeIndexToArrayIndex(index);
				if (_newIndex > CountIdecesLessZero)
				{
					throw new IndexOutOfRangeException();
				}

				//The first element in array which will be relocated to possition where now is index.
				int shiftStart = _newIndex + 1;

				// if not the last element of the array is deleted.  
				if (shiftStart < CountIdecesLessZero) 
				{
					// Array shift one element to the left.                                  
					Array.Copy(_ArrayIndecesLessZero, shiftStart, _ArrayIndecesLessZero, _newIndex, CountIdecesLessZero - shiftStart);
					//Array.Clear(_ArrayLessZero, shiftStart, 1);
				}
				CountIdecesLessZero--;
				if (((SizeArrayLessZero>>1)-CountIdecesLessZero)>=1)
				{
					CutArraySize(true);
				}

			}
			else
			{
				if (index >= CountIdecesAboveZero)
				{
					throw new IndexOutOfRangeException();
				}

				//The first element in array which will be relocated to possition where now is index.
				int shiftStart = index + 1;

				// if not the last element of the array is deleted.
				if (shiftStart < Count)   
				{
					// Array shift one element to the left.                                      
					Array.Copy(_ArrayIndecesAboveZero, shiftStart, _ArrayIndecesAboveZero, index, CountIdecesAboveZero - shiftStart);
				}
				CountIdecesAboveZero--;
				if (((SizeArrayAboveZero >> 1) - CountIdecesAboveZero) >= 1)
				{
					CutArraySize(false);
				}
			}
		}

		// Delete only one first specified element
		public bool Remove(T element)
		{
			return Remove(element, false);
			
		}

		// Delete only one first specified element if _deleteAll = false.
		public bool Remove(T item, bool _deleteAll)												 
		{
			if (HasIndecesLessZero == true)
			{
				if (_ArrayIndecesLessZero != null)
				{
					for (int i = 0; i < CountIdecesLessZero; i++)
					{
						// Delete only one firs element which is Equal to the Item was recieved.
						if (_ArrayIndecesLessZero[i].Equals(item))
						{
							RemoveAt(ConvertArrayIndexToNegativeIndex(i));
							//Delete only one firs element which is Equal to the specified element was recieved.
							if (_deleteAll == false)
							{
								return true;
							}
						}
					}
				}
			}
			if (_ArrayIndecesAboveZero != null)
			{
				for (int i = CountIdecesAboveZero - 1; i >= 0; i--)
				{
					// Delete only one firs element which is Equal to the Item was recieved.
					if (_ArrayIndecesAboveZero[i].Equals(item))
					{
						RemoveAt(i);
						//Delete only one firs element which is Equal to the specified element was recieved.
						if (_deleteAll == false)
						{
							return true;
						}
					}
				}
			}
			return true;
		}

		//Inner Search.
		public int IndexOf(T element)
		{
			//We use ref parametr because Array contain an negative indeces and we have to know it is the index of element in the array or it is only -1 meaning "Not Found".
			bool hasItValueItem = false;
			int indexOfElement = IndexOf(element, ref hasItValueItem);
			if (hasItValueItem == true)
			{
				return indexOfElement;
			}
			else
			{
				throw new IndexIsNotFoundException("Index is not found");
			}
		}

		//Inner Search.
		private int IndexOf(T element, ref bool _isFromArray)
		{
			if (_ArrayIndecesLessZero != null)
			{
				for (int i = CountIdecesLessZero - 1; i >= 0; i--)
				{
					if (_ArrayIndecesLessZero[i].Equals(element))
					{
						// Tells us that we have returned -1 as index of Array.
						_isFromArray = true; 
						//return an index in Array.
						return ConvertArrayIndexToNegativeIndex(i);
						
					}
				}
			}
			if (_ArrayIndecesAboveZero != null)
			{
				for (int i = 0; i < CountIdecesAboveZero; i++)
				{
					if (_ArrayIndecesAboveZero[i].Equals(element))
					{
						return i;
					}
				}
			}
			//_isFromArray == false, The element was not found
			return -1;
		}

		// The method determines the belonging of the element to the array
		public bool Contains(T item)
		{
			//We use ref parametr because Array contain an negative indeces and we have to know it is the index of element in the array or it is only -1 meaning "Not Found".
			bool hasItValueItem = false;
			int indexOfItem = IndexOf(item, ref hasItValueItem);
			if (hasItValueItem == false && indexOfItem==-1)
			{
				return hasItValueItem;
			}
			else
			{
				return !hasItValueItem;
			}
		}

		// The method returns an Enumerator, iterates over the collection.
		public System.Collections.Generic.IEnumerator<T> GetEnumerator()
		{
			if (_ArrayIndecesLessZero != null)
			{
				for (int i = CountIdecesLessZero-1; i >=0 ; i--)
				{
					yield return _ArrayIndecesLessZero[i];
				}
				

			}
			if (_ArrayIndecesAboveZero != null)
			{
				for (int i =  0; i < CountIdecesAboveZero; i++)
				{
					yield return _ArrayIndecesAboveZero[i];

				}
			}
		}
		// The method returns an Enumerator, iterates over the collection.
		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}
