using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoppingHeart
{
    public partial class Payment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {  
        }

        public enum CardType
        {
            Invalid,
            Unknown,
            AmericanExpress,
            Bankcard,
            DinersClubInternational,
            DinersClubUSandCanada,
            DiscoverCard,
            JCB,
            Maestro,
            MasterCard,
            SoloDebit,
            SwitchDebit,
            Visa,
            VisaElectron,
            enRoute
        }

        public static CardType GetCardType(string strCardNumber)
        {
            strCardNumber = strCardNumber.Replace(" ", "");

            // Check American Express
            if (strCardNumber.Substring(0, 2) == "34" || strCardNumber.Substring(0, 2) == "37")
            {
                if (strCardNumber.Length == 15)
                    return CardType.AmericanExpress;
                else
                    return CardType.Invalid;
            }

            // Check Bankcard
            if (strCardNumber.Substring(0, 3).ToUpper() == "DNE") return CardType.Bankcard;

            // Check Diners Club Internationl
            if (strCardNumber.Substring(0, 2) == "36" || strCardNumber.Substring(0, 2) == "38" || (Convert.ToInt32(strCardNumber.Substring(0, 3)) >= 300 && Convert.ToInt32(strCardNumber.Substring(0, 3)) <= 305))
                if (strCardNumber.Length == 14)
                    return CardType.DinersClubInternational;
                else
                    return CardType.Invalid;

            // Check Diners Club US and Canadaa
            if (strCardNumber.Substring(0, 2) == "55") return CardType.DinersClubUSandCanada;

            // Check Discover Card
            if (strCardNumber.Substring(0, 4) == "6011")
                if (strCardNumber.Length == 16)
                    return CardType.Bankcard;
                else
                    return CardType.Invalid;

            // Check JCB Card
            if (strCardNumber.Substring(0, 4) == "2131" || strCardNumber.Substring(0, 4) == "1800")
                if (strCardNumber.Length == 15)
                    return CardType.JCB;
                else
                    return CardType.Invalid;

            // Check Maestro Card
            if (strCardNumber.Substring(0, 4) == "5020")
                if (strCardNumber.Length == 16)
                    return CardType.Maestro;
                else
                    return CardType.Invalid;

            // Check MasterCard
            if ((Convert.ToInt32(strCardNumber.Substring(0, 3)) >= 51 && Convert.ToInt32(strCardNumber.Substring(0, 3)) <= 55))
                if (strCardNumber.Length == 16)
                    return CardType.MasterCard;
                else
                    return CardType.Invalid;

            // Check Solo Card
            if (strCardNumber.Substring(0, 2) == "63" || strCardNumber.Substring(0, 4) == "6767")
                if (strCardNumber.Length == 16 || strCardNumber.Length == 18 || strCardNumber.Length == 19)
                    return CardType.SoloDebit;
                else
                    return CardType.Invalid;

            // Check Switch Card
            if (strCardNumber.Substring(0, 4) == "4903" || strCardNumber.Substring(0, 4) == "4905" || strCardNumber.Substring(0, 4) == "4911" || strCardNumber.Substring(0, 4) == "4936" || strCardNumber.Substring(0, 6) == "564182" || strCardNumber.Substring(0, 6) == "633110" || strCardNumber.Substring(0, 4) == "6333" || strCardNumber.Substring(0, 4) == "6759")
                if (strCardNumber.Length == 16 || strCardNumber.Length == 18 || strCardNumber.Length == 19)
                    return CardType.SwitchDebit;
                else
                    return CardType.Invalid;

            // Check Visa Electron Card
            if (strCardNumber.Substring(0, 6) == "417500")
                if (strCardNumber.Length == 16)
                    return CardType.VisaElectron;
                else
                    return CardType.Invalid;

            // Check Visa Card
            if (strCardNumber.Substring(0, 1) == "4")
                if (strCardNumber.Length == 16)
                    return CardType.Visa;
                else
                    return CardType.Invalid;

            // Check enRoute Card
            if (strCardNumber.Substring(0, 4) == "2014" || strCardNumber.Substring(0, 4) == "2149")
                if (strCardNumber.Length == 15)
                    return CardType.enRoute;
                else
                    return CardType.Invalid;

            return CardType.Unknown;

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            if (TextBox2.Text == "")
            {
                Label4.Text = "*";
            }
            else
            {
                Label4.Text = "";
                int cm = DateTime.Now.Month;
                int cy = DateTime.Now.Year;
                string exp = TextBox2.Text;
                if (exp.Length == 7)
                {
                    
                    int cm1 = Convert.ToInt32(exp.Substring(0, 2));
                    int cy1 = Convert.ToInt32(exp.Substring(3, 4));
                    if (cm1 <= 12)
                    {
                       


                        if (cy1 < cy)
                        {
                            Label4.Text = "Enter correct expiry date";
                        }
                        else if (cy1 == cy)
                        {
                            if (cm1 < cm)
                                Label4.Text = "Enter correct expiry date";
                            else
                                Label4.Text = "";
                        }
                        else
                        {
                            Label4.Text = "";
                        }
                    }
                    Label4.Text = "Enter in correct format(mm/yyyy)";
                    Label4.Text = cm1.ToString();
                }
                else
                    Label4.Text = "Enter in correct format(mm/yyyy)";
            }
           
        }
        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text == "")
                Label2.Text = "*";
            else
            {
                
                if (TextBox1.Text.Length != 16)
                    Label2.Text = "Enter 16 digit card number";
                else
                {
                   Label2.Text="";
                    CardType g1 = GetCardType(TextBox1.Text);
                    Label3.Text = g1.ToString();
                }
            }

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {
            if (TextBox3.Text != "")
            {
                if (TextBox3.Text.Length != 3)
                    Label5.Text = "Enter 3 digit CVV";
                else
                    Label5.Text = "";
            }
            else
                Label5.Text = "*";

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {
            if (TextBox4.Text !="")
                Label6.Text = "";
            else
                Label6.Text = "*";
        }
    }
}
