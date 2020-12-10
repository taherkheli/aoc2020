namespace aoc.D01
{
  public static class Helper
  {
    private static int number = 2020;

    public static int Sum2(int[] input)
    {
      for (int i = 0; i < input.Length - 1; i++)
      {
        for (int j = i + 1; j < input.Length; j++)
        {
          if (input[i] + input[j] == number)
            return input[i] * input[j];
        }
      }

      return int.MinValue;
    }

    public static int Sum3(int[] input)
    {
      for (int i = 0; i < input.Length - 2; i++)
      {
        for (int j = i + 1; j < input.Length - 1; j++)
        {
          if (input[i] + input[j] < number + 1)
          {
            for (int k = j + 1; k < input.Length; k++)
            {
              if (input[i] + input[j] + input[k] == number)
                return input[i] * input[j] * input[k];
            }
          }
        }
      }

      return int.MinValue;
    }
  }
}
