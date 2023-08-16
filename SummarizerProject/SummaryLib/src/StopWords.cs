using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;

namespace SummaryLib
{
	public class StopWords
	{
		private const string STOPWORDS_FILENAME = @"data\StopWordList.txt";
		private static StringDictionary m_stopwords = new StringDictionary();

		static StopWords()
		{
			m_stopwords.Clear();

			if (File.Exists(STOPWORDS_FILENAME)) 
			{
				StreamReader rdr = File.OpenText(STOPWORDS_FILENAME);
				string word = null;
				while ((word = rdr.ReadLine()) != null)
				{
					string wordNormalized = word.Trim().ToLower();

					if (!m_stopwords.ContainsKey(wordNormalized))
						m_stopwords.Add(wordNormalized, null);
				}

				rdr.Close();
			}
			else
			{
				m_stopwords.Add("a", null);
				m_stopwords.Add("about", null);
				m_stopwords.Add("after", null);
				m_stopwords.Add("also", null);
				m_stopwords.Add("an", null);
				m_stopwords.Add("and", null);
				m_stopwords.Add("as", null);
				m_stopwords.Add("at", null);
				m_stopwords.Add("be", null);
				m_stopwords.Add("by", null);
				m_stopwords.Add("can", null);
				m_stopwords.Add("for", null);
				m_stopwords.Add("from", null);
				m_stopwords.Add("have", null);
				m_stopwords.Add("he", null);
				m_stopwords.Add("how", null);
				m_stopwords.Add("i", null);
				m_stopwords.Add("in", null);
				m_stopwords.Add("is", null);
				m_stopwords.Add("it", null);
				m_stopwords.Add("not", null);
				m_stopwords.Add("of", null);
				m_stopwords.Add("on", null);
				m_stopwords.Add("or", null);
				m_stopwords.Add("said", null);
				m_stopwords.Add("she", null);
				m_stopwords.Add("that", null);
				m_stopwords.Add("the", null);
				m_stopwords.Add("this", null);
				m_stopwords.Add("to", null);
				m_stopwords.Add("was", null);
				m_stopwords.Add("we", null);
				m_stopwords.Add("what", null);
				m_stopwords.Add("when", null);
				m_stopwords.Add("where", null);
				m_stopwords.Add("who", null);
				m_stopwords.Add("will", null);
				m_stopwords.Add("with", null);
			}
		}

		public static bool IsStopWord(string word)
		{
			string wordNormalized = word.Trim().ToLower();

			return m_stopwords.ContainsKey(wordNormalized);
		}
	}
}
