using System;
using System.Collections;
using System.Collections.Specialized;

namespace SummaryLib
{
    public class Sentence
    {
        private int					positionValue = 0;
		private double				scoreValue = 0.0;
		private int					segmentValue = 0;
        private string				textValue = null;
        private StringCollection	tokensValue = null;

		public class SentenceComparerByScore : IComparer
		{
			public int Compare (object x, object y) 
			{ 
				Sentence x1 = (Sentence) x;
				Sentence y1 = (Sentence) y;

				int xScore = (int) x1.score;
				int yScore = (int) y1.score;

				return (-1) * (xScore - yScore);
			} 
		}

		public class SentenceComparerByPosition : IComparer
		{
			public int Compare (object x, object y) 
			{ 
				Sentence x1 = (Sentence) x;
				Sentence y1 = (Sentence) y;

				int xPosition = (int) x1.position;
				int yPosition = (int) y1.position;

				return (xPosition - yPosition);
			} 
		}
		
		public Sentence() : this (0, 0, null, null)
        {
        }

        public Sentence(int		sentenceSegment,
						int     sentencePosition, 
                        string  sentenceText, 
                        StringCollection sentenceTokens)
        {
			this.positionValue = sentencePosition;
			this.scoreValue = 0.0;
			this.segmentValue = sentenceSegment;
            this.textValue = sentenceText;
            
            if (sentenceTokens != null)
            {
                this.tokensValue = new StringCollection();

				foreach (string token in sentenceTokens)
					this.tokensValue.Add(token);
            }
        }

        public int position
        {
            get { return this.positionValue; }
        }

		public double score
		{
			get { return this.scoreValue; }
			set { this.scoreValue = value; }
		}

		public int segment
		{
			get { return this.segment; }
		}

        public string text
        {
            get { return this.textValue; }
        }

        public StringCollection tokens
        {
            get { return this.tokensValue; }
        }
    }
}
