using System;

class HashingExample
{
    static void Main()
    {
        string testInput = "Programming";
        int hash = FoldingHash(testInput);
        Console.WriteLine("The hash value for '{0}' is: {1}", testInput, hash);
    }

    private static int FoldingHash(string input)
    {
        int hashValue = 0;
        int startIndex = 0;
        int currentFourBytes;

        do
        {
            // Grab the next 4-byte chunk
            currentFourBytes = GetNextBytes(startIndex, input);

            // 'unchecked' allows the number to "roll over" if it exceeds 
            // the max value of an integer, which is standard in hashing.
            unchecked
            {
                hashValue += currentFourBytes;
            }

            startIndex += 4;
        } while (startIndex < input.Length);

        return hashValue;
    }

    private static int GetNextBytes(int start, string input)
    {
        int value = 0;
        // Loop up to 4 times to build a 32-bit integer from characters
        for (int i = 0; i < 4; i++)
        {
            if (start + i < input.Length)
            {
                // Shift the existing bits left and add the new character's ASCII value
                value = (value << 8) + (int)input[start + i];
            }
        }
        return value;
    }
    private static int GetNextBytes(int startIndex)
    {
        if (index )

    }
}