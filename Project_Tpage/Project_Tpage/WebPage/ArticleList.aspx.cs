﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Tpage.Class;
namespace Project_Tpage.WebPage
{
    public partial class ArticleList : System.Web.UI.Page
    {
<<<<<<< HEAD
=======

>>>>>>> 8121cb08ff19d42cc620e1f56476230e59b053ec
        // 資料庫在這邊給資料。顯示於listbox
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Controller.IsConstrut)
            {
                //建構MVC
                Controller.Initial(Session["state"] == null ? StateEnum.Article : (StateEnum)Session["state"]);
            }
<<<<<<< HEAD
=======
            //Controller.model.RequestPageData(Controller.model.State);
            if (PageData.Out.ContainsKey("Board"))
                this.Title.Text = PageData.Out["Board"] as string;
>>>>>>> 8121cb08ff19d42cc620e1f56476230e59b053ec
        }

        // 選擇要看文章
        protected void SelectArticle(object sender, EventArgs e)
        {
            int index = this.ListOfArticle.SelectedIndex;
            Controller.controller.GetUserInput(ViewOp.Article_viewarticle);
            Response.Redirect("article.aspx");
        }
<<<<<<< HEAD
        protected void back_Click(object sender, EventArgs e)
        {

            Controller.controller.GetUserInput(ViewOp.ArticleList_back);
            Response.Redirect("BoardList.aspx");

=======

        // 返回看板
        protected void btnBack_Click(object sender, EventArgs e)
        {
            Controller.controller.GetUserInput(ViewOp.ArticleList_back);
            Response.Redirect("BoardList.aspx");
        }

        // 發新文章
        protected void btnPo_Click(object sender, EventArgs e)
        {
            Controller.controller.GetUserInput(ViewOp.Board_editarticle);
            Response.Redirect("editor.aspx");
>>>>>>> 8121cb08ff19d42cc620e1f56476230e59b053ec
        }
    }
}