using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Configuration; 
namespace KisiselBlog.Web.App_Classes
{
    public class Settings
    {
        public static Size ResimKucukBoyut
        {
            get
            {
                Size Sonuc = new Size();
                Sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                Sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return Sonuc;
            }
        }

        public static Size ResimOrtaBoyut
        {
            get
            {
                Size Sonuc = new Size();
                Sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                Sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return Sonuc;
            }
        }

        public static Size ResimBuyukBoyut
        {
            get
            {
                Size Sonuc = new Size();
                Sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                Sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return Sonuc;
            }
        }
    }
}