using eKadenceHomework;

namespace eKadenceHomeworkTests;

public class StringExtensionsTests
{
    readonly Func<string, bool> matchedCondition = word => word.Length >= 2;
    readonly string basicSentence = "Hello, World. My name is Nguyen Le Thien An.";
    readonly string advancedSentence =
        "'Hey y'all', he stepped into a bar and asking loudly, 'any of ya happened to know Mr.K?'";

    [Fact]
    public void AverageNumberOfLettersPerWord_ShouldReturnMinusOne_WhenInputStringIsNullOrEmpty()
    {
        // Arrange
        var text1 = string.Empty;
        string? text2 = null;

        // Act
        var result1 = text1.AverageNumberOfLettersPerWord(matchedCondition);
#pragma warning disable CS8604 // Possible null reference argument.
        var result2 = text2.AverageNumberOfLettersPerWord(matchedCondition);
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        Assert.Equal(-1, result1);
        Assert.Equal(-1, result2);
    }

    [Fact]
    public void AverageNumberOfLettersPerWord_ShouldReturnZero_WhenInputStringIsContainsWordsLessThan2CharactersLong()
    {
        // Arrange
        var text = "a b c d e f g h'";

        // Act
        var result = text.AverageNumberOfLettersPerWord(matchedCondition);

        // Assert
        Assert.Equal(0, result);
    }

    [Fact]
    public void AverageNumberOfLettersPerWord_ShouldReturnCorrectNumber_WhenInputStringIsASentence()
    {
        // Arrange
        var text = basicSentence;

        // Act
        var result = text.AverageNumberOfLettersPerWord(matchedCondition);

        // Assert
        Assert.Equal(3, result);
    }

    [Fact]
    public void AverageNumberOfLettersPerWord_ShouldReturnCorrectNumber_WhenInputStringIsASentenceAdvanced()
    {
        // Arrange
        var text = advancedSentence;

        // Act
        var result = text.AverageNumberOfLettersPerWord(matchedCondition);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void GetWords_ShouldReturnEmptyList_WhenInputStringIsNullOrEmpty()
    {
        // Arrange
        var sentence1 = string.Empty;
        string? sentence2 = null;

        // Act
        var words1 = sentence1.GetWords();
#pragma warning disable CS8604 // Possible null reference argument.
        var words2 = sentence2.GetWords();
#pragma warning restore CS8604 // Possible null reference argument.

        // Assert
        Assert.Empty(words1);
        Assert.Empty(words2);
    }

    [Fact]
    public void GetWords_ShouldReturnListOfOneWord_WhenInputStringIsSentenceWithOneWord()
    {
        // Arrange
        var sentence = "Hello";

        // Act
        var words = sentence.GetWords();

        // Assert
        Assert.Single(words);
        Assert.Equal(sentence, words.FirstOrDefault());
    }

    [Fact]
    public void GetWords_ShouldReturnListOfWords_WhenInputStringIsSentenceWithManyWords()
    {
        // Arrange
        var sentence = basicSentence;

        // Act
        var words = sentence.GetWords();

        // Assert
        Assert.Equal(9, words.Count());
        Assert.Equal("Hello", words.ElementAt(0));
        Assert.Equal("World", words.ElementAt(1));
    }

    [Fact]
    public void GetWords_ShouldReturnListOfWords_WhenInputStringIsSentenceWithManyWordsAdvanced()
    {
        // Arrange
        var sentence = advancedSentence;

        // Act
        var words = sentence.GetWords();

        // Assert
        Assert.Equal(17, words.Count());
        Assert.Equal("y'all", words.ElementAt(1));
        Assert.Equal("Mr.K", words.LastOrDefault());
    }
}
