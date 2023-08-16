using System;
using System.Collections;

namespace SummaryLib
{
	public interface ISentenceExtractor
	{
		SentenceCollection parseText(string textToParseValue);
	}
}
