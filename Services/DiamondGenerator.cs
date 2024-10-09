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
        var letterArray = Enumerable.Range('A', targetLetter - 'A' + 1).Select(r => ((char)r)).ToArray();
        var diamondLines = MakeDiamondLines(letterArray, padCharacter);
        diamondLines.AddRange(diamondLines.ToArray().Reverse().Skip(1));
        return string.Join("\n", diamondLines);
    }

    private static List<string> MakeDiamondLines(char[] letterArray, char padCharacter = ' ')
    {
        var diamondLines = new List<string>();
        var outerPaddingLength = letterArray.Length - 1;
        var innerPaddingLength = -1;
        foreach (var lineLetter in letterArray)
        {
            var charDifference = lineLetter - 'A';
            var outerPadding = string.Empty.PadRight(outerPaddingLength, padCharacter);
            var innerPadding = string.Empty.PadRight(innerPaddingLength <0 ? 0: innerPaddingLength, padCharacter);

            diamondLines.Add( lineLetter == 'A' ?
                $"{outerPadding}{lineLetter}{outerPadding}" :
                $"{outerPadding}{lineLetter}{innerPadding}{lineLetter}{outerPadding}");

            innerPaddingLength += 2;
            outerPaddingLength--;
        }
        return diamondLines;
    }

}