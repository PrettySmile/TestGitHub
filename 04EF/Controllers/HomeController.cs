using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _04EF.Models;

namespace _04EF.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        //整數陣列遞減排序
        public string ShowArrayDesc()
        {
            int[] score = { 78, 99, 20, 100, 0, 66, 95, 45 };
            string show = "";
            //把score當欄位，存到資料庫

            //Linq查詢運算式
            var result = from m in score
                           orderby m descending
                            select m;

            //Linq擴充
            var result2 = score.OrderByDescending(m=>m);

            show = "遞減排序：";
            foreach (var m in result) {
                show += m + ",";
            }
            show += "<br/>";
            show += "總合："+result.Sum();//使用Linq的Sum方法進行加總

            return show;
        }

        //整數陣列遞增排序
        public string ShowArrayAsc()
        {
            int[] score = { 78, 99, 20, 100, 0, 66, 95, 45 };
            string show = "";
            //把score當欄位，存到資料庫

            //Linq擴充方法寫法
            var result = score.OrderBy(m=>m);

            //Linq查詢運算式
            var result2 = from m in score
                         orderby m ascending
                         select m;

            show = "遞增排序：";
            foreach (var m in result)
            {
                show += m + ",";
            }
            show += "<br/>";
            show += "平均："+result.Average();

            return show;
        }

        public string LoginMember(string uid,string pwd)
        {
            Member[] members = new Member[] {
                new Member{ UId="tom",Pwd="123",Name="湯姆"},
                new Member{ UId="jpsper",Pwd="456",Name="賈思伯"},
                new Member{ UId="mary",Pwd="789",Name="瑪麗"}
            };

            //Linq擴充方法寫法
            var result = members.Where(m=>m.UId==uid && m.Pwd==pwd).FirstOrDefault();

            //Linq查詢運算式寫法
            var result2 = (from m in members
                     where m.UId == uid && m.Pwd == pwd
                     select m).FirstOrDefault();

            string show = "";
            if (result != null)
            {
                show = result.Name += "歡迎進入系統!!";
            }
            else
            {
                show = "帳號或密碼錯誤!!";
            }

            return show;
        }

    }
}