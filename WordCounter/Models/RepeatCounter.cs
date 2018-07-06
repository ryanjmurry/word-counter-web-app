using System;
using System.Collections.Generic;
using System.Linq;

namespace WordCounter.Models
{
    public class RepeatCounter
    {
        //object properties
        private string _targetWord = "";
        private string _searchPhrase = "";
        private List<string> _searchList = new List<string>() { };
        private int _start = 0;
        private int _end = 0;
        private int _range = 0;
        private int _listIndex = 0;
        private int _matches = 0;
        private static List<RepeatCounter> _history = new List<RepeatCounter>() { };
        private int _id;

        //object constructor
        public RepeatCounter(string targetWord = "", string searchPhrase = "")
        {
            _targetWord = targetWord.ToLower();
            _searchPhrase = searchPhrase.ToLower();
            SetSearchList();
            _history.Add(this);
            _id = _history.Count;
        }

        public static List<RepeatCounter> GetHistory()
        {
            return _history;
        }

        public int GetId()
        {
            return _id;
        }

        public static RepeatCounter Find(int id)
        {
            return _history[id - 1];
        }

        public void ClearHistory()
        {
            _history.Clear();
        }

        public static void ClearOne(int id)
        {
            _history.RemoveAt(id - 1);
            foreach (RepeatCounter search in _history)
            {
                if (search._id > id)
                {
                    search._id--;
                }
            }
        }

        public string GetTargetWord()
        {
            return _targetWord;
        }

        //checks for punctuation at beginning and end of word
        public bool CheckBookendPunctuation()
        {
            if (Char.IsPunctuation(_targetWord[0]) || Char.IsPunctuation(_targetWord[_targetWord.Length - 1]))
            {
                return true;
            }
            return false;
        }

        //checks target word for numbers, letters, apostrophes, and dashes
        public bool CheckAllowedCharacters()
        {
            foreach (char letter in _targetWord)
            {
                if (Char.IsWhiteSpace(letter))
                {
                    return false;
                }
                else
                {
                    if (!Char.IsNumber(letter) || !Char.IsLetter(letter) || letter != '\'' || letter != '-')
                    {

                    }
                }
            }
            return true;
        }

        //to be run in main()
        public bool ValidateTargetWord()
        {
            GetTargetWord();
            if (CheckBookendPunctuation() || !CheckAllowedCharacters())
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string GetSearchPhrase()
        {
            return _searchPhrase;
        }

        public void SetSearchList()
        {
            _searchList = _searchPhrase.Split(' ').ToList();
        }

        public List<string> GetSearchList()
        {
            return _searchList;
        }

        public void IncrementStart()
        {
            _start++;
        }

        public int GetStart()
        {
            return _start;
        }

        public void ReduceEnd()
        {
            _end--;
        }

        public int GetEnd()
        {
            return _end;
        }

        public void IncrementListIndex()
        {
            _listIndex++;
        }

        public int GetListIndex()
        {
            return _listIndex;
        }

        public void ResetCleanerValues()
        {
            _start = 0;
            _end = 0;
            _range = 0;
        }

        public void SetSubstringValues(string word)
        {
            _end = word.Length - 1;
            while (Char.IsPunctuation(word[_start]))
            {
                IncrementStart();
            }
            while (Char.IsPunctuation(word[_end]))
            {
                ReduceEnd();
            }
        }

        public void ReplaceWord(string word, int index)
        {
            SetSubstringValues(word);
            _range = (_end - _start) + 1;
            string cleanWord = word.Substring(_start, _range);
            _searchList[index] = cleanWord;
        }

        public void CleanList()
        {
            for (int i = 0; i < _searchList.Count; i++)
            {
                ReplaceWord(_searchList[i], _listIndex);
                IncrementListIndex();
                ResetCleanerValues();
            }
        }

        public void IncrementMatches()
        {
            _matches++;
        }

        public void SetMatches()
        {
            CleanList();
            foreach (string word in _searchList)
            {
                if (word == _targetWord)
                {
                    IncrementMatches();
                }
            }
        }

        public int Matches()
        {
            SetMatches();
            return _matches;
        }
    }
}
