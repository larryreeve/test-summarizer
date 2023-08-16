/*
 *    LovinsStemmer.java
 *    Copyright (C) 2001 Eibe Frank
 *
 *    This program is free software; you can redistribute it and/or modify
 *    it under the terms of the GNU General Public License as published by
 *    the Free Software Foundation; either version 2 of the License, or
 *    (at your option) any later version.
 *
 *    This program is distributed in the hope that it will be useful,
 *    but WITHOUT ANY WARRANTY; without even the implied warranty of
 *    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *    GNU General Public License for more details.
 *
 *    You should have received a copy of the GNU General Public License
 *    along with this program; if not, write to the Free Software
 *    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
 */
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Text;

namespace SummaryLib
{
    public class LovinsStemmer : IStemmer
    {
        /** Enters C version compatibility mode if set to true (emulates
            features of the original C implementation that are inconsistent
            with the algorithm as described in Lovins's paper) */
        private static bool m_CompMode = false;

        /** The hash tables containing the list of endings. */
        private static Hashtable m_l11 = null;
        private static Hashtable m_l10 = null;
        private static Hashtable m_l9 = null;
        private static Hashtable m_l8 = null;
        private static Hashtable m_l7 = null;
        private static Hashtable m_l6 = null;
        private static Hashtable m_l5 = null;
        private static Hashtable m_l4 = null;
        private static Hashtable m_l3 = null;
        private static Hashtable m_l2 = null;
        private static Hashtable m_l1 = null;

