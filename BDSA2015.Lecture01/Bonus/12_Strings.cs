namespace BDSA2015.Lecture01.Bonus
{
    public static class Strings
    {
        public static void Run()
        {
            int answer = 42;

            string concat = "The answer is " + answer; // implicit cast

            string format = string.Format("The answer is {0}", answer);

            string interpolation = $"The answer is {answer}";

            var array1 = new string[3];
            array1[0] = "a";
            array1[1] = "b";
            array1[2] = "c";
             
            var array2 = new[] { "a", "b", "c" }; // array initializer

            string[] array3 = {"a", "b", "c"}; // array initializer

            string concatenate = string.Concat(array1);

            string join = string.Join(",", array1);

            string empty = string.Empty;
        }
    }
}