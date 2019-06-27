using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
        
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {

            // Add your code here.
            var numbers=equation.Split("=")[0];
            var result=equation.Split("=")[1];
            var firstNumber=numbers.Split("*")[0];
            var secondNumber=numbers.Split("*")[1];
            var postition=0;
            var requiredNumber=0;
            var missingDigit=0;
            var product=0;
            if(firstNumber.Contains("?")){
                
                requiredNumber=Convert.ToInt32(result)/Convert.ToInt32(secondNumber);
                postition=firstNumber.IndexOf("?");
                missingDigit=requiredNumber.ToString()[postition];
                product=requiredNumber*Convert.ToInt32(secondNumber);
                if (requiredNumber.ToString().Length!=firstNumber.Length){
                    return -1;
                }

            }else if (secondNumber.Contains("?")){
                requiredNumber=Convert.ToInt32(result)/Convert.ToInt32(firstNumber);
                postition=secondNumber.IndexOf("?");
                missingDigit=requiredNumber.ToString()[postition];
                product=requiredNumber*Convert.ToInt32(firstNumber);
                if (requiredNumber.ToString().Length!=secondNumber.Length){
                    return -1;
                }
                
            }else{
                requiredNumber=Convert.ToInt32(firstNumber)*Convert.ToInt32(secondNumber);
                postition=result.IndexOf("?");
                missingDigit=requiredNumber.ToString()[postition];
                product=requiredNumber;
                return (int)Char.GetNumericValue(requiredNumber.ToString()[postition]);
            }
            if(postition==0 && (int)Char.GetNumericValue(requiredNumber.ToString()[postition])==0){
                    return -1;}
            else{
                if(product!=Convert.ToInt32(result)){
                    return -1;
                }else{
                    return (int)Char.GetNumericValue(requiredNumber.ToString()[postition]);
                }
            }            

            throw new NotImplementedException();
        }
    }
}
