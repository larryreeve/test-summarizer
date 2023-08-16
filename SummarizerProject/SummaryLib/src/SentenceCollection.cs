using System;
using System.Collections;

namespace SummaryLib
{
	public class SentenceCollection : CollectionBase  
	{
		public Sentence this[int index]  
		{
			get { return((Sentence) List[index]); }
			set {List[index] = value; }
		}

		public int Add(Sentence value)  
		{
			return List.Add(value);
		}

		public int IndexOf(Sentence value)  
		{
			return List.IndexOf(value);
		}

		public void Insert(int index, Sentence value)
		{
			List.Insert(index, value);
		}

		public void Sort(IComparer comparer)
		{
			base.InnerList.Sort(comparer);
		}
	}
}