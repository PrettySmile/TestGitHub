using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPnet.Controllers
{
    public class Homework_F_Controller : Controller
    {

        public void a()
        {
            int a = 10;
            aa(ref a);
            //ref:call by refrence傳址
            //架構好
            //效能好
            //不浪費記憶體空間
        }

        public void aa(ref int a)
        {
            a += 10;
        }



        public void q1()
        {
            int[] totalPokerArr = generatePoker();
            randomPoker(ref totalPokerArr);
            deal(ref totalPokerArr);
        }

        private int[] generatePoker()
        {
            int[] totalPokerArr = new int[52];
            for (int i = 0; i < 52; i++)
            {
                totalPokerArr[i] = i + 1;                
            }
            return totalPokerArr; 
        }

        private void randomPoker(ref int[] totalPokerArr)
        {
            Random random = new Random();
            int randomIndex;
            for (int i = 0; i < totalPokerArr.Length; i++)
            {
                randomIndex = random.Next(0, totalPokerArr.Length);
                int temp = totalPokerArr[i];                
                totalPokerArr[i] = totalPokerArr[randomIndex];
                totalPokerArr[randomIndex] = temp;
            }
        }

        private void deal(ref int[] totalPokerArr)
        {
            int[] p1 = new int[13];
            int[] p2 = new int[13];
            int[] p3 = new int[13];
            int[] p4 = new int[13];
            int p, n;
            for (int i = 0; i < totalPokerArr.Length; i++)
            {
                p = i % 4;
                n = i / 4;
                switch (p)
                {
                    case 0:
                        p1[n] = i;
                        break;
                    case 1:
                        p2[n] = i;
                        break;
                    case 2:
                        p3[n] = i;
                        break;
                    case 3:
                        p4[n] = i;
                        break;
                }
            }

            Response.Write("<br/>第1位玩家");
            print(ref totalPokerArr, ref p1);
            Response.Write("<br/>第2位玩家");
            print(ref totalPokerArr, ref p2);
            Response.Write("<br/>第3位玩家");
            print(ref totalPokerArr, ref p3);
            Response.Write("<br/>第4位玩家");
            print(ref totalPokerArr, ref p4);
        }

        private void print(ref int[] totalPoker,ref int[] personPokerIndex)
        {
            for (int i = 0; i < personPokerIndex.Length; i++)
            {
                Response.Write("<img src='../poker_img/" + totalPoker[personPokerIndex[i]] + ".gif'/>");
            }
        }

    }
}