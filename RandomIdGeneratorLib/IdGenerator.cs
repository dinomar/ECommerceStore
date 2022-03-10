using System;
using System.Collections.Generic;
using System.Text;

namespace RandomIdGeneratorLib
{
    public static class IdGenerator
    {
        private readonly static char[] _lowerCaseCharacters = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
        private readonly static char[] _upperCaseCharacters = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
        private readonly static char[] _numberCharacters = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private readonly static Random _random = new Random();


        public static string Generate(int length, bool excludeNumbers = false, bool excludeLowerCase = false, bool excludeUpperCase = false)
        {
            char[] characters = getCharacterList(excludeNumbers, excludeLowerCase, excludeUpperCase);

            char[] id = new char[length];
            for (int i = 0; i < length; i++)
            {
                int rand = _random.Next(0, characters.Length);
                id[i] = characters[rand];
            }

            return new string(id);
        }

        private static char[] getCharacterList(bool excludeNumbers, bool excludeLowerCase, bool excludeUpperCase)
        {
            int characterListLength = 0;

            
            if (!excludeNumbers) { characterListLength += _numberCharacters.Length; }
            if (!excludeLowerCase) { characterListLength += _lowerCaseCharacters.Length; }
            if (!excludeUpperCase) { characterListLength += _upperCaseCharacters.Length; }

            int lastIndex = 0;
            char[] characters = new char[characterListLength];


            if (!excludeNumbers)
            {
                _numberCharacters.CopyTo(characters, lastIndex);
                lastIndex += _numberCharacters.Length;
            }

            if (!excludeLowerCase)
            {
                _lowerCaseCharacters.CopyTo(characters, lastIndex);
                lastIndex += _lowerCaseCharacters.Length;
            }

            if (!excludeUpperCase)
            {
                _upperCaseCharacters.CopyTo(characters, lastIndex);
                lastIndex += _upperCaseCharacters.Length;
            }

            return characters;
        }
    }
}
