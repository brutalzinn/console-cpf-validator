using System;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace testeValidators
{
    internal class Program
    {
        // THIS IS A CUSTOM FUNCTION TO CHECK CPF VALIDATION. FEEL FREE TO CLONE AND CONTRIBUITE.
        // THIS PROJECT IS WILL BE USED WITH CHALLENGER TARGET API
        // THANKS TO http://www.macoratti.net/alg_cpf.htm
        static int CheckDivision(int value)
        {
            int result = value % 11;

            if (result < 2)
            {
                return 0;
            }
            else if(result >= 2)
            {
                return 11 - result;
            }
            return 0;
        }
        static int CalcPeso(string CPF, int Peso)
        {
            int Calc = 0;
            foreach (var digit in CPF)
            {
                Calc += (int)Char.GetNumericValue(digit) * Peso;

                if (Peso == 2)
                {

                    break;
                }
                Peso--;
            }
            return Calc;
        }

        static bool CheckCpf(int Vone, int VTwo, string CPF)
        {
            int VerifierOne = (int)Char.GetNumericValue(CPF[CPF.Length - 2]);
            int VerifierTwo = (int)Char.GetNumericValue(CPF[CPF.Length - 1]);

            if (VerifierOne == Vone && VerifierTwo == VTwo)
            {
                return true;
            }
            else
            {
                return false;
            }
          

        }
        public static string Salinizator(string cpf)
        {
            return Regex.Replace(cpf, @"[^a-z0-9_]+", "");
        }
        static void Main(string[] args)
        {
    
             
            string CPFOriginal = Salinizator("000.000.000-00");
            Console.WriteLine(CPFOriginal);
            string CPF = CPFOriginal.Substring(0, CPFOriginal.Length - 2);


            int Calc;
            int FDigit;
            int SDigit;

            Calc = CalcPeso(CPF, 10);
            FDigit = CheckDivision(Calc);
            Calc = CalcPeso($"{CPF}{FDigit}", 11);
            SDigit = CheckDivision(Calc);
            Console.WriteLine($"{FDigit}-{SDigit}");
            Console.WriteLine($"RESULT:{CheckCpf(FDigit, SDigit, CPFOriginal)}");

        }
    }
}
