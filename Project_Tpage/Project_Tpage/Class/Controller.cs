﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Project_Tpage.WebPage;

namespace Project_Tpage.Class
{
    public class Controller
    {
        public static Controller controller { get; set; }
        public static Model model { get; set; }
        public static View view { get; set; }
        /// <summary>
        /// 指出控制器是否已建構的旗標。
        /// </summary>
        public static bool IsConstrut = false;
        /// <summary>
        /// 提供跨頁面的資料傳輸途徑。
        /// </summary>
        public static DAT CrossPageDAT { get; set; }

        public Controller()
        {

        }

        public static void Initial(StateEnum state)
        {
            model = new Model("");
            view = new View();
            controller = new Controller();

            IsConstrut = true;
            CrossPageDAT = null;

            model.State = state;
        }

        /// <summary>
        /// 註冊在p頁面上的事件。
        /// </summary>
        /// <param name="p">目標頁面。</param>
        public void SubsribeEvent(Page p)
        {
            //將在頁面內設計好的事件在此註冊。

            if (p is Login)             // Login State
            {
                (p as Login).DoLogin += LoginState_Login;
                (p as Login).ToRegister += LoginState_ToRegister;
            }
            else if (p is Register)     // Register State
            {
                (p as Register).DoRegister += RegisterState_Register;
                (p as Register).ToBack += RegisterState_ToBack;
            }
            else if (p is Home)         //  Home State
            {
                (p as Home).ToBoard += HomeState_ToBoard;
                (p as Home).ToCreateBoard += HomeState_ToCreateBoard;
                (p as Home).ToAD += HomeState_ToAD;
                (p as Home).DoSearch += HomeState_DoSearch;
                (p as Home).DoCard += HomeState_DoCard;
                (p as Home).DoStyle += HomeState_DoStyle;
            }
            else if (p is Board)        //  Board State
            {
                //(p as Board).ToArticle += BoardState_ToArticle;
                //(p as Board).ToEditor += BoardState_ToEditor;
                //(p as Board).ToBack += BoardState_ToBack;
                //(p as Board).DoFollow += BoardState_DoFollow;
            }
            else if (p is CreateBoard)  //  Create Board State
            {
                //(p as CreateBoard).DoCreate += CreateBoardState_DoCreate;
                //(p as CreateBoard).DoInvite += CreateBoardState_DoInvite;
                //(p as CreateBoard).ToHome += CreateBoardState_ToHome;
            }
            else if (p is WebPage.Article)      //  Article State
            {
                //(p as Article).DoMessage += ArticleState_DoMessage;
                //(p as Article).DoLike += ArticleState_DoLike;
                //(p as Article).ToBack += ArticleState_ToBack;
                //(p as Article).ToHome += ArticleState_ToHome;
            }
            else if (p is Editor)       //  Editor State
            {
                //(p as Editor).ToBack += EditorState_ToBack;
                //(p as Editor).DoCreate += EditorState_DoCreate;
            }
            else if (p is AD)           //  AD State
            {
                //(p as AD).ToHome += EditorState_ToHome;
                //(p as AD).DoBuy += EditorState_DoBuy;
            }
        }
        //  Login State
        public void LoginState_Login(ViewEventArgs e, out DAT opt)
        {
            //取得帳號與密碼
            string ID = e.data["ID"] as string;
            string Password = e.data["Password"] as string;

            //設定錯誤資訊。
            string failinfo = "";
            try
            {
                //嘗試登入
                model.Login(ID, Password);
            }
            catch (ModelException me)
            {
                //登入失敗則說明錯誤資訊。
                if (me.ErrorNumber == ModelException.Error.LoginFailed)
                    failinfo = me.userMessage == "" ? "登入失敗" : me.userMessage;
            }
            catch (Exception)
            {
                failinfo = "登入失敗";
            }


            //若無錯誤資訊，則為成功登入，切換至Home state
            if (failinfo == "")
            {
                opt = model.RequestPageData(StateEnum.Home, e.data);

                //頁面切換至HomePage
                //page.Response.Redirect("");
            }
            else//否則為登入失敗，重回Login state
            {
                opt = model.RequestPageData(StateEnum.Login, e.data);

                opt["failinfo"] = failinfo;
            }
        }
        public void LoginState_ToRegister(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Register, e.data);
        }
        
