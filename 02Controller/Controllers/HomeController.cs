using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _02Controller.Controllers
{
    public class HomeController : Controller
    {
        public string ShowAry() {
            int[] score = { 78,99,20,100,66 };//把此陣列當做module回傳值
            string show = "";
            int sum = 0;
            foreach (var m in score) {//宣告m為動態型別
                show += m + ", ";
                sum += m;
            }
            show += "<hr>";
            show+= "總合:" + sum;
            return show;
        }

        string ShowAry2()//沒寫存取層級=private
        {
            int[] score = { 78, 99, 20, 100, 66 };
            string show = "";
            int sum = 0;
            foreach (var m in score)
            {
                show += m + ", ";
                sum += m;
            }
            show += "<hr>";
            show += "總合:" + sum;
            return show;
        }

        public string ShowImages()
        {
            string show = "";
            for(int i=1; i<9; i++)
            {
                show += "<img src='../images/"+i+".JPG' width='150' />";
            }            
            return show;
        }
        
        public string ShowImagesIndex(int index)
        {
            string[] name = { "櫻桃鴨","鴨油高麗菜","鴨油麻婆豆腐","櫻桃鴨握壽司","片皮鴨捲三星蔥","三杯鴨","櫻桃鴨片肉","慢火白菜燉鴨湯"};

            string show = string.Format("<p align='center'><img src='../images/{0}.JPG' /><br>{1}</p>",index,name[index-1]);
            //透過Format，可以用{}，而不用寫迴圈。

            return show;
        }

        //Q:將陣列從大到小排序
        public string ShowSortAry()
        {
            int[] score = { 78, 99, 20, 100, 66 };//把此陣列當做module回傳值

            //寫法一，氣泡排序法
            sortB2S(ref score);


            //寫法二，linq
            var s = from m in score
                    orderby m descending
                    select m;

            string show = "";
            foreach (var m in s)
            {//宣告m為動態型別
                show += m + ", ";
            }

            return show;
        }

        public int[] sortB2S(ref int[] score)
        {
            int temp;
            for(int i=0; i<score.Length; i++)
            {                
                for (int ii=0; ii<score.Length; ii++)
                {
                    if (i == ii) continue;
                    if (score[i] > score[ii])
                    {
                        temp = score[i];
                        score[i] = score[ii];
                        score[ii] = temp;
                    }
                }
            }
            return score;
        }

    }
}