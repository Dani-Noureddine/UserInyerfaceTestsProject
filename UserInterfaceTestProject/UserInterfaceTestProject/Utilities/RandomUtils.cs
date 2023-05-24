
using Aquality.Selenium.Core.Configurations;
using Aquality.Selenium.Core.Utilities;

namespace UserInterfaceTestProject 
{ 
    public static class RandomUtils
    {
        private static ISettingsFile TestData => new JsonSettingsFile("testData.json");
        public static string GenerateRandomValidPassword()
        {
            Random random = new Random();
            int numOfSmallLetters =random.Next(3, 8);
            int numOfCapitalLetters = random.Next(3, 8);
            int numOfNumbers = random.Next(4, 8);
            return GenerateSmallLetters(numOfSmallLetters)+GenerateCapitalLetters(numOfCapitalLetters)
                +GenerateNumbers(numOfNumbers);
        }
        public static string GenerateRandomEmail()
        {
            Random random=new Random();
            int lengthOfString = random.Next(1, TestData.GetValue<int>("MaxNumberOfCharsInEmail"));
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            for (int i = 0; i < lengthOfString; i++)
            {
                result += chars[random.Next(chars.Length)];
            }
            return result;
        }
        public static string GenerateRandomDomain()
        {
            Random random = new Random();
            int lengthOfString = random.Next(1, TestData.GetValue<int>("MaxNumberOfCharsInDomain"));
            string chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            for (int i = 0; i < lengthOfString; i++)
            {
                result += chars[random.Next(chars.Length)];
            }
            return result;
        }
        public static int[] GetRandomInterestIndex()
        {
            Random random = new Random();
            int totalNumOfInterests =TestData.GetValue<int>("NumberOfInterests");
            int indexOfUnselectAll = TestData.GetValue<int>("IndexOfUnselectAll");
            int indexOfSelectAll = TestData.GetValue<int>("IndexOfSelectAll");
            int[] randomInterestIndexes = new int[3];
            int a;
            int b;
            int c;
            do
            {
                a = random.Next(1, totalNumOfInterests);
                b = random.Next(1, totalNumOfInterests);
                c = random.Next(1, totalNumOfInterests);
            } while (a == b || a == c || b == c || a==indexOfSelectAll ||a==indexOfUnselectAll || b == indexOfSelectAll || 
            b == indexOfUnselectAll || c == indexOfSelectAll || c == indexOfUnselectAll);
            randomInterestIndexes[0] = a;
            randomInterestIndexes[1] = b;
            randomInterestIndexes[2] = c;
            return randomInterestIndexes;
        }
        public static int GenerateRandomExtensionIndex()
        {
            Random random = new Random();
            int totalNumOfExtensions = TestData.GetValue<int>("TotalNumberOfExtensionsInDropdown");
            return random.Next(2, totalNumOfExtensions+1); //+1 as the max in random.Next is not included in the range
        }
        private static string GenerateSmallLetters(int amount)
        {
            Random random= new Random();
            string smallLetters = "abcdefghijklmnopqrstuvwxyz";
            string result= "";
            for (int i =0; i < amount; i++)
            {
                result += smallLetters[random.Next(smallLetters.Length)];
            }
            return result;
        }
        private static string GenerateCapitalLetters(int amount)
        {
            Random random = new Random();
            string capitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string result = "";
            for (int i = 0; i < amount; i++)
            {
                result += capitalLetters[random.Next(capitalLetters.Length)];
            }
            return result;
        }
        private static string GenerateNumbers(int amount)
        {
            Random random = new Random();
            string numbers = "0123456789";
            string result = "";
            for (int i = 0; i < amount; i++)
            {
                result += numbers[random.Next(numbers.Length)];
            }
            return result;
        }
    }
}
