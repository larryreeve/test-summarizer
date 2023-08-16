using System;
using System.Collections;
using System.Collections.Specialized;

namespace SummaryLib
{
	public class SummarizerLuhn : ISummarizer
	{
		private StringDictionary parametersValue = new StringDictionary();

		private class FrequencyComparer : IComparer
		{
			public int Compare (object x, object y) 
			{ 
				DictionaryEntry x1 = (DictionaryEntry) x;
				DictionaryEntry y1 = (DictionaryEntry) y;

				int xFrequency = (int) x1.Value;
				int yFrequency = (int) y1.Value;

				return (-1) * (xFrequency - yFrequency);
			} 
		}


		public StringDictionary Parameters
		{
			get { return this.parametersValue; }
		}

		public SentenceCollection summarize(SentenceCollection sentences)
		{
			SentenceCollection sentencesCopy = new SentenceCollection();
			SentenceCollection extractedSentences = new SentenceCollection();
			Hashtable frequencyTable = new Hashtable();

			if (sentences == null)
				return extractedSentences;

			// Make copy of sentences list
			foreach (Sentence sentenceEntry in sentences)
				sentencesCopy.Add(sentenceEntry);

			// Get term frequency list
			foreach (Sentence sentenceEntry in sentencesCopy)
			{
				foreach (string token in sentenceEntry.tokens)
				{
					string tokenNormalized = token.ToLower();

					if (tokenNormalized.Length > 0)
					{
						int punctPos = tokenNormalized.IndexOfAny(new char[] {'.', '!', '?', '"', '\'', ';', ',', '(', ')'});

						if (punctPos < 0 && !StopWords.IsStopWord(tokenNormalized))
						{
							if (frequencyTable.Contains(tokenNormalized))
							{
								int frequency = (int) frequencyTable[tokenNormalized];
								frequency++;
								frequencyTable[tokenNormalized] = frequency;
							}
							else
							{
								frequencyTable.Add(tokenNormalized, 1);
							}
						}
					}
				}
			}

			// Consolidate words with similar stem
			//	Sort words alpabetically
			ArrayList sortedWords = new ArrayList(frequencyTable.Keys);
			sortedWords.Sort();

			//	Find stems
			Hashtable stems = new Hashtable();
//			IStemmer stemmer = new LovinsStemmer();
			for (int sortedWordIdx=0; sortedWordIdx < sortedWords.Count-1; sortedWordIdx++)
			{
//				string word = (string) sortedWords[sortedWordIdx];
//				string lastStemword = null;
//				string stem = null;
//				for (stem = stemmer.stemTerm(word);
//					 stem != lastStemword;
//					 )
//				{
//					lastStemword = stem;
//					stem = stemmer.stemTerm(stem);
//				}
//
//				if (!stems.ContainsKey(stem))
//				{
//					Hashtable words = new Hashtable();
//
//					if (!words.ContainsKey(word))
//						words.Add(word, (int) frequencyTable[word]);
//					stems.Add(stem, words);
//				}
//				else
//				{
//					Hashtable words = (Hashtable) stems[stem]; 
//							
//					if (!words.ContainsKey(word))
//						words.Add(word, (int) frequencyTable[word]);
//				}

					 
				string word1 = (string) sortedWords[sortedWordIdx];
				string word2 = (string) sortedWords[sortedWordIdx+1];

				int matchLen = 0;
				while (matchLen < word1.Length &&
					   matchLen < word2.Length &&
					   word1[matchLen] == word2[matchLen])
				{
					matchLen++;
				}

				if (matchLen > 1)
				{
					int diffLen = (word1.Length - matchLen) + (word2.Length - matchLen);

					if (diffLen <= 6)
					{
						string stem = word1.Substring(0, matchLen);

						if (!stems.ContainsKey(stem))
						{
							Hashtable words = new Hashtable();

							if (!words.ContainsKey(word1))
								words.Add(word1, (int) frequencyTable[word1]);
							if (!words.ContainsKey(word2))
								words.Add(word2, (int) frequencyTable[word2]);
							stems.Add(stem, words);
						}
						else
						{
							Hashtable words = (Hashtable) stems[stem]; 
							
							if (!words.ContainsKey(word1))
								words.Add(word1, (int) frequencyTable[word1]);
							if (!words.ContainsKey(word2))
								words.Add(word2, (int) frequencyTable[word2]);
						}
					}
				}
			}

			//	Find frequency counts of stems
			foreach (string stem in stems.Keys)
			{
				// Get frequency count of all words in stem
				int stemFreqCount = 0;
				Hashtable words = (Hashtable) stems[stem];
				foreach (string word in words.Keys)
				{
					int freqCount = (int) words[word];
					stemFreqCount += (int) words[word];
				}


				// Update frequency count table with 
				//	all words from stem with stem frequency count
				words = (Hashtable) stems[stem];
				foreach (string word in words.Keys)
				{
					frequencyTable[word] = stemFreqCount;
				}
			}


			//	Determine significant words
			//		Calculate average frequency
			double totalFrequency = 0;
			foreach (string word in frequencyTable.Keys)
			{
			    totalFrequency += (int) frequencyTable[word];
			}
			double avgFrequencyCount = (totalFrequency / frequencyTable.Count);

			// Calculate std dev
			double totalVariance = 0;
			foreach (string word in frequencyTable.Keys)
			{
			    totalVariance += Math.Pow(((int) frequencyTable[word]) - avgFrequencyCount, 2); 
			}
	
			double stdDev = Math.Sqrt(totalVariance / frequencyTable.Count);
	
			// Get most frequent terms
			Hashtable significantTermsTable = new Hashtable();
			int frequencyMinimum = (int) (avgFrequencyCount + (2 * stdDev));
			//int frequencyMinimum = 4;
			foreach (string word in frequencyTable.Keys)
			{
			    if (((int) frequencyTable[word]) >= frequencyMinimum)
			        significantTermsTable.Add(word, null);
			}


			//	Determine signficance factor for each sentence
			foreach (Sentence sentenceEntry in sentencesCopy)
			{
				// Find position of all significant words in sentence
				ArrayList significantClusters = new ArrayList();
				ArrayList currentCluster = new ArrayList();
				int curPos = 1;
				foreach (string token in sentenceEntry.tokens)
				{
					string tokenNormalized = token.ToLower();

					if (significantTermsTable.ContainsKey(tokenNormalized))
					{
						if (currentCluster.Count > 0)
						{
							if ((curPos - (int) currentCluster[0]) > 5)
							{
								if (currentCluster.Count > 1)
									significantClusters.Add(currentCluster);
								currentCluster = new ArrayList();
							}
						}

						currentCluster.Add(curPos);
					}

					curPos++;
				}
				if (currentCluster.Count > 1)
					significantClusters.Add(currentCluster);

				// 
				if (significantClusters.Count == 0)
				{
					sentenceEntry.score = 0;
				}
				else if (significantClusters.Count == 1)
				{
					ArrayList cluster = (ArrayList) significantClusters[0];

					int totalBracketedWords = (((int) cluster[cluster.Count-1]) - ((int) cluster[0])) + 1;
					sentenceEntry.score = Math.Pow(cluster.Count, 2) / totalBracketedWords;
				}
				else
				{
					// Find highest score among multiple clusters
					for (int idx=0; idx < significantClusters.Count; idx++)
					{
						ArrayList cluster = (ArrayList) significantClusters[idx];

						int totalBracketedWords = (((int) cluster[cluster.Count-1]) - ((int) cluster[0])) + 1;
						double score = Math.Pow(cluster.Count, 2) / totalBracketedWords;

						if (score > sentenceEntry.score)
							sentenceEntry.score = score;
					}
				}
			}

			// Sort sentences based on score
			sentencesCopy.Sort(new Sentence.SentenceComparerByScore());
            
			//	Get compression rate
			int compressionRate = 10;
			if (this.parametersValue.ContainsKey("compressionRate"))
			{
				compressionRate = Int32.Parse(this.parametersValue["compressionRate"]);
				if (compressionRate < 1 || compressionRate > 100)
					compressionRate  = 10;
			}

			//	Get # of sentences to extract
			int totalSentencesToExtract = (int) Math.Ceiling(sentencesCopy.Count * (compressionRate / 100.0) + 0.5);

			// Extract sentences
			Sentence[] extractedList = new Sentence[totalSentencesToExtract];
			for (int idx=0; idx < totalSentencesToExtract; idx++)
			{
				extractedSentences.Add(sentencesCopy[idx]);
			}

			// Sort extracted sentences for presentation
			string displayOrderValue = this.parametersValue["displayOrder"];
			if (displayOrderValue!= null && !displayOrderValue.Equals("topScoring"))
				extractedSentences.Sort(new Sentence.SentenceComparerByPosition());

			return extractedSentences;
		}
	}
}