        static LovinsStemmer()
        {
            m_l11 = new Hashtable();
            m_l11.Add("alistically", "B");
            m_l11.Add("arizability", "A");
            m_l11.Add("izationally", "B");
            m_l10 = new Hashtable();
            m_l10.Add("antialness", "A");
            m_l10.Add("arisations", "A");
            m_l10.Add("arizations", "A");
            m_l10.Add("entialness", "A");
            m_l9 = new Hashtable();
            m_l9.Add("allically", "C");
            m_l9.Add("antaneous", "A");
            m_l9.Add("antiality", "A");
            m_l9.Add("arisation", "A");
            m_l9.Add("arization", "A");
            m_l9.Add("ationally", "B");
            m_l9.Add("ativeness", "A");
            m_l9.Add("eableness", "E");
            m_l9.Add("entations", "A");
            m_l9.Add("entiality", "A");
            m_l9.Add("entialize", "A");
            m_l9.Add("entiation", "A");
            m_l9.Add("ionalness", "A");
            m_l9.Add("istically", "A");
            m_l9.Add("itousness", "A");
            m_l9.Add("izability", "A");
            m_l9.Add("izational", "A");
            m_l8 = new Hashtable();
            m_l8.Add("ableness", "A");
            m_l8.Add("arizable", "A");
            m_l8.Add("entation", "A");
            m_l8.Add("entially", "A");
            m_l8.Add("eousness", "A");
            m_l8.Add("ibleness", "A");
            m_l8.Add("icalness", "A");
            m_l8.Add("ionalism", "A");
            m_l8.Add("ionality", "A");
            m_l8.Add("ionalize", "A");
            m_l8.Add("iousness", "A");
            m_l8.Add("izations", "A");
            m_l8.Add("lessness", "A");
            m_l7 = new Hashtable();
            m_l7.Add("ability", "A");
            m_l7.Add("aically", "A");
            m_l7.Add("alistic", "B");
            m_l7.Add("alities", "A");
            m_l7.Add("ariness", "E");
            m_l7.Add("aristic", "A");
            m_l7.Add("arizing", "A");
            m_l7.Add("ateness", "A");
            m_l7.Add("atingly", "A");
            m_l7.Add("ational", "B");
            m_l7.Add("atively", "A");
            m_l7.Add("ativism", "A");
            m_l7.Add("elihood", "E");
            m_l7.Add("encible", "A");
            m_l7.Add("entally", "A");
            m_l7.Add("entials", "A");
            m_l7.Add("entiate", "A");
            m_l7.Add("entness", "A");
            m_l7.Add("fulness", "A");
            m_l7.Add("ibility", "A");
            m_l7.Add("icalism", "A");
            m_l7.Add("icalist", "A");
            m_l7.Add("icality", "A");
            m_l7.Add("icalize", "A");
            m_l7.Add("ication", "G");
            m_l7.Add("icianry", "A");
            m_l7.Add("ination", "A");
            m_l7.Add("ingness", "A");
            m_l7.Add("ionally", "A");
            m_l7.Add("isation", "A");
            m_l7.Add("ishness", "A");
            m_l7.Add("istical", "A");
            m_l7.Add("iteness", "A");
            m_l7.Add("iveness", "A");
            m_l7.Add("ivistic", "A");
            m_l7.Add("ivities", "A");
            m_l7.Add("ization", "F");
            m_l7.Add("izement", "A");
            m_l7.Add("oidally", "A");
            m_l7.Add("ousness", "A");
            m_l6 = new Hashtable();
            m_l6.Add("aceous", "A");
            m_l6.Add("acious", "B");
            m_l6.Add("action", "G");
            m_l6.Add("alness", "A");
            m_l6.Add("ancial", "A");
            m_l6.Add("ancies", "A");
            m_l6.Add("ancing", "B");
            m_l6.Add("ariser", "A");
            m_l6.Add("arized", "A");
            m_l6.Add("arizer", "A");
            m_l6.Add("atable", "A");
            m_l6.Add("ations", "B");
            m_l6.Add("atives", "A");
            m_l6.Add("eature", "Z");
            m_l6.Add("efully", "A");
            m_l6.Add("encies", "A");
            m_l6.Add("encing", "A");
            m_l6.Add("ential", "A");
            m_l6.Add("enting", "C");
            m_l6.Add("entist", "A");
            m_l6.Add("eously", "A");
            m_l6.Add("ialist", "A");
            m_l6.Add("iality", "A");
            m_l6.Add("ialize", "A");
            m_l6.Add("ically", "A");
            m_l6.Add("icance", "A");
            m_l6.Add("icians", "A");
            m_l6.Add("icists", "A");
            m_l6.Add("ifully", "A");
            m_l6.Add("ionals", "A");
            m_l6.Add("ionate", "D");
            m_l6.Add("ioning", "A");
            m_l6.Add("ionist", "A");
            m_l6.Add("iously", "A");
            m_l6.Add("istics", "A");
            m_l6.Add("izable", "E");
            m_l6.Add("lessly", "A");
            m_l6.Add("nesses", "A");
            m_l6.Add("oidism", "A");
            m_l5 = new Hashtable();
            m_l5.Add("acies", "A");
            m_l5.Add("acity", "A");
            m_l5.Add("aging", "B");
            m_l5.Add("aical", "A");
            if (!m_CompMode) 
            {
                m_l5.Add("alist", "A");
            }
            m_l5.Add("alism", "B");
            m_l5.Add("ality", "A");
            m_l5.Add("alize", "A");
            m_l5.Add("allic", "b");
            m_l5.Add("anced", "B");
            m_l5.Add("ances", "B");
            m_l5.Add("antic", "C");
            m_l5.Add("arial", "A");
            m_l5.Add("aries", "A");
            m_l5.Add("arily", "A");
            m_l5.Add("arity", "B");
            m_l5.Add("arize", "A");
            m_l5.Add("aroid", "A");
            m_l5.Add("ately", "A");
            m_l5.Add("ating", "I");
            m_l5.Add("ation", "B");
            m_l5.Add("ative", "A");
            m_l5.Add("ators", "A");
            m_l5.Add("atory", "A");
            m_l5.Add("ature", "E");
            m_l5.Add("early", "Y");
            m_l5.Add("ehood", "A");
            m_l5.Add("eless", "A");
            if (!m_CompMode) 
            {
                m_l5.Add("elily", "A");
            } 
            else 
            {
                m_l5.Add("elity", "A");
            }
            m_l5.Add("ement", "A");
            m_l5.Add("enced", "A");
            m_l5.Add("ences", "A");
            m_l5.Add("eness", "E");
            m_l5.Add("ening", "E");
            m_l5.Add("ental", "A");
            m_l5.Add("ented", "C");
            m_l5.Add("ently", "A");
            m_l5.Add("fully", "A");
            m_l5.Add("ially", "A");
            m_l5.Add("icant", "A");
            m_l5.Add("ician", "A");
            m_l5.Add("icide", "A");
            m_l5.Add("icism", "A");
            m_l5.Add("icist", "A");
            m_l5.Add("icity", "A");
            m_l5.Add("idine", "I");
            m_l5.Add("iedly", "A");
            m_l5.Add("ihood", "A");
            m_l5.Add("inate", "A");
            m_l5.Add("iness", "A");
            m_l5.Add("ingly", "B");
            m_l5.Add("inism", "J");
            m_l5.Add("inity", "c");
            m_l5.Add("ional", "A");
            m_l5.Add("ioned", "A");
            m_l5.Add("ished", "A");
            m_l5.Add("istic", "A");
            m_l5.Add("ities", "A");
            m_l5.Add("itous", "A");
            m_l5.Add("ively", "A");
            m_l5.Add("ivity", "A");
            m_l5.Add("izers", "F");
            m_l5.Add("izing", "F");
            m_l5.Add("oidal", "A");
            m_l5.Add("oides", "A");
            m_l5.Add("otide", "A");
            m_l5.Add("ously", "A");
            m_l4 = new Hashtable();
            m_l4.Add("able", "A");
            m_l4.Add("ably", "A");
            m_l4.Add("ages", "B");
            m_l4.Add("ally", "B");
            m_l4.Add("ance", "B");
            m_l4.Add("ancy", "B");
            m_l4.Add("ants", "B");
            m_l4.Add("aric", "A");
            m_l4.Add("arly", "K");
            m_l4.Add("ated", "I");
            m_l4.Add("ates", "A");
            m_l4.Add("atic", "B");
            m_l4.Add("ator", "A");
            m_l4.Add("ealy", "Y");
            m_l4.Add("edly", "E");
            m_l4.Add("eful", "A");
            m_l4.Add("eity", "A");
            m_l4.Add("ence", "A");
            m_l4.Add("ency", "A");
            m_l4.Add("ened", "E");
            m_l4.Add("enly", "E");
            m_l4.Add("eous", "A");
            m_l4.Add("hood", "A");
            m_l4.Add("ials", "A");
            m_l4.Add("ians", "A");
            m_l4.Add("ible", "A");
            m_l4.Add("ibly", "A");
            m_l4.Add("ical", "A");
            m_l4.Add("ides", "L");
            m_l4.Add("iers", "A");
            m_l4.Add("iful", "A");
            m_l4.Add("ines", "M");
            m_l4.Add("ings", "N");
            m_l4.Add("ions", "B");
            m_l4.Add("ious", "A");
            m_l4.Add("isms", "B");
            m_l4.Add("ists", "A");
            m_l4.Add("itic", "H");
            m_l4.Add("ized", "F");
            m_l4.Add("izer", "F");
            m_l4.Add("less", "A");
            m_l4.Add("lily", "A");
            m_l4.Add("ness", "A");
            m_l4.Add("ogen", "A");
            m_l4.Add("ward", "A");
            m_l4.Add("wise", "A");
            m_l4.Add("ying", "B");
            m_l4.Add("yish", "A");
            m_l3 = new Hashtable();
            m_l3.Add("acy", "A");
            m_l3.Add("age", "B");
            m_l3.Add("aic", "A");
            m_l3.Add("als", "b");
            m_l3.Add("ant", "B");
            m_l3.Add("ars", "O");
            m_l3.Add("ary", "F");
            m_l3.Add("ata", "A");
            m_l3.Add("ate", "A");
            m_l3.Add("eal", "Y");
            m_l3.Add("ear", "Y");
            m_l3.Add("ely", "E");
            m_l3.Add("ene", "E");
            m_l3.Add("ent", "C");
            m_l3.Add("ery", "E");
            m_l3.Add("ese", "A");
            m_l3.Add("ful", "A");
            m_l3.Add("ial", "A");
            m_l3.Add("ian", "A");
            m_l3.Add("ics", "A");
            m_l3.Add("ide", "L");
            m_l3.Add("ied", "A");
            m_l3.Add("ier", "A");
            m_l3.Add("ies", "P");
            m_l3.Add("ily", "A");
            m_l3.Add("ine", "M");
            m_l3.Add("ing", "N");
            m_l3.Add("ion", "Q");
            m_l3.Add("ish", "C");
            m_l3.Add("ism", "B");
            m_l3.Add("ist", "A");
            m_l3.Add("ite", "a");
            m_l3.Add("ity", "A");
            m_l3.Add("ium", "A");
            m_l3.Add("ive", "A");
            m_l3.Add("ize", "F");
            m_l3.Add("oid", "A");
            m_l3.Add("one", "R");
            m_l3.Add("ous", "A");
            m_l2 = new Hashtable();
            m_l2.Add("ae", "A"); 
            m_l2.Add("al", "b");
            m_l2.Add("ar", "X");
            m_l2.Add("as", "B");
            m_l2.Add("ed", "E");
            m_l2.Add("en", "F");
            m_l2.Add("es", "E");
            m_l2.Add("ia", "A");
            m_l2.Add("ic", "A");
            m_l2.Add("is", "A");
            m_l2.Add("ly", "B");
            m_l2.Add("on", "S");
            m_l2.Add("or", "T");
            m_l2.Add("um", "U");
            m_l2.Add("us", "V");
            m_l2.Add("yl", "R");
            m_l2.Add("s\'", "A");
            m_l2.Add("\'s", "A");
            m_l1 = new Hashtable();
            m_l1.Add("a", "A");
            m_l1.Add("e", "A");
            m_l1.Add("i", "A");
            m_l1.Add("o", "A");
            m_l1.Add("s", "W");
            m_l1.Add("y", "B");	
        }

