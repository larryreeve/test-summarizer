using System;
using System.Collections;
using System.Collections.Specialized;

namespace SummaryLib
{
    public interface ISummarizer
    {
		StringDictionary Parameters
		{
			get;
		}

        SentenceCollection summarize(SentenceCollection sentences);
    }
}
