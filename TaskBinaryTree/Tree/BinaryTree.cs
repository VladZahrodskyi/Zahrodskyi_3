using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskForBinaryTree.Tree
{
	class BinaryTreeNode<T> : IComparable<T> where T : IComparable<T>
	{
		public BinaryTreeNode(T value)
		{
			Value = value;
		}

		public BinaryTreeNode<T> Left { get; set;}

		public BinaryTreeNode<T> Right { get; set;}

		public T Value { get; private set;}

		public int CompareTo(T other)
		{
			return Value.CompareTo(other);
		}

	}

	public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
	{

		public delegate void MyActionHandler(string action);
		
		public event MyActionHandler AddNode;
		public event MyActionHandler RemoveNode;
		

		private BinaryTreeNode<T> _head;
		
			private int _count;
		#region Adding a new NODE to the Tree

			public void Add(T value)
			{
			//First way: the Tree is empty.

				if (_head == null)
				{
					_head = new BinaryTreeNode<T>(value);
					AddNode?.Invoke("The Head created");
				}
				/*Second way: Tree is not empty, as result we use recursive
				 * algoritm to find the place for adiing a new NODE*/
				else
				{
					AddTo(_head, value);
					AddNode?.Invoke("The Node added");
			}
				_count++;
			}

			// Recursive algoritm.

			private void AddTo(BinaryTreeNode<T> node, T value)
			{
			// The first case: the value of the added node is less than the value of the current one.

			if (value.CompareTo(node.Value) < 0)
				{
				// if the left descendant is missing, add it.          

				if (node.Left == null)
					{
						node.Left = new BinaryTreeNode<T>(value);
					}
					else
					{
					// repeated iteration.              
						AddTo(node.Left, value);
					}
				}
			//The second case: the value of the added node is equal to or greater than the current value.     
			else
			{
					// If there is no right descendant, add it.         

					if (node.Right == null)
					{
						node.Right = new BinaryTreeNode<T>(value);
					}
					else
					{
						// repeated iteration. 

						AddTo(node.Right, value);
					}
				}
			}

		#endregion

		#region Delete NODE of Tree

		public bool Remove(T value)
		{
			BinaryTreeNode<T> current;
			BinaryTreeNode<T> parent;

			// Search the NODE for removal.

			current = FindWithParent(value, out parent);

			if (current == null)
			{
				return false;
			}

			_count--;

			// The first option: the deleted node does not have a right descendant.    

			if (current.Right == null)
			{

				// Remove the root
				if (parent == null)
				{
					_head = current.Left;
					RemoveNode?.Invoke("The head changed");
				}
				else
				{
					int result = parent.CompareTo(current.Value);

					if (result > 0)
					{
						//If the value of the parent node is greater
						//than the value of the node being deleted, 
						//make the left descendant of the current node
						// to the left descendant of the parent node.

						parent.Left = current.Left;
						RemoveNode?.Invoke("make the left descendant of the current node to the left descendant of the parent node");
					}

					else if (result < 0)
					{

						// If the value of the parent node is less than the value
						//of the node being deleted, make the left descendant 
						//of the current node the right descendant of the 
						//parent node.

						parent.Right = current.Left;
						RemoveNode?.Invoke("make the left descendant of the current node to the right descendant of the parent node");

					}
				}
			}
			// The second option: the deleted node has a right descendant, which has no left descendant.
			else if (current.Right.Left == null)
			{
				current.Right.Left = current.Left;

				// Remove the root
				if (parent == null)
				{
					_head = current.Right;
					RemoveNode?.Invoke("The head changed");
				}

				else
				{
					int result = parent.CompareTo(current.Value);
					if (result > 0)
					{
						// If the value of the parent node is greater than the value of the node being deleted -
						// make the right descendant of the current node the left descendant of the parent node.

						parent.Left = current.Right;
						RemoveNode?.Invoke("make the right descendant of the current node the left descendant of the parent node");
					}
					else if (result < 0)
					{
						// If the value of the parent node is less than the value of the node being deleted -
						// make the right descendant of the current node the right descendant of the parent node. 

						parent.Right = current.Right;
						RemoveNode?.Invoke("make the right descendant of the current node the right descendant of the parent node");
					}
				}
			}
			// The third option: the deleted node has a right descendant that has a left descendant.
			else
			{
				BinaryTreeNode<T> leftmostParent = current.Right;
				BinaryTreeNode<T> leftmost = current.Right.Left;
				
				// search for the leftmost descendant
				while (leftmost.Left != null)

				{
					leftmostParent = leftmost;
					leftmost = leftmost.Left;
				}


				// The right subtree of the leftmost node becomes the left subtree of its parent node.        
				leftmostParent.Left = leftmost.Right;
				RemoveNode?.Invoke("The right subtree of the leftmost node becomes the left subtree of its parent node");

				// Assign the leftmost node as the left descendant - the left descendant of the deleted node,
				// and as the right descendant is the right descendant of the node to be deleted. 

				leftmost.Left = current.Left;
				leftmost.Right = current.Right;
				RemoveNode?.Invoke("Assign the leftmost node as the left descendant - the left descendant of the deleted node," +
					"and as the right descendant is the right descendant of the node to be deleted. ");
				if (parent == null)
				{
					_head = leftmost;
					RemoveNode?.Invoke("The head changed");
				}
				else

				{
					int result = parent.CompareTo(current.Value);

					if (result > 0)
					{

						// If the value of the parent node (parent) is greater than the value of the node being deleted (current) -
						// make the leftmost descendant of the deleted node (leftmost) - the left descendant of its parent (parent).

						parent.Left = leftmost;
						RemoveNode?.Invoke("make the leftmost descendant of the deleted node (leftmost) - the left descendant of its parent (parent).");
					}

					else if (result < 0)

					{

						// If the value of the parent node (parent) is less than the value of the node being deleted (current) -
						// make the leftmost descendant of the deleted node (leftmost) - the right descendant of its parent (parent).

						parent.Right = leftmost;
						RemoveNode?.Invoke("make the leftmost descendant of the deleted node(leftmost) -the right descendant of its parent(parent).");
					}
				}
			}

			return true;
		}

		#endregion

		#region Delete the Tree

		public void Clear()
		{
			_head = null;
			_count = 0;
			RemoveNode?.Invoke("Work Clear Method");
		}

		#endregion

		#region Search the NODE into The Tree

		//The Contains method using the FindWithParent search method determines whether the specified value belongs to a tree.

		public bool Contains(T value)
		{

			//BinaryTreeNode<T> parent;
			return FindWithParent(value,  out BinaryTreeNode<T> parent) != null;
		}

		// The FindWithParent method returns the first found node.
		// If no value is found, the method returns null.
		// Also returns the parent node for the found value.

		private BinaryTreeNode<T> FindWithParent(T value, out BinaryTreeNode<T> parent)
		{
			// Search for a value in the tree.     

			BinaryTreeNode<T> current = _head;
			parent = null;

			while (current != null)
			{
				int result = current.CompareTo(value);
				if (result > 0)
				{
					// If the desired value is less than the value of the current node - go to the left descendant.             

					parent = current;
					current = current.Left;
				}
				else if (result < 0)
				{
					// If the desired value is greater than the value of the current node, go to the right descendant.

					parent = current;
					current = current.Right;
				}
				else
				{
					// Search item found.           
					break;
				}
			}
			return current;
		}

		#endregion

		#region Enumerator


		public IEnumerator<T> GetEnumerator()
		{
			throw new NotImplementedException();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return InOrderTraversal().GetEnumerator();
		}


		#endregion

		#region Count NODE in the Tree

		public int Count
			{
				get
				{
					return _count;
				}
			}

		#endregion

		#region Traversals
		public IEnumerable<T> PreOrderTraversal()
		{ 
			// Save NODE into the Tree.

			Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
			BinaryTreeNode<T> current = _head;

			// When moving through the tree, we must track to which of the next node to go: to the left or right descendant.

			bool goLeftNext = true;

			// Start. Putting a tree root into a stack.

			stack.Push(current);
			 // return th Head of Tree.
			yield return current.Value;
		
			while (stack.Count > 0)
			{
				// If we turn left ...
				if (goLeftNext)
				{
					while (current.Left != null)
					{ 
						// Write all the left children to the stack. 
					  //if (current.Left != null)
						stack.Push(current);
						
						current = current.Left;
						// Return of the root left descendant.
						yield return current.Value;
						
					}
				}
				// If he has a right descendant.
				if (current.Right != null)
				{
					// Return of the root right descendant.
					current = current.Right;
					yield return current.Value;
					// If we go to the right once, then false again 
					//to make a passage on the left side.
					goLeftNext = true;
				}
				else
				{
					// If there is no right descendant, we must remove 
					//the parent node from the stack.
					current = stack.Pop();
					goLeftNext = false;
				}
			}
		}
		public IEnumerable<T> InOrderTraversal()
		{


			if (_head != null)
			{
				// Save NODE into the Tree.

				Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
				BinaryTreeNode<T> current = _head;

				// When moving through the tree, we must track to which of the next node to go: to the left or right descendant. 

				bool goLeftNext = true;

				// Start. Putting a tree root into a stack.        

				stack.Push(current);

				while (stack.Count > 0)
				{
					// If we turn left ...      
					if (goLeftNext)
					{
						// Write all the left children to the stack.               

						while (current.Left != null)
						{
							stack.Push(current);
							current = current.Left;
						}
					}

					// Return of the leftmost descendant.

					yield return current.Value;

					// If he has a right descendant.

					if (current.Right != null)
					{
						current = current.Right;

						// If we go to the right once, then false again to make a passage on the left side.
						goLeftNext = true;
					}
					else
					{
						// If there is no right descendant, we must remove the parent node from the stack.

						current = stack.Pop();
						goLeftNext = false;
					}
				}
			}
		}
		#endregion



	}
}

