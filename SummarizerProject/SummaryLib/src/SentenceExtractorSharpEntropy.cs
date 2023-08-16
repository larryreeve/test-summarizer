using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;
using EnglishTokenizer;

namespace SummaryLib
{
	public class SentenceExtractorSharpEntropy : ISentenceExtractor
	{
		public SentenceCollection parseText(string textToParseValue)
		{
			SentenceCollection sentencesList = new SentenceCollection();
            int position = 0;
			int segment = 0;
            string lastToken = "";

			StringBuilder newSentence = new StringBuilder();
            MaxentTokenizer tokenizer = new MaxentTokenizer(@"data\EnglishTok.nbin");
            StringCollection tokenList = new StringCollection();

            string [] tokens = tokenizer.Tokenize(textToParseValue);

			int tokenIdx = 0;
			while (tokenIdx < tokens.Length)
            {
				if (tokens[tokenIdx].Length == 0)
				{ 
					if (tokenList.Count > 0)
					{
						sentencesList.Add(new Sentence(segment, position, newSentence.ToString(), tokenList));
						newSentence.Length = 0;
						tokenList.Clear();
						position++;
					}

					segment++;

					while ((tokenIdx < tokens.Length) && (tokens[tokenIdx].Length == 0))
						tokenIdx++;
				}

				if (tokenIdx >= tokens.Length)
					break;

				string currentToken = tokens[tokenIdx];
				tokenIdx++;

				int eosPos = currentToken.IndexOfAny(new char[] {'.', '!', '?'});
				int punctPos = currentToken.IndexOfAny(new char[] {',',';',':','"', '\''});

				// See if end-of-sentence char is mixed with other text
                if (eosPos >= 0)
                {
                    if (currentToken.Length > 1)
                    {
                        char punctChar = currentToken[eosPos];

                        if (eosPos == 0)
                        {
							lastToken = punctChar.ToString();
                            tokenList.Add(punctChar.ToString());
                            newSentence.Append(punctChar.ToString());

                            newSentence.Append(" ");

                            currentToken = currentToken.Remove(eosPos,1);

							lastToken = currentToken;
                            tokenList.Add(currentToken);
                            newSentence.Append(currentToken);
                        }
                        else if (eosPos == (currentToken.Length-1))
                        {
							if (newSentence.Length > 0)
								newSentence.Append(" ");

                            currentToken = currentToken.Remove(eosPos,1);
							lastToken = currentToken;
                            tokenList.Add(currentToken);
                            newSentence.Append(currentToken);

							lastToken = punctChar.ToString();
                            tokenList.Add(punctChar.ToString());
                            newSentence.Append(punctChar.ToString());
                        }
                        else
                        {
//                            char[] delimiters = new char[1];
//                            delimiters[0] = punctChar;
//                            string[] twoTokens = currentToken.Split(delimiters);

							// Look for URL query string
							if (punctChar == '?' && 
								(lastToken.ToLower().StartsWith("www") ||
								 lastToken.ToLower().StartsWith("http")))
							{
								// don't treat ? as end of sentence
							}
							else
							{
								lastToken = currentToken;
								tokenList.Add(currentToken);
								if (newSentence.Length > 0)
									newSentence.Append(" ");
						
								newSentence.Append(currentToken);
							}
//
//                            tokenList.Add(twoTokens[0]);
//                            newSentence.Append(twoTokens[0]);
//
//                            tokenList.Add(punctChar.ToString());
//                            newSentence.Append(punctChar.ToString());
//
//                            newSentence.Append(" ");
//
//                            tokenList.Add(twoTokens[1]);
//                            newSentence.Append(twoTokens[1]);
                        }
                    }
                    else
                    {
                        newSentence.Append(currentToken);
						lastToken = currentToken;
                        tokenList.Add(currentToken);
                        sentencesList.Add(new Sentence(segment, position, newSentence.ToString(), tokenList));
                        newSentence.Length = 0;
                        tokenList.Clear();
						position++;
					}
                }
				else if (punctPos >= 0)
				{
					if (currentToken.Length > 1)
					{
						char punctChar = currentToken[punctPos];

						if (punctPos == 0)
						{
							lastToken = punctChar.ToString();
							tokenList.Add(punctChar.ToString());
							newSentence.Append(punctChar.ToString());

							newSentence.Append(" ");

							currentToken = currentToken.Remove(punctPos,1);

							lastToken = currentToken;
							tokenList.Add(currentToken);
							newSentence.Append(currentToken);
						}
						else if (punctPos == (currentToken.Length-1))
						{
							if (newSentence.Length > 0)
								newSentence.Append(" ");

							currentToken = currentToken.Remove(punctPos,1);
							tokenList.Add(currentToken);
							newSentence.Append(currentToken);

							lastToken = punctChar.ToString();
							tokenList.Add(punctChar.ToString());
							newSentence.Append(punctChar.ToString());
						}
						else
						{
							lastToken = currentToken;
							tokenList.Add(currentToken);
							if ((newSentence.Length > 0) &&
								(currentToken.IndexOfAny(new char[] {'\''}) < 0))
								newSentence.Append(" ");
						
							newSentence.Append(currentToken);
						}
					}
				}
				else
                {
					lastToken = currentToken;
                    tokenList.Add(currentToken);

					//(currentToken.IndexOfAny(new char[] {',', ';', '"', '\''}) < 0) &&

                    if ((newSentence.Length > 0) && 
                        (lastToken.IndexOfAny(new char[] {'"', '\'', '$'}) < 0))
                        newSentence.Append(" ");
                    
                    newSentence.Append(currentToken);
                }
            }

            if (tokenList.Count > 0)
            {
                sentencesList.Add(new Sentence(segment, position, newSentence.ToString(), tokenList));
				position++;
			}

			return sentencesList;
		}
	}
}