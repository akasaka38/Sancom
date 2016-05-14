using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

namespace SkillUpSample2
{
    public partial class First : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            //ローマ字で入力されているかチェックすることも考える
            String str = "";

            using (StreamReader readText = new StreamReader(@"C:\Users\sancom260\Desktop\新しいテキスト ドキュメント (3).txt", System.Text.Encoding.GetEncoding("utf-8")))
            {
                //while((str = readText.ReadLine()) != null){
                str = readText.ReadLine();
                    //ローマ字の母音で区切る
                    str = str.Replace("a", "a,");
                    str = str.Replace("i", "i,");
                    str = str.Replace("u", "u,");
                    str = str.Replace("e", "e,");
                    str = str.Replace("o", "o,");
                    str = str.Replace("nn", "nn,");
                //}
            }

            using (StreamWriter writeText = new StreamWriter(@"C:\Users\sancom260\Desktop\新しいテキスト ドキュメント (3).txt"))
            {
                writeText.WriteLine(Henkan(str));
            }
        }

        private String Henkan(String input)
        {
            //母音を数字にする為の配列
            Dictionary<string, int> boinNum = new Dictionary<string, int>()
                {
                    {"a", 0},
                    {"i", 1},
                    {"u", 2},
                    {"e", 3},
                    {"o", 4}
                };

            String[] a = { "あ", "い", "う", "え", "お" };
            String[] k = { "か", "き", "く", "け", "こ" };
            String[] s = { "さ", "し", "す", "せ", "そ" };
            String[] t = { "た", "ち", "つ", "て", "と" };
            String[] n = { "な", "に", "ぬ", "ね", "の" };
            String[] h = { "は", "ひ", "ふ", "へ", "ほ" };
            String[] m = { "ま", "み", "む", "め", "も" };
            String[] y = { "や", "い", "ゆ", "いぇ", "よ" };
            String[] r = { "ら", "り", "る", "れ", "ろ" };
            String[] w = { "わ", "うぃ", "う", "うぇ", "を" };
            String[] b = { "ば" ,"び", "ぶ", "べ", "ぼ" };
            String[] p = { "ぱ" ,"ぴ" ,"ぷ" ,"ぺ" ,"ぽ" };
            String[] q = { "くぁ" ,"くぃ","く","くぇ","くぉ"};
            String[] z = { "ざ" ,"じ" ,"ず" ,"ぜ" ,"ぞ" };
            String[] x = { "ぁ", "ぃ", "ぅ", "ぇ", "ぉ" };
            String[] d = { "だ", "ぢ", "づ", "で", "ど" };
            String[] c = { "か", "し", "く", "せ", "こ" };
            String[] f = { "ふぁ", "ふぃ", "ふ", "ふぇ", "ふぉ" };
            String[] v = { "ヴぁ", "ヴぃ", "ヴ", "ヴぇ", "ヴぉ" };
            String[] g = { "が", "ぎ", "ぐ", "げ", "ご" };
            String[] j = { "じゃ", "じ", "じゅ", "じぇ", "じょ"};
            String[] l = { "ぁ", "ぃ", "ぅ", "ぇ", "ぉ" };

            String[] wh = { "うぁ", "うぃ", "う", "うぇ", "うぉ"};
            String[] ly = { "ゃ", "ぃ", "ゅ", "ぇ", "ょ" };
            String[] xy = { "ゃ", "ぃ", "ゅ", "ぇ", "ょ"};
            String[] ky = { "きゃ", "きぃ", "きゅ", "きぇ", "きょ"};
            String[] qy = { "くゃ", "くぃ", "くゅ", "くぇ", "くょ"};
            String[] qw = { "くぁ", "くぃ", "くぅ", "くぇ", "くぉ" };
            String[] gy = { "ぎゃ", "ぎぃ", "ぎゅ", "ぎぇ", "ぎょ"};
            String[] gw = { "ぐぁ", "ぐぃ", "ぐぅ", "ぐぇ", "ぐぉ"};

            //ひらがなの行を指定するための配列
            Dictionary<String, String[]> mojiGyou = new Dictionary<String, String[]>()
            {
                {"a", a},
                {"k", k},
                {"s", s},
                {"t", t},
                {"n", n},
                {"h", h},
                {"m", m},
                {"y", y},
                {"r", r},
                {"w", w},
                {"b", b},
                {"p", p},
                {"q", q},
                {"z", z},
                {"x", x},
                {"d", d},
                {"c", c},
                {"f", f},
                {"v", v},
                {"g", g},
                {"j", j},
                {"l", l}
            };

            String[] mojiretu = input.Split(',');
            String returnMoji = "";
            String sample = "";
            String[] test;

            foreach (String moji in mojiretu)
            {
                switch(moji.Length)
                {
                    case 1:
                        returnMoji += a[boinNum[moji]];
                        break;
                    case 2:
                        sample = moji.Substring(0, 1);
                        test = mojiGyou[sample];
                        if (moji.Substring(1, 1) == "n")
                        {
                            returnMoji += "ん";
                        }
                        else
                        {
                            returnMoji += test[boinNum[moji.Substring(1, 1)]];
                        }
                        break;
                    case 3:
                        if (moji.Substring(0, 1) == moji.Substring(1, 1))
                        {
                            sample = moji.Substring(0, 1);
                            test = mojiGyou[sample];
                            returnMoji += "っ" + test[boinNum[moji.Substring(2, 1)]];
                        }
                        else
                        {
                            sample = moji.Substring(0, 2);
                            test = mojiGyou[sample];
                            returnMoji += test[boinNum[moji.Substring(2, 1)]];
                        }
                        break;
                    default:
                        break;
                }
            }

            return returnMoji;
        }
    }
}