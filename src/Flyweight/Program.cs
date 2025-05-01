using System.Collections.Generic;

namespace Flyweight;

class Program
{
    static void Main(string[] args)
    {
        var aBunchOfCharacters = "abba";
        var characterFactory = new CharecterFactory();

        var characterObject = characterFactory.GetCharacter(aBunchOfCharacters[0]);
        characterObject.Draw("Maria", 13);

        characterObject = characterFactory.GetCharacter(aBunchOfCharacters[1]);
        characterObject.Draw("Joao", 16);

        characterObject = characterFactory.GetCharacter(aBunchOfCharacters[2]);
        characterObject.Draw("Simone", 34);

        characterObject = characterFactory.GetCharacter(aBunchOfCharacters[3]);
        characterObject.Draw("Wodson", 34);

        var paragraph = characterFactory.CreateParagraph(new List<ICharacter>() { characterObject }, 1);

        paragraph.Draw("Antonio", 25);
    }
}
