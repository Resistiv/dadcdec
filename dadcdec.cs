using System;
using System.IO;

namespace DADCBarDecoder {
    public class Program {
        public static void Main(string[] args)
        {
            if(args.Length > 1 || args.Length < 1)
            {
                Console.WriteLine("[ERR] Invalid number of arguments");
                return;
            }
            else if(args[0].Length % 4 != 0)
            {
                Console.WriteLine("[ERR] Invalid number of barcode digits");
                return;
            }
            string rawBarcode = args[0];
            int blockCount = args[0].Length / 4;
            int[] blockedBarcode = new int[blockCount - 2];
            for(int i = 0; i < blockedBarcode.Length; i++)
            {
                blockedBarcode[i] = Convert.ToInt32(rawBarcode.Substring((i * 4) + 4, 4), 2);
                // Console.WriteLine(rawBarcode.Substring(i * 4, 4));
            }
            bool isChar = false;
            string decodedBarcode = "";
            for(int i = 0; i < blockedBarcode.Length; i++)
            {
                if(isChar)
                {
                    int charVal = Convert.ToInt32(rawBarcode.Substring(((i-1) * 4) + 4, 8), 2);
                    switch(charVal)
                    {
                        case 0xB0: { decodedBarcode += "A"; break; };
                        case 0xB1: { decodedBarcode += "B"; break; };
                        case 0xB2: { decodedBarcode += "C"; break; };
                        case 0xB3: { decodedBarcode += "D"; break; };
                        case 0xB4: { decodedBarcode += "E"; break; };
                        case 0xB5: { decodedBarcode += "F"; break; };
                        case 0xB6: { decodedBarcode += "G"; break; };
                        case 0xB7: { decodedBarcode += "H"; break; };
                        case 0xB8: { decodedBarcode += "I"; break; };
                        case 0xB9: { decodedBarcode += "J"; break; };
                        case 0xC0: { decodedBarcode += "K"; break; };
                        case 0xC1: { decodedBarcode += "L"; break; };
                        case 0xC2: { decodedBarcode += "M"; break; };
                        case 0xC3: { decodedBarcode += "N"; break; };
                        case 0xC4: { decodedBarcode += "O"; break; };
                        case 0xC5: { decodedBarcode += "P"; break; };
                        case 0xC6: { decodedBarcode += "Q"; break; };
                        case 0xC7: { decodedBarcode += "R"; break; };
                        case 0xC8: { decodedBarcode += "S"; break; };
                        case 0xC9: { decodedBarcode += "T"; break; };
                        case 0xD0: { decodedBarcode += "U"; break; };
                        case 0xD1: { decodedBarcode += "V"; break; };
                        case 0xD2: { decodedBarcode += "W"; break; };
                        case 0xD3: { decodedBarcode += "X"; break; };
                        case 0xD4: { decodedBarcode += "Y"; break; };
                        case 0xD5: { decodedBarcode += "Z"; break; };
                        case 0xD6: { decodedBarcode += "-"; break; };
                        default: { decodedBarcode += "|"; break; };
                    }
                    isChar = false;
                }
                else if(blockedBarcode[i] > 9)
                {
                    isChar = true;
                }
                else {
                    decodedBarcode += blockedBarcode[i].ToString();
                }
            }
            Console.WriteLine(decodedBarcode);
        }
    }
}