        //  Register State
        public void RegisterState_Register(ViewEventArgs e, out DAT opt)
        {
            //建構新的使用者資訊
            UserInfo uif = UserInfo.New;

            //設定欄位
            uif.ID = e.data["Id"] as string;
            uif.Password = e.data["Password"] as string;
            uif.Email = e.data["Email"] as string;
            uif.StudentID = e.data["StudentID"] as string;

            //設定錯誤資訊。
            string failinfo = "";
            try
            {
                //嘗試註冊新的使用者。
                model.Register(uif);
            }
            catch (ModelException me) when (me.ErrorNumber == ModelException.Error.InvalidUserInformation)
            {
                failinfo = me.userMessage;
            }
            catch (Exception)
            {
                failinfo += "註冊失敗。";
            }


            if (failinfo == "")
            {
                opt = model.RequestPageData(StateEnum.Login, e.data);
            }
            else
            {
                opt = model.RequestPageData(StateEnum.Register, e.data);

                opt["failinfo"] = failinfo;
            }
        }
        public void RegisterState_ToBack(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Login, e.data);
        }

        //  Home State
        public void HomeState_ToBoard(ViewEventArgs e, out DAT opt) {
            opt = model.RequestPageData(StateEnum.Board, e.data);
        }
        public void HomeState_ToCreateBoard(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.CreateBoard, e.data);
        }
        public void HomeState_ToAD(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.AD, e.data);
        }
        public void HomeState_DoSearch(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Board, e.data);
        } 
        public void HomeState_DoCard(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }
        public void HomeState_DoStyle(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }

        //  Board State
        public void BoardState_ToArticle(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Article, e.data);
        }
        public void BoardState_ToEditor(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.EditArticle, e.data);
        }
        public void BoardState_ToBack(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }
        public void BoardState_DoFollow(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Board, e.data);
        }

        //  Create Board State
        public void CreateBoardState_DoCreate(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }
        public void CreateBoardState_DoInvite(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.CreateBoard, e.data);
        }
        public void CreateBoardState_ToHome(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }

        //  Article State
        public void ArticleState_DoMessage(ViewEventArgs e, out DAT opt)
        {
            AMessage message = e.data["Message"] as AMessage;
            //設定錯誤資訊。
            string failinfo = "";
            try
            {
                //嘗試留言
                model.ReleaseAMessage(message.Content, message.OfArticle);
               
                opt = model.RequestPageData(StateEnum.Article, e.data);
                model.State = StateEnum.Board;
            }
            catch (ModelException me)
            {
                failinfo = me.userMessage == "" ? "留言失敗" : me.userMessage;
                opt = model.RequestPageData(StateEnum.Article, e.data);
                opt["failinfo"] = failinfo;

            }
            catch (Exception)
            {
                failinfo = "留言失敗";
                opt = model.RequestPageData(StateEnum.Article, e.data);
                opt["failinfo"] = failinfo;
            }
        }
        public void ArticleState_DoLike(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Article, e.data);
        }
        public void ArticleState_ToBack(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Board, e.data);
        }
        public void ArticleState_ToHome(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }

        //  Editor State
        public void EditorState_DoCreate(ViewEventArgs e, out DAT opt)
        {
            Article article = e.data["Article"] as Article;
            //設定錯誤資訊。
            string failinfo = "";
            try
            {
                //嘗試發文
                model.ReleaseArticle(article.Title, article.Content, article.OfGroup, article.OfBoard);
                opt = model.RequestPageData(StateEnum.Board, e.data);
                model.State = StateEnum.Board;
            }
            catch (ModelException me)
            {
                failinfo = me.userMessage == "" ? "文章發佈失敗" : me.userMessage;
                opt = model.RequestPageData(StateEnum.EditArticle, e.data);
                opt["failinfo"] = failinfo;

            }
            catch (Exception)
            {
                failinfo = "文章發佈失敗";
                opt = model.RequestPageData(StateEnum.EditArticle, e.data);
                opt["failinfo"] = failinfo;
            }
        }
        public void EditorState_ToBack(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Board, e.data);
        }

        // AD State
        public void ADState_DoBuy(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }
        public void ADState_ToHome(ViewEventArgs e, out DAT opt)
        {
            opt = model.RequestPageData(StateEnum.Home, e.data);
        }

    }

    /// <summary>
    /// 代表使用者在View上進行的行為之列舉值。
    /// </summary>
    public enum ViewOp
    {
        /// <summary>
        /// 在登入頁面，執行登入作業。
        /// </summary>
        Login_login = 0101,
        /// <summary>
        /// 在登入頁面，前往註冊頁面。
        /// </summary>
        Login_toregister = 0102,


        /// <summary>
        /// 在註冊頁面，執行註冊作業。
        /// </summary>
        Register_register = 0201,
        /// <summary>
        /// 在註冊頁面，返回前頁面。
        /// </summary>
        Register_back = 0202,


        /// <summary>
        /// 在首頁頁面，前往設定頁面。
        /// </summary>
        Home_setting = 0301,
        /// <summary>
        /// 在首頁頁面，瀏覽文章。
        /// </summary>
        Home_viewarticle = 0302,
        /// <summary>
        /// 在首頁頁面，前往團體頁面。
        /// </summary>
        Home_togroup = 0303,
        /// <summary>
        /// 在首頁頁面，前往使用者頁面。
        /// </summary>
        Home_touserpage = 0304,
        /// <summary>
        /// 在首頁頁面，發文。
        /// </summary>
        Home_editarticle = 0305,


        /// <summary>
        /// 在團體頁面，前往首頁頁面。
        /// </summary>
        Group_tohome = 0401,
        /// <summary>
        /// 在團體頁面，前往看板頁面。
        /// </summary>
        Group_toboard = 0402,
        /// <summary>
        /// 在團體頁面，瀏覽文章。
        /// </summary>
        Group_viewarticle = 0403,
        /// <summary>
        /// 在團體頁面，發文。
        /// </summary>
        Group_editarticle = 0405,


        /// <summary>
        /// 在看板頁面，前往首頁頁面。
        /// </summary>
        Board_tohome = 0501,
        /// <summary>
        /// 在看板頁面，前往團體頁面。
        /// </summary>
        Board_togroup = 0502,
        /// <summary>
        /// 在看板頁面，瀏覽文章。
        /// </summary>
        Board_viewarticle = 0503,
        /// <summary>
        /// 在看板頁面，發文。
        /// </summary>
        Board_editarticle = 0504,


        /// <summary>
        /// 在文章頁面，前往首頁頁面。
        /// </summary>
        Article_tohome = 0601,
        /// <summary>
        /// 在文章頁面，返回前頁面。
        /// </summary>
        Article_back = 0602,
        /// <summary>
        /// 在文章頁面，編輯文章。
        /// </summary>
        Article_editarticle = 0603,
        /// <summary>
        /// 在文章頁面，查看文章。
        /// </summary>
        Article_viewarticle = 0604,


        /// <summary>
        /// 在使用者頁面，前往首頁頁面。
        /// </summary>
        Userpage_tohome = 0701,
        /// <summary>
        /// 在使用者頁面，瀏覽文章。
        /// </summary>
        Userpage_viewarticle = 0702,


        /// <summary>
        /// 在編輯文章頁面，前往首頁頁面。
        /// </summary>
        Editarticle_tohome = 0801,
        /// <summary>
        /// 在編輯文章頁面，返回前頁面。
        /// </summary>
        Editarticle_back = 0802,
        /// <summary>
        /// 在編輯文章頁面，發布文章。
        /// </summary>
        Editarticle_release = 0803,


        /// <summary>
        /// 在文章列表返回看板。
        /// </summary>
        ArticleList_back = 0901,
    }



    /// <summary>
    /// 代表在View上引發的事件。
    /// </summary>
    /// <param name="page">引發事件的頁面。</param>
    /// <param name="sender">引發事件的控制項。</param>
    /// <param name="e">事件附帶的資料。</param>
    public delegate void ViewEventHandler(ViewEventArgs e, out DAT opt);

    /// <summary>
    /// 代表附帶在ViewEventHandler上的事件資料。
    /// </summary>
    public class ViewEventArgs
    {
        /// <summary>
        /// 儲存資料的字典物件。
        /// </summary>
        public DAT data { get; }
        /// <summary>
        /// 引發事件的頁面。
        /// </summary>
        public Page page { get; }

        /// <summary>
        /// 初始化ViewEventArgs類別的新執行個體，其中data值為null。
        /// </summary>
        public ViewEventArgs(Page pag)
        {
            data = new DAT();
            page = pag;
        }

        /// <summary>
        /// 初始化ViewEventArgs類別的新執行個體，其中包含從指定的DAT複製至data的項目。
        /// </summary>
        /// <param name="dat"></param>
        public ViewEventArgs(DAT dat, Page pag)
        {
            data = new DAT(dat);
            page = pag;
        }
    }

    /// <summary>
    /// 用來儲存資料的結構。
    /// </summary>
    public class DAT : Dictionary<string, object>
    {
        public new object this[string s]
        {
            get
            {
                return ((Dictionary<string, object>)this)[s];
            }
            set
            {
                try
                {
                    ((Dictionary<string, object>)this)[s] = value;
                }
                catch (KeyNotFoundException)
                {
                    Add(s, value);
                }
            }
        }

        public void Clone(Dictionary<string, object> src)
        {
            Clear();
            foreach (string key in src.Keys)
                Add(key, src[key]);
        }

        /// <summary>
        /// 初始化DAT類別的新執行個體，這個執行個體是空白的、具有預設的初始容量。
        /// </summary>
        public DAT() : base() { }

        /// <summary>
        /// 初始化DAT類別的新執行個體，這個執行個體是空白的、具有指定的初始容量。
        /// </summary>
        /// <param name="capacity"></param>
        public DAT(int capacity) : base(capacity) { }

        /// <summary>
        /// 初始化DAT類別的新執行個體，其中包含從指定的Dictionary複製的項目。
        /// </summary>
        /// <param name="dat"></param>
        public DAT(Dictionary<string, object> dat) : base(dat) { }
    }
}