        /**
        * Finds and removes ending from given word.
        */
        private string removeEnding(string word) 
        {
            int length = word.Length;
            int el = 11;

            while (el > 0) 
            {
                if (length - el > 1) 
                {
                    string ending = word.Substring(length - el);
                    string conditionCode = null;

                    switch (el) 
                    {
                        case 11: 
                            conditionCode = (string)m_l11[ending];
                            break;
                        case 10: 
                            conditionCode = (string) m_l10[ending];
                            break; 
                        case 9: 
                            conditionCode = (string)m_l9[ending];
                            break;
                        case 8: 
                            conditionCode = (string)m_l8[ending];
                            break;   
                        case 7: 
                            conditionCode = (string)m_l7[ending];
                            break;   
                        case 6: 
                            conditionCode = (string)m_l6[ending];
                            break;   
                        case 5: 
                            conditionCode = (string)m_l5[ending];
                            break;   
                        case 4: 
                            conditionCode = (string)m_l4[ending];
                            break;   
                        case 3: 
                            conditionCode = (string)m_l3[ending];
                            break;   
                        case 2: 
                            conditionCode = (string)m_l2[ending];
                            break;   
                        case 1: 
                            conditionCode = (string)m_l1[ending];
                            break;   
                        default:
                            break;
                    }

                    if (conditionCode != null) 
                    {
                        switch (conditionCode[0]) 
                        {
                            case 'A':
                                return word.Substring(0, length - el);
                            case 'B':
                                if (length - el > 2) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'C':
                                if (length - el > 3) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'D':
                                if (length - el > 4) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'E':
                                if (word[length - el - 1] != 'e') 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'F':
                                if ((length - el > 2) &&
                                    (word[length - el - 1] != 'e')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'G':
                                if ((length - el > 2) &&
                                    (word[length - el - 1] == 'f')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'H':
                                if ((word[length - el - 1] == 't') ||
                                   ((word[length - el - 1] == 'l') &&
                                    (word[length - el - 2] == 'l'))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'I':
                                if ((word[length - el - 1] != 'o') &&
                                    (word[length - el - 1] != 'e')) 
                                { 
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'J':
                                if ((word[length - el - 1] != 'a') &&
                                    (word[length - el - 1] != 'e')) 
                                { 
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'K':
                                if ((length - el > 2) &&
                                    ((word[length - el - 1] == 'l') ||
                                     (word[length - el - 1] == 'i') ||
                                    ((word[length - el - 1] == 'e') &&
                                     (word[length - el - 3] == 'u')))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'L':
                                if ((word[length - el - 1] != 'u') &&
                                    (word[length - el - 1] != 'x') &&
                                   ((word[length - el - 1] != 's') ||
                                    (word[length - el - 2] == 'o'))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'M':
                                if ((word[length - el - 1] != 'a') &&
                                    (word[length - el - 1] != 'c') &&
                                    (word[length - el - 1] != 'e') &&
                                    (word[length - el - 1] != 'm')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'N':
                                if ((length - el > 3) || 
                                    ((length - el == 3) &&
                                    ((word[length - el - 3] != 's')))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'O':
                                if ((word[length - el - 1] == 'l') ||
                                    (word[length - el - 1] == 'i')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'P':
                                if (word[length - el - 1] != 'c') 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'Q':
                                if ((length - el > 2) &&
                                    (word[length - el - 1] != 'l') &&
                                    (word[length - el - 1] != 'n')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'R':
                                if ((word[length - el - 1] == 'n') ||
                                    (word[length - el - 1] == 'r')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'S':
                                if (((word[length - el - 1] == 'r') &&
                                     (word[length - el - 2] == 'd')) ||
                                    ((word[length - el - 1] == 't') &&
                                     (word[length - el - 2] != 't'))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'T':
                                if ((word[length - el - 1] == 's') ||
                                   ((word[length - el - 1] == 't') &&
                                    (word[length - el - 2] != 'o'))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'U':
                                if ((word[length - el - 1] == 'l') ||
                                    (word[length - el - 1] == 'm') ||
                                    (word[length - el - 1] == 'n') ||
                                    (word[length - el - 1] == 'r')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'V':
                                if (word[length - el - 1] == 'c') 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'W':
                                if ((word[length - el - 1] != 's') &&
                                    (word[length - el - 1] != 'u')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'X':
                                if ((word[length - el - 1] == 'l') ||
                                    (word[length - el - 1] == 'i') ||
                                    ((length - el > 2) &&
                                    (word[length - el - 1] == 'e') &&
                                    (word[length - el - 3] == 'u'))) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'Y':
                                if ((word[length - el - 1] == 'n') &&
                                    (word[length - el - 2] == 'i')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'Z':
                                if (word[length - el - 1] != 'f') 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'a':
                                if ((word[length - el - 1] == 'd') ||
                                    (word[length - el - 1] == 'f') ||
                                    (((word[length - el - 1] == 'h') &&
                                    (word[length - el - 2] == 'p'))) ||
                                    (((word[length - el - 1] == 'h') &&
                                    (word[length - el - 2] == 't'))) ||
                                    (word[length - el - 1] == 'l') ||
                                    (((word[length - el - 1] == 'r') &&
                                    (word[length - el - 2] == 'e'))) ||
                                    (((word[length - el - 1] == 'r') &&
                                    (word[length - el - 2] == 'o'))) ||
                                    (((word[length - el - 1] == 's') &&
                                    (word[length - el - 2] == 'e'))) ||
                                    (word[length - el - 1] == 't')) 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            case 'b':
                                if (m_CompMode) 
                                {
                                    if (((length - el == 3 ) &&
                                        (!((word[length - el - 1] == 't') &&
                                        (word[length - el - 2] == 'e') &&
                                        (word[length - el - 3] == 'm')))) ||
                                        ((length - el > 3) &&
                                        (!((word[length - el - 1] == 't') &&
                                        (word[length - el - 2] == 's') &&
                                        (word[length - el - 3] == 'y') &&
                                        (word[length - el - 4] == 'r'))))) 
                                    {
                                        return word.Substring(0, length - el);
                                    }
                                } 
                                else 
                                {
                                    if ((length - el > 2) &&
                                        (!((word[length - el - 1] == 't') &&
                                        (word[length - el - 2] == 'e') &&
                                        (word[length - el - 3] == 'm'))) &&
                                        ((length - el < 4) ||
                                        (!((word[length - el - 1] == 't') &&
                                        (word[length - el - 2] == 's') &&
                                        (word[length - el - 3] == 'y') &&
                                        (word[length - el - 4] == 'r'))))) 
                                    {
                                        return word.Substring(0, length - el);
                                    }
                                } 
                                break;
                            case 'c':
                                if (word[length - el - 1] == 'l') 
                                {
                                    return word.Substring(0, length - el);
                                }
                                break;
                            default:
                                throw new ArgumentException("Fatal error.");
                        }
                    }
                }
                el--;
            }
            return word;
        }

        /**
        * Recodes ending of given word.
        */
        private string recodeEnding(string word) 
        {
            int lastPos = word.Length - 1;

            // Rule 1
            if (word.EndsWith("bb") ||
                word.EndsWith("dd") ||
                word.EndsWith("gg") ||
                word.EndsWith("ll") ||
                word.EndsWith("mm") ||
                word.EndsWith("nn") ||
                word.EndsWith("pp") ||
                word.EndsWith("rr") ||
                word.EndsWith("ss") ||
                word.EndsWith("tt")) 
            {
                word = word.Substring(0, lastPos);
                lastPos--;
            }

            // Rule 2
            if (word.EndsWith("iev")) 
            {
                word = word.Substring(0, lastPos - 2) + "ief";
            }

            // Rule 3
            if (word.EndsWith("uct")) 
            {
                word = word.Substring(0, lastPos - 2) + "uc";
                lastPos--;
            }

            // Rule 4
            if (word.EndsWith("umpt")) 
            {
                word = word.Substring(0, lastPos - 3) + "um";
                lastPos -= 2;
            }

            // Rule 5
            if (word.EndsWith("rpt")) 
            {
                word = word.Substring(0, lastPos - 2) + "rb";
                lastPos--;
            }

            // Rule 6
            if (word.EndsWith("urs")) 
            {
                word = word.Substring(0, lastPos - 2) + "ur";
                lastPos--;
            }

            // Rule 7
            if (word.EndsWith("istr")) 
            {
                word = word.Substring(0, lastPos - 3) + "ister";
                lastPos++;
            }
 
            // Rule 7a
            if (word.EndsWith("metr")) 
            {
                word = word.Substring(0, lastPos - 3) + "meter";
                lastPos++;
            }

            // Rule 8
            if (word.EndsWith("olv")) 
            {
                word = word.Substring(0, lastPos - 2) + "olut";
                lastPos++;
            }
 
            // Rule 9
            if (word.EndsWith("ul")) 
            {
                if ((lastPos - 2 < 0) ||
                    ((word[lastPos - 2] != 'a') &&
                     (word[lastPos - 2] != 'i') &&
                     (word[lastPos - 2] != 'o'))) 
                {
                    word = word.Substring(0, lastPos - 1) + "l";
                    lastPos--;
                }
            }

            // Rule 10
            if (word.EndsWith("bex")) 
            {
                word = word.Substring(0, lastPos - 2) + "bic";
            }

            // Rule 11
            if (word.EndsWith("dex")) 
            {
                word = word.Substring(0, lastPos - 2) + "dic";
            }

            // Rule 12
            if (word.EndsWith("pex")) 
            {
                word = word.Substring(0, lastPos - 2) + "pic";
            }

            // Rule 13
            if (word.EndsWith("tex")) 
            {
                word = word.Substring(0, lastPos - 2) + "tic";
            }

            // Rule 14
            if (word.EndsWith("ax")) 
            {
                word = word.Substring(0, lastPos - 1) + "ac";
            }

            // Rule 15
            if (word.EndsWith("ex")) 
            {
                word = word.Substring(0, lastPos - 1) + "ec";
            }

            // Rule 16
            if (word.EndsWith("ix")) 
            {
                word = word.Substring(0, lastPos - 1) + "ic";
            }

            // Rule 17
            if (word.EndsWith("lux")) 
            {
                word = word.Substring(0, lastPos - 2) + "luc";
            }

            // Rule 18
            if (word.EndsWith("uad")) 
            {
                word = word.Substring(0, lastPos - 2) + "uas";
            }

            // Rule 19
            if (word.EndsWith("vad")) 
            {
                word = word.Substring(0, lastPos - 2) + "vas";
            }

            // Rule 20
            if (word.EndsWith("cid")) 
            {
                word = word.Substring(0, lastPos - 2) + "cis";
            }

            // Rule 21
            if (word.EndsWith("lid")) 
            {
                word = word.Substring(0, lastPos - 2) + "lis";
            }

            // Rule 22
            if (word.EndsWith("erid")) 
            {
                word = word.Substring(0, lastPos - 3) + "eris";
            }

            // Rule 23
            if (word.EndsWith("pand")) 
            {
                word = word.Substring(0, lastPos - 3) + "pans";
            }
 
            // Rule 24
            if (word.EndsWith("end")) 
            {
                if ((lastPos - 3 < 0) ||
                    (word[lastPos - 3] != 's')) 
                {
                    word = word.Substring(0, lastPos - 2) + "ens";
                }
            }

            // Rule 25
            if (word.EndsWith("ond")) 
            {
                word = word.Substring(0, lastPos - 2) + "ons";
            }

            // Rule 26
            if (word.EndsWith("lud")) 
            {
                word = word.Substring(0, lastPos - 2) + "lus";
            }

            // Rule 27
            if (word.EndsWith("rud")) 
            {
                word = word.Substring(0, lastPos - 2) + "rus";
            }

            // Rule 28
            if (word.EndsWith("her")) 
            {
                if ((lastPos - 3 < 0) ||
                    ((word[lastPos - 3] != 'p') &&
                     (word[lastPos - 3] != 't'))) 
                {
                    word = word.Substring(0, lastPos - 2) + "hes";
                }
            }

            // Rule 29
            if (word.EndsWith("mit")) 
            {
                word = word.Substring(0, lastPos - 2) + "mis";
            }

            // Rule 30
            if (word.EndsWith("end")) 
            {
                if ((lastPos - 3 < 0) ||
                    (word[lastPos - 3] != 'm')) 
                {
                    word = word.Substring(0, lastPos - 2) + "ens";
                }
            }

            // Rule 31
            if (word.EndsWith("ert")) 
            {
                word = word.Substring(0, lastPos - 2) + "ers";
            }

            // Rule 32
            if (word.EndsWith("et")) 
            {
                if ((lastPos - 2 < 0) ||
                    (word[lastPos - 2] != 'n')) 
                {
                    word = word.Substring(0, lastPos - 1) + "es";
                }
            }

            // Rule 33
            if (word.EndsWith("yt")) 
            {
                word = word.Substring(0, lastPos - 1) + "ys";
            }

            // Rule 34
            if (word.EndsWith("yz")) 
            {
                word = word.Substring(0, lastPos - 1) + "ys";
            }

            return word;
        }

        /**
         * Returns the stemmed version of the given word.
         * Word is converted to lower case before stemming.
         * 
         * @param word a string consisting of a single word
         */
        public string stem(string word) 
        {

            if (word.Length > 2) 
            {
                return recodeEnding(removeEnding(word.ToLower()));
            } 
            else 
            {
                return word.ToLower();
            }
        }

        /**
         * Stems everything in the given string. string
         * is converted to lower case before stemming.
         */
        public string stemstring(string str) 
        {

            StringBuilder result = new StringBuilder();

            int start = -1;
            for (int j = 0; j < str.Length; j++) 
            {
                char c = str[j];
                if (Char.IsLetterOrDigit(c)) 
                {
                    if (start == -1) 
                    {
                        start = j;
                    }
                } 
                else if (c == '\'') 
                {
                    if (start == -1) 
                    {
                        result.Append(c);
                    }
                } 
                else 
                {
                    if (start != -1) 
                    {
                        result.Append(stem(str.Substring(start, j)));
                        start = -1;
                    }
                    result.Append(c);
                }
            }
            if (start != -1) 
            {
                result.Append(stem(str.Substring(start, str.Length)));
            }
            return result.ToString();  
        }

        public string stemTerm(string term)
        {
            return this.stem(term);
        }

        /**
         * Stems text coming into stdin and writes it to stdout.
         */
        //  public static void main(string[] ops) {
        //
        //    LovinsStemmer ls = new LovinsStemmer();
        //
        //    try {
        //      int num;
        //      stringBuffer wordBuffer = new stringBuffer();
        //      while ((num = System.in.read()) != -1) {
        //	char c = (char)num;
        //	if (((num >= (int)'A') && (num <= (int)'Z')) ||
        //	    ((num >= (int)'a') && (num <= (int)'z'))) {
        //	  wordBuffer.append(c);
        //	} else {
        //	  if (wordBuffer.length() > 0) {
        //	    System.out.print(ls.stem(wordBuffer.tostring().
        //				     toLowerCase()));
        //	    wordBuffer = new stringBuffer();
        //	  }
        //	  System.out.print(c);
        //	}
        //      }
        //    } catch (Exception e) {
        //      e.printStackTrace();
        //    }
        //  }
    }
}
