﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project_Tpage.Class;
using System.Drawing;
namespace Project_Tpage.WebPage
{
    public partial class Home : System.Web.UI.Page
    {
        //  進去看板頁面
        public event ViewEventHandler ToBoard;
        
        //  進去申請看板頁面
        public event ViewEventHandler ToCreateBoard;

        //  進入設定
        public event ViewEventHandler ToSetBoard;

        //  進去廣告頁面
        public event ViewEventHandler ToAD;

        //  查詢看板
        public event ViewEventHandler DoSearch;

        //  抽卡
        public event ViewEventHandler DoCard;

        //  更改樣式
        public event ViewEventHandler DoStyle;

        //  接受邀請
        public event ViewEventHandler DoYesInvite;

        //  拒絕邀請
        public event ViewEventHandler DoNoInvite;

        //  事件的輸出結果
        public DAT optDAT;

        private Class.User user;

        //  初始化
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Controller.IsConstrut)
                Controller.Initial(StateEnum.Login);
            //讓Controller內的function訂閱這個頁面上的事件。
            //Do this in each Page_Load()
            Controller.controller.SubsribeEvent(this);
          
            user = Controller.CrossPageDAT["User"] as User;
            int style = 0;
            style=user.Usersetting.Viewstyle;
            ADimage.ImageUrl = "TakeShowingImage.aspx";
            // 邀請加入的看板名字
            List<string> boardQueuelistName = new List<string>();
            boardQueuelistName.Clear();
            boardQueuelistName = Controller.CrossPageDAT["FollowBoardQueueName"] as List<string>;

            int count = 0;
            foreach (string BID in user.FollowBoardQueue) {
                inviteList.Items.Add(new ListItem(boardQueuelistName[count], BID));
                count++;
            }

            ListOfBoard.Items.Clear();
            List<string> boardListValue = new List<string>();
            boardListValue.Clear();
            boardListValue = user.FollowBoard;

