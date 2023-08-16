using System;
using System.Collections;
using System.Collections.Specialized;

namespace SummaryLib
{
    public class SummarizerTermFrequency : ISummarizer
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

            // Score each sentence according to term frequency
            foreach (Sentence sentenceEntry in sentencesCopy)
            {
                foreach (string token in sentenceEntry.tokens)
                {
                    string tokenNormalized = token.ToLower();

					if (frequencyTable.Contains(tokenNormalized))
					{
						sentenceEntry.score += (int) frequencyTable[tokenNormalized];
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
