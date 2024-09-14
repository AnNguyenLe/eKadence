using eKadenceHomework;

var sentence = "An apple a table";
var avgLettersInAWord = sentence.AverageNumberOfLettersPerWord(word => word.Length >= 2);

Console.WriteLine(avgLettersInAWord); // Should be 4 
