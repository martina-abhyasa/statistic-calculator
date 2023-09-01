using System;
using System.Text;


namespace StatisticCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Provide values separated by comma: ");
            string[] values = Console.ReadLine().Split(',');  //split string into array by comma

            double[] valuesArray = new double[values.Length];   //new double array -> valuesArray
            for (int i = 0; i < values.Length; i++)
            {
                valuesArray[i] = Convert.ToDouble(values[i]); //each string element from values array convert to double
            }

                                    // STATISTIC CALCULATOR - options
            Console.WriteLine("\n"); 
            Console.WriteLine("--------------------------------------------------------------------------\n");

            Console.WriteLine("See the options below and choose calculator by entered appropriate number: \n" +
                "1 Minimum \n" +
                "2 Maximum \n" +
                "3 Sorted Data in Ascending Order \n" +
                "4 Sorted Data in Descending Order \n" +
                "5 Sum \n" +
                "6 Sample Mean \n" +
                "7 Sample Standard Deviation \n" +
                "8 Sample Variance \n" +
                "9 Geometric Mean \n" +
                "10 Count \n");


            Console.WriteLine("--------------------------------------------------------------------------\n");
            Console.Write("Enter number: ");


            int option = Convert.ToInt32(Console.ReadLine()); 

            switch (option)
            {
                case 1:
                    Console.Write("Minimum: {0}", Minimum(valuesArray));
                    break;

                case 2:
                    Console.Write("Maksimum: {0}", Maximum(valuesArray));
                    break;

                case 3:
                    Console.WriteLine("Sorted Data in Ascending Order: {0}", SortAscendingOrder(valuesArray));
                    break;
                case 4:
                    Console.WriteLine("Sorted Data in Descending Order: {0}", SortDescendingOrder(valuesArray));
                    break;
                case 5:
                    Console.Write("Sum: {0}", Sum(valuesArray));
                    break;
                case 6:
                    Console.Write("Sample Mean: {0}", SampleMean(valuesArray));
                    break;
                case 7:
                    Console.Write("Sample Standard Deviation: {0}", SampleStandardDeviation(valuesArray));
                    break;
                case 8:
                    Console.Write("Sample Variance: {0}", SampleVariance(valuesArray));
                    break;
                case 9:
                    Console.Write("Geometric Mean: {0}", GeometricMean(valuesArray));
                    break;
                case 10:
                    Console.Write("Count: {0}", Count(valuesArray));
                    break;
                default:
                    Console.WriteLine("Error -> the entered number is incorrect!");
                    break;
            }

            Console.WriteLine("\n");
            Console.WriteLine("--------------------------------------------------------------------------\n");
            Console.Write("For whole set of calculators enter YES; For exit, enter NO: ");


            string answer = Console.ReadLine();
            char[] t = answer.ToCharArray();                                  // we convert string answer to array of characters
                                                                              // in order to go through each element of char array and convert each char:
            for (int i = 0; i < t.Length; i++) { t[i] = char.ToLower(t[i]); } // we convert all letters to lowercase
            string answerString = new string(t);                              // convert char array t to string -> answerString (consists of lowercases)
             

            if (answerString == "yes")
            {
                Console.WriteLine("");
                Console.WriteLine("     STATISTIC CALCULATOR");
                Console.WriteLine(" Count: {0}", Count(valuesArray));
                Console.WriteLine(" Minimum: {0}", Minimum(valuesArray));
                Console.WriteLine(" Maximum: {0}", Maximum(valuesArray));

                Console.WriteLine(" Sum: {0,5:0.00}", Sum(valuesArray));
                Console.WriteLine(" Sample Mean: {0,5:0.00}", SampleMean(valuesArray));
                Console.WriteLine(" Sample Standard Deviation: {0,5:0.00}", SampleStandardDeviation(valuesArray));
                Console.WriteLine(" Sample Variance: {0,5:0.00}", SampleVariance(valuesArray));
                Console.WriteLine(" Geometric Mean: {0,5:0.00}", GeometricMean(valuesArray));

                Console.WriteLine(" Ascending Order: {0,5}", SortAscendingOrder(valuesArray));
                Console.WriteLine(" Descending Order: {0,5}", SortDescendingOrder(valuesArray));


            }
            else { Console.Clear(); }


            Console.ReadLine();

        }

        // we create some methods that we can use to calculate statistics:

        static double Minimum(double[] a)
        {
            double min = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] < min)
                {
                    min = a[i];
                }
            }

            return min;
        }

        static double Maximum(double[] a)
        {
            double max = a[0];
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > max)
                {
                    max = a[i];
                }
            }

            return max;
        }

        static double Sum(double[] a)
        {
            double sum = 0.0;
            for (int i = 0; i < a.Length; i++) { sum = sum + a[i]; }

            return sum;
        }

        static int Count(double[] a)
        {
            int count = 0;
            foreach (double value in a) { count++; }

            return count;
        }

        static double SampleMean(double[] a)
        {
            double mean = Sum(a) / Count(a);
            return mean;
        }

        static double SampleVariance(double[] a)
        {
            double sum = 0.0;
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                sum = sum + Math.Pow(a[i] - SampleMean(a), 2);
            }

            double sampleVar = sum / (n - 1);
            return sampleVar;
        }

        static double SampleStandardDeviation(double[] a)
        {
            double sampleDev = Math.Sqrt(SampleVariance(a));
            return sampleDev;
        }

        static double GeometricMean(double[] a)
        {
            double product = 1;
            double n = a.Length;

            for (int i = 0; i < n; i++)
            {
                product = product * a[i];
            }

            double result = Math.Pow(product, 1 / n);
            return result;
        }

        static string SortAscendingOrder(double[] a)
        {
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] < a[i])
                    {
                        double temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;

                    }
                }
            }

            int z = 0;

            StringBuilder t = new StringBuilder();

            while (z < n)
            {
                double number = a[z];
                string numberString = number.ToString();
                t.Append(numberString + " ");
                z++;
            }
            string s = t.ToString();
            return s;
        }


        static string SortDescendingOrder(double[] a)
        {
            int n = a.Length;

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (a[j] > a[i])
                    {
                        double temp = a[i];
                        a[i] = a[j];
                        a[j] = temp;

                    }
                }
            }

            int z = 0;

            StringBuilder t = new StringBuilder();

            while (z < n)
            {
                double number = a[z];
                string numberString = number.ToString();
                t.Append(numberString + " ");
                z++;
            }

            string s = t.ToString();
            return s;
        }

    }
}
