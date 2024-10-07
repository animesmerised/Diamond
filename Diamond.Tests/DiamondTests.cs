using Xunit;
using Diamond.Services;
using System;

namespace Diamond.Tests;

public class DiamondTests
{
    [Fact]
    public void Create_ShouldReturnCorrectDiamond_ForLetterE()
    {
        // Arrange
        var diamond = new DiamondGenerator();
        var expected = "    A    \n" +
                       "   B B   \n" +
                       "  C   C  \n" +
                       " D     D \n" +
                       "E       E\n" +
                       " D     D \n" +
                       "  C   C  \n" +
                       "   B B   \n" +
                       "    A    ";

        // Act
        var result = diamond.Create('E', ' ');

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Create_ShouldReturnCorrectDiamond_ForLetterC()
    {
        // Arrange
        var diamond = new DiamondGenerator();
        var expected = "  A  \n" +
                       " B B \n" +
                       "C   C\n" +
                       " B B \n" +
                       "  A  ";

        // Act
        var result = diamond.Create('C', ' ');

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Create_ShouldReturnCorrectDiamond_ForLowercaseLetterc()
    {
        // Arrange
        var diamond = new DiamondGenerator();
        var expected = "  A  \n" +
                       " B B \n" +
                       "C   C\n" +
                       " B B \n" +
                       "  A  ";

        // Act
        var result = diamond.Create('c', ' ');

        // Assert
        Assert.Equal(expected, result);
    }


    [Fact]
    public void Create_ShouldReturnCorrectDiamond_WithCustomPadding()
    {
        // Arrange
        var diamond = new DiamondGenerator();
        var expected = "----A----\n" +
                       "---B-B---\n" +
                       "--C---C--\n" +
                       "-D-----D-\n" +
                       "E-------E\n" +
                       "-D-----D-\n" +
                       "--C---C--\n" +
                       "---B-B---\n" +
                       "----A----";

        // Act
        var result = diamond.Create('E', '-');

        // Assert
        Assert.Equal(expected, result);
    }

    [Fact]
    public void NonAsciiCharacterShouldThrowAndException()
    {
        // Arrange
        var diamond = new DiamondGenerator();
        var expected = "Invalid character. Character should be an Ascii letter charcter";

        // Act
        string action() => diamond.Create('$', ' ');

        // Assert
        var caughtException = Assert.Throws<ArgumentException>((Func<string>)action);
        Assert.Equal(expected, caughtException.Message);
    }

    [Theory]
    [ClassData(typeof(DiamondTestData))]
    public void CreateShouldReturnCorrectDiamondForLetter(char letter, string expected)
    {
        // Arrange
        var diamond = new DiamondGenerator();

        // Act
        var result = diamond.Create(letter, ' ');

        // Assert
        Assert.Equal(expected, result);
    }
}
