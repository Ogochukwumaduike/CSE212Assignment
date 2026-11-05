public static class Arrays
{
    /// <summary>
    /// This function will create an array of size 'length' starting with 'number' followed by multiples of 'number'. Take for 
    /// example, Multiples of(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {

        // Plan:
        // 1. I Create a new array with the specified length.
        // 2. Use a "for" loop to go through each position in the array.
        // 3. Multiply the starting number by the current position plus one.
        // 4. Store the calculated multiple in the current array position.
        // 5. Return the completed array.

        double[] multiples = new double[length];

        for (int i = 0; i < length; i++)
        {
            multiples[i] = number * (i + 1);
        }

        return multiples;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list instead of returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {

        // Plan:
        // 1. I calculate the starting index of the elements that need to move to the beginning.
        // 2. Use GetRange() to copy the last 'amount' elements into a temporary list.
        // 3. Use RemoveRange() to remove those elements from the original list.
        // 4. Use InsertRange() to insert the temporary list at index 0.
        // 5. The original list will is now suposed to be rotated to the right by the specified amount.

        int startIndex = data.Count - amount;

        List<int> lastElements = data.GetRange(startIndex, amount);

        data.RemoveRange(startIndex, amount);

        data.InsertRange(0, lastElements);
    }
}