            List<string> boardListName = new List<string>();
            boardListName.Clear();
            boardListName = Controller.CrossPageDAT["BoardListName"] as List<string>;
            count = 0;
            foreach (string element in boardListValue)
            {
                ListOfBoard.Items.Add(new ListItem(boardListName[count], element));//照順序排value 0~...
                count++;
            }
            if (style == 0)
            {
                color.Style.Add("background-color", "lightblue");

                Color a = Color.Black;
                String border = "white";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                cardInfo.ForeColor = a;
                ListOfBoard.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "32.5%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "10%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "120px");
                ADimage.Style.Add("left", "55%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "450px");
                btnNew.Style.Add("left", "5%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "450px");
                btnCard.Style.Add("left", "25%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "475px");
                cardInfo.Style.Add("left", "35%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "450px");
                btnAD.Style.Add("left", "50%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "475px");
                StyleInfo.Style.Add("left", "62.5%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "475px");
                StyleList.Style.Add("left", "70%");

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "220px");
                btnBoard.Style.Add("left", "3%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "70px");
                btnSet.Style.Add("left", "30%");
                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "450px");
                inviteList.Style.Add("left", "85%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "460px");
                btnYes.Style.Add("left", "80%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "510px");
                btnNo.Style.Add("left", "80%");
            }
            else if (style == 1)
            {
                color.Style.Add("background-color", "black");
                Color a = Color.WhiteSmoke;
                String border = "DarkGray";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                ListOfBoard.ForeColor = a;
                cardInfo.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "32.5%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "10%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "120px");
                ADimage.Style.Add("left", "55%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "450px");
                btnNew.Style.Add("left", "5%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "450px");
                btnCard.Style.Add("left", "25%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "475px");
                cardInfo.Style.Add("left", "35%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "450px");
                btnAD.Style.Add("left", "50%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "475px");
                StyleInfo.Style.Add("left", "62.5%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "475px");
                StyleList.Style.Add("left", "70%");

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "220px");
                btnBoard.Style.Add("left", "3%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "70px");
                btnSet.Style.Add("left", "30%");
                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "450px");
                inviteList.Style.Add("left", "85%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "460px");
                btnYes.Style.Add("left", "80%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "510px");
                btnNo.Style.Add("left", "80%");
            }
            else
            {

                color.Style.Add("background-color", "BurlyWood");
                Color a = Color.BlueViolet;
                String border = "CadetBlue";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                ListOfBoard.ForeColor = a;
                cardInfo.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "35%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "35%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "450px");
                ADimage.Style.Add("left", "35%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "0px");
                btnNew.Style.Add("left", "0%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "80px");
                btnCard.Style.Add("left", "0%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "100px");
                cardInfo.Style.Add("left", "7.5%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "160px");
                btnAD.Style.Add("left", "0%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "240px");
                btnBoard.Style.Add("left", "25%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "240px");
                btnSet.Style.Add("left", "0%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "400px");
                StyleInfo.Style.Add("left", "0%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "430px");
                StyleList.Style.Add("left", "0%");

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "620px");
                inviteList.Style.Add("left", "0%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "620px");
                btnYes.Style.Add("left", "10%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "660px");
                btnNo.Style.Add("left", "10%");
            }
        }

        //  點選不同看板進入
        protected void SelectBoard(object sender, EventArgs e)
        {
            //不做事
        }
        
        //  進入申請
        protected void btnNew_Click(object sender, EventArgs e)
        {
            ToCreateBoard(new ViewEventArgs(this), out optDAT);
        }
        //進入按鈕
        protected void btnboard_Click(object sender, EventArgs e)
        {
            DAT dat = new DAT();
            dat["BID"] = ListOfBoard.SelectedValue;
            ToBoard(new ViewEventArgs(dat, this), out optDAT);
        }
        //  抽卡,回傳資訊顯示於cardInfo
        protected void btnCard_Click(object sender, EventArgs e)
        {
            DoCard(new ViewEventArgs(this),out optDAT);
            cardInfo.Text = optDAT["Info"] as string;
        }

        //  送出查詢資料
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DAT dat = new DAT();
            dat["Search"] = searchText.Text;
            DoSearch(new ViewEventArgs(dat, this), out optDAT);
        }

        //  前往廣告頁面
        protected void btnAD_Click(object sender, EventArgs e)
        {
            ToAD(new ViewEventArgs(this), out optDAT);
        }

        //  更改顯示樣式 存入view模式
        protected void StyleChanged(object sender, EventArgs e)
        {
            DAT dat = new DAT();
            int stylevalue = StyleList.SelectedIndex;
            dat["Style"] = stylevalue;
            DoStyle(new ViewEventArgs(dat, this), out optDAT);
            if (stylevalue == 0)
            {
                color.Style.Add("background-color", "lightblue");

                Color a = Color.Black;
                String border = "white";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                cardInfo.ForeColor = a;
                ListOfBoard.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "32.5%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "10%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "120px");
                ADimage.Style.Add("left", "55%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "450px");
                btnNew.Style.Add("left", "5%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "450px");
                btnCard.Style.Add("left", "25%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "475px");
                cardInfo.Style.Add("left", "35%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "450px");
                btnAD.Style.Add("left", "50%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "475px");
                StyleInfo.Style.Add("left", "62.5%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "475px");
                StyleList.Style.Add("left", "70%");

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "220px");
                btnBoard.Style.Add("left", "3%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "70px");
                btnSet.Style.Add("left", "30%");
                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "450px");
                inviteList.Style.Add("left", "85%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "460px");
                btnYes.Style.Add("left", "80%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "510px");
                btnNo.Style.Add("left", "80%");
            }
            else if (stylevalue == 1)
            {
                color.Style.Add("background-color", "black");
                Color a = Color.WhiteSmoke;
                String border = "DarkGray";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                ListOfBoard.ForeColor = a;
                cardInfo.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "32.5%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "10%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "120px");
                ADimage.Style.Add("left", "55%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "450px");
                btnNew.Style.Add("left", "5%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "450px");
                btnCard.Style.Add("left", "25%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "475px");
                cardInfo.Style.Add("left", "35%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "450px");
                btnAD.Style.Add("left", "50%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "475px");
                StyleInfo.Style.Add("left", "62.5%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "475px");
                StyleList.Style.Add("left", "70%");

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "220px");
                btnBoard.Style.Add("left", "3%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "70px");
                btnSet.Style.Add("left", "30%");
                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "450px");
                inviteList.Style.Add("left", "85%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "460px");
                btnYes.Style.Add("left", "80%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "510px");
                btnNo.Style.Add("left", "80%");
            }
            else
            {

                color.Style.Add("background-color", "BurlyWood");
                Color a = Color.BlueViolet;
                String border = "CadetBlue";
                Title.ForeColor = a;
                searchText.ForeColor = a;
                StyleList.ForeColor = a;
                StyleInfo.ForeColor = a;
                btnSearch.ForeColor = a;
                btnNew.ForeColor = a;
                btnAD.ForeColor = a;
                searchresult.ForeColor = a;
                btnCard.ForeColor = a;
                ListOfBoard.ForeColor = a;
                cardInfo.ForeColor = a;
                btnBoard.ForeColor = a;
                btnSet.ForeColor = a;
                btnSet.Style.Add("background-color", border);
                btnBoard.Style.Add("background-color", border);
                btnAD.Style.Add("background-color", border);
                btnCard.Style.Add("background-color", border);
                btnNew.Style.Add("background-color", border);
                btnSearch.Style.Add("background-color", border);
                searchText.Style.Add("background-color", border);
                ListOfBoard.Style.Add("background-color", border);
                boardText.Style.Add("background-color", border);
                StyleList.Style.Add("background-color", border);

                Title.Style.Add("position", "absolute");
                Title.Style.Add("top", "10px");
                Title.Style.Add("left", "45%");

                searchText.Style.Add("position", "absolute");
                searchText.Style.Add("top", "70px");
                searchText.Style.Add("left", "35%");

                btnSearch.Style.Add("position", "absolute");
                btnSearch.Style.Add("top", "70px");
                btnSearch.Style.Add("left", "65%");

                searchresult.Style.Add("position", "absolute");
                searchresult.Style.Add("top", "80px");
                searchresult.Style.Add("left", "72.5%");

                ListOfBoard.Style.Add("position", "absolute");
                ListOfBoard.Style.Add("top", "120px");
                ListOfBoard.Style.Add("left", "35%");

                ADimage.Style.Add("position", "absolute");
                ADimage.Style.Add("top", "450px");
                ADimage.Style.Add("left", "35%");

                btnNew.Style.Add("position", "absolute");
                btnNew.Style.Add("top", "0px");
                btnNew.Style.Add("left", "0%");

                btnCard.Style.Add("position", "absolute");
                btnCard.Style.Add("top", "80px");
                btnCard.Style.Add("left", "0%");

                cardInfo.Style.Add("position", "absolute");
                cardInfo.Style.Add("top", "100px");
                cardInfo.Style.Add("left", "7.5%");

                btnAD.Style.Add("position", "absolute");
                btnAD.Style.Add("top", "160px");
                btnAD.Style.Add("left", "0%");

                btnBoard.Style.Add("position", "absolute");
                btnBoard.Style.Add("top", "240px");
                btnBoard.Style.Add("left", "25%");

                btnSet.Style.Add("position", "absolute");
                btnSet.Style.Add("top", "240px");
                btnSet.Style.Add("left", "0%");

                StyleInfo.Style.Add("position", "absolute");
                StyleInfo.Style.Add("top", "400px");
                StyleInfo.Style.Add("left", "0%");

                StyleList.Style.Add("position", "absolute");
                StyleList.Style.Add("top", "430px");
                StyleList.Style.Add("left", "0%");         

                boardText.Style.Add("position", "absolute");
                boardText.Style.Add("top", "540px");
                boardText.Style.Add("left", "20%");

                inviteList.Style.Add("position", "absolute");
                inviteList.Style.Add("top", "620px");
                inviteList.Style.Add("left", "0%");
                btnYes.Style.Add("position", "absolute");
                btnYes.Style.Add("top", "620px");
                btnYes.Style.Add("left", "10%");
                btnNo.Style.Add("position", "absolute");
                btnNo.Style.Add("top", "660px");
                btnNo.Style.Add("left", "10%");
            }
        }
        protected void btnset_Click(object sender, EventArgs e)
        {
            ToSetBoard(new ViewEventArgs(this), out optDAT);
        }

        protected void inviteList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnYes_Click(object sender, EventArgs e)
        {
            DAT dat = new DAT();
            dat["BID"] = user.FollowBoardQueue[inviteList.SelectedIndex];
            DoYesInvite(new ViewEventArgs(dat, this), out optDAT);
        }

        protected void btnNo_Click(object sender, EventArgs e)
        {
            DAT dat = new DAT();
            dat["BID"] = user.FollowBoardQueue[inviteList.SelectedIndex];
            DoNoInvite(new ViewEventArgs(dat, this), out optDAT);
        }
    }
}