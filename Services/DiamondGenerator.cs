namespace Diamond.Services;

public class DiamondGenerator
{
    public string Create(char targetLetter, char padCharacter)
    {
        // Check if the charcter is an Ascii letter
        if (!Char.IsAsciiLetter(targetLetter))
        {
            throw new ArgumentException("Invalid character. Character should be an Ascii letter charcter");
        }

        //Convert to uppercase if lowercase 
        targetLetter = targetLetter.ToString().ToUpper()[0];
        var letterArray = GetCharactersInRange(targetLetter);
        var diamondLines = new List<string>();
        foreach (var c in letterArray)
        {
            var line = MakeDiamondLine(letterArray.Length, c, padCharacter);
            diamondLines.Add(line);
        }
        diamondLines.AddRange(diamondLines.ToArray().Reverse().Skip(1));
        return string.Join("\n", diamondLines);
    }

    private static char[] GetCharactersInRange(char target)
    {
        return Enumerable.Range('A', target - 'A' + 1).Select(r => ((char)r)).ToArray();
    }
    private static string MakeDiamondLine(int letterCount, char lineLetter, char padCharacter = ' ')
    {
        var charDifference = Math.Abs('A' - lineLetter);
        var outerPadding = string.Empty.PadRight(letterCount - charDifference - 1, padCharacter);
        var innerPadding = string.Empty.PadRight(charDifference == 0 ? 0 : charDifference * 2 - 1, padCharacter);

        return lineLetter == 'A' ?
            $"{outerPadding}{lineLetter}{outerPadding}" :
            $"{outerPadding}{lineLetter}{innerPadding}{lineLetter}{outerPadding}";
    }
}