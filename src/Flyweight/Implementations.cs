using System;
using System.Collections.Generic;

namespace Flyweight
{

    /// <summary>
    /// Flyweight
    /// </summary>
    public interface ICharacter
    {
        void Draw(string fontFamily, int fontSize);
    }

    public class CharecterA : ICharacter
    {
        private char _actualCharacter = 'a';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    public class CharecterB : ICharacter
    {
        private char _actualCharacter = 'b';
        private string _fontFamily = string.Empty;
        private int _fontSize;

        public void Draw(string fontFamily, int fontSize)
        {
            _fontFamily = fontFamily;
            _fontSize = fontSize;
            Console.WriteLine($"Drawing {_actualCharacter}, {_fontFamily} {_fontSize}");
        }
    }

    /// <summary>
    /// FlyweighFactory
    /// </summary>
    public class CharecterFactory
    {
        private readonly Dictionary<char, ICharacter> _characters = new();

        public ICharacter GetCharacter(char character)
        {
            if(_characters.ContainsKey(character))
            {
                Console.WriteLine("Character reuse");
                return _characters[character];
            }

            switch (character)
            {
                case 'a':
                    _characters[character] = new CharecterA();
                    return _characters[character];
                case 'b':
                    _characters[character] = new CharecterB();
                    return _characters[character];
            }

            return null;
        }
    
        public ICharacter CreateParagraph(List<ICharacter> characters, int location)
        {
            return new Paragraph(characters, location);
        }
    }

    /// <summary>
    /// Unshared Concrete Flyweight
    /// </summary>
    public class Paragraph: ICharacter
    {
        private int _location;
        private List<ICharacter> _characters = new();

        public Paragraph(List<ICharacter> characters, int location)
        {
            _characters = characters;
            _location = location;
        }

        public void Draw(string fontFamily, int fontSize)
        {
            Console.WriteLine($"Drawing in paragraph at location {_location}");

            foreach (var character in _characters)
            {
                character.Draw(fontFamily, fontSize);
            }
        }
    }
}