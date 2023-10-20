using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.CodeDom;
using Microsoft.SqlServer.Server;
using System.CodeDom.Compiler;

namespace PMPHF005_JQ8Z8Z
{
    internal class Program
    {
        class assembly
        {
            int A;
            int B;
            int C;
            int D;
            public assembly(string temp)
            {
                string[] array = temp.Split(',');
                A = int.Parse(array[0]);
                B = int.Parse(array[1]);
                C = int.Parse(array[2]);
                D = int.Parse(array[3]);
            }
            public void MOV(string DEST, string SRC)
            {
                int temp = 0;
                if (SRC == "A") temp = A;
                if (SRC == "B") temp = B;
                if (SRC == "C") temp = C;
                if (SRC == "D") temp = D;
                if (SRC != "A" && SRC != "B" && SRC != "C" && SRC != "D") temp = int.Parse(SRC);

                if (DEST == "A") A = temp;
                if (DEST == "B") B = temp;
                if (DEST == "C") C = temp;
                if (DEST == "D") D = temp;
            }
            public void ADD(string DEST, string SRC1, string SRC2)
            {
                int temp1 = 0;
                if (SRC1 == "A") temp1 = A;
                if (SRC1 == "B") temp1 = B;
                if (SRC1 == "C") temp1 = C;
                if (SRC1 == "D") temp1 = D;
                if (SRC1 != "A" && SRC1 != "B" && SRC1 != "C" && SRC1 != "D") temp1 = int.Parse(SRC1);

                int temp2 = 0;
                if (SRC2 == "A") temp2 = A;
                if (SRC2 == "B") temp2 = B;
                if (SRC2 == "C") temp2 = C;
                if (SRC2 == "D") temp2 = D;
                if (SRC2 != "A" && SRC2 != "B" && SRC2 != "C" && SRC2 != "D") temp2 = int.Parse(SRC2);

                if (DEST == "A") A = temp1 + temp2;
                if (DEST == "B") B = temp1 + temp2;
                if (DEST == "C") C = temp1 + temp2;
                if (DEST == "D") D = temp1 + temp2;
            }
            public void SUB(string DEST, string SRC1, string SRC2)
            {
                int temp1 = 0;
                if (SRC1 == "A") temp1 = A;
                if (SRC1 == "B") temp1 = B;
                if (SRC1 == "C") temp1 = C;
                if (SRC1 == "D") temp1 = D;
                if (SRC1 != "A" && SRC1 != "B" && SRC1 != "C" && SRC1 != "D") temp1 = int.Parse(SRC1);

                int temp2 = 0;
                if (SRC2 == "A") temp2 = A;
                if (SRC2 == "B") temp2 = B;
                if (SRC2 == "C") temp2 = C;
                if (SRC2 == "D") temp2 = D;
                if (SRC2 != "A" && SRC2 != "B" && SRC2 != "C" && SRC2 != "D") temp2 = int.Parse(SRC2);

                if (DEST == "A") A = temp1 - temp2;
                if (DEST == "B") B = temp1 - temp2;
                if (DEST == "C") C = temp1 - temp2;
                if (DEST == "D") D = temp1 - temp2;
            }
            public int JNE(string DEST, string SRC1, string SRC2)
            {
                int temp = 0;
                if(SRC1 == "A") temp = A;
                if(SRC1 == "B") temp = B;
                if(SRC1 == "C") temp = C;
                if(SRC1 == "D") temp = D;
                if (SRC1 != "A" && SRC1 != "B" && SRC1 != "C" && SRC1 != "D") temp = int.Parse(SRC1);

                if (int.Parse(SRC2) != temp)
                {
                    return int.Parse(DEST);
                }
                else return -1;
            }
            public void OUTPUT()
            {
                StreamWriter sw = new StreamWriter("output.txt");
                sw.WriteLine("{0},{1},{2},{3}", A, B, C, D);
                sw.Close();
            }
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("input.txt");
            assembly assembly = new assembly(sr.ReadLine());
            string[] length = File.ReadAllLines("input.txt");
            string[] linesInOrder = new string[length.Length - 1];
            int index = 0;

            while (!sr.EndOfStream)
            {
                linesInOrder[index] = sr.ReadLine();
                index++;
            }
            sr.Close();

            int i = 0;
            for (; i < linesInOrder.Length; i++)
            {
                if (linesInOrder[i].Split(' ')[0] == "MOV")
                {
                    assembly.MOV(linesInOrder[i].Split(' ')[1], linesInOrder[i].Split(' ')[2]);
                }
                if (linesInOrder[i].Split(' ')[0] == "ADD")
                {
                    assembly.ADD(linesInOrder[i].Split(' ')[1], linesInOrder[i].Split(' ')[2], linesInOrder[i].Split(' ')[3]);
                }
                if (linesInOrder[i].Split(' ')[0] == "SUB")
                {
                    assembly.SUB(linesInOrder[i].Split(' ')[1], linesInOrder[i].Split(' ')[2], linesInOrder[i].Split(' ')[3]);
                }
                if (linesInOrder[i].Split(' ')[0] == "JNE")
                {
                    int temp = assembly.JNE(linesInOrder[i].Split(' ')[1], linesInOrder[i].Split(' ')[2], linesInOrder[i].Split(' ')[3]);
                    if (temp != -1) i = temp - 1;
                }
            }
            assembly.OUTPUT();
        }
    }
}
