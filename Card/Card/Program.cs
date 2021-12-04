using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Card
{
    internal class Program
    {
        static void PrintArray<T>(T [] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + "\t");
            }
        }

        static string [] DecodingCard(int [] arr)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string [] decodingArrCard = new string [arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                switch (arr[i] / 10)
                {
                    case 1: decodingArrCard[i] = "\u2665"; break;
                    case 2: decodingArrCard[i] = "\u2660"; break;
                    case 3: decodingArrCard[i] = "\u2663"; break;
                    case 4: decodingArrCard[i] = "\u2666"; break;
                }
                switch (arr[i] % 10)
                {
                    case 1: decodingArrCard[i] += "6"; break;
                    case 2: decodingArrCard[i] += "7"; break;
                    case 3: decodingArrCard[i] += "8"; break;
                    case 4: decodingArrCard[i] += "9"; break;
                    case 5: decodingArrCard[i] += "10"; break;
                    case 6: decodingArrCard[i] += "B"; break;
                    case 7: decodingArrCard[i] += "D"; break;
                    case 8: decodingArrCard[i] += "K"; break;
                    case 9: decodingArrCard[i] += "T"; break;
                }

            }
            return decodingArrCard;
        }

        static void Main(string[] args)
        {
            int[] ArrayCard = new int[36];
            string[] CardInHand = new string[6];
            Random random = new Random();

            for (int i = 0; i < 9; i++)
            {
                ArrayCard[i] = 10 + (i + 1);
                ArrayCard[9 + i] = 40 + (i + 1);
                ArrayCard[18 + i] = 30 + (i + 1);
                ArrayCard[27 + i] = 20 + (i + 1);
            }
            
            string[] deckOfCard = DecodingCard(ArrayCard);

            Console.WriteLine();

            for (int i = 0; i < CardInHand.Length; i++)
            {
                int randCard = random.Next(ArrayCard.Length);
                CardInHand[i] = ArrayCard[randCard].ToString();
                ArrayCard.Where(number => number != ArrayCard[randCard]).ToArray();   
            }

            PrintArray(CardInHand);
            Console.WriteLine();

            CardInHand = DecodingCard(Array.ConvertAll(CardInHand, int.Parse));
            PrintArray(CardInHand);

            int mastPicaCounter = 0;

            for (int i = 0; i < CardInHand.Length; i++)
            {
                string check = CardInHand[i];   
                
                if (check[0] == '\u2660')
                {
                    mastPicaCounter++;
                }
            }
            Console.WriteLine();
            Console.WriteLine("Кiлькiсть карт мастi пiка : " + mastPicaCounter);

        }
    }
}
