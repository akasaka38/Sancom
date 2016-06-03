using System;
using System.IO;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Windows;

namespace SkillUpSample2
{
    public partial class First : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button_Click(object sender, EventArgs e)
        {
            String path = filename.Value;
            System.Text.Encoding enc = System.Text.Encoding.GetEncoding("utf-8");
            String str = System.IO.File.ReadAllText(path, enc);

            str = str.ToLower();

            //ローマ字の母音で区切る
            str = str.Replace(",", "、,");
            str = str.Replace("a", "a,");
            str = str.Replace("i", "i,");
            str = str.Replace("u", "u,");
            str = str.Replace("e", "e,");
            str = str.Replace("o", "o,");
            str = str.Replace("nn", "nn,");
            str = str.Replace(" ", " ,");
            str = str.Replace("-", "-,");
            str = str.Replace("\n", "qq,");
            str = str.Replace(".", "。,");

            System.IO.File.WriteAllText(path, Henkan(str), enc);
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
            String[] sh = { "しゃ", "し", "しゅ", "しぇ", "しょ" };
            String[] sy = { "しゃ", "し", "しゅ", "しぇ", "しょ" };
            String[] sw = { "すぁ", "すぃ", "すぅ", "すぇ", "すぉ" };
            String[] zy = { "じゃ", "じぃ", "じゅ", "じぇ", "じょ"};
            String[] jy = { "じゃ", "じぃ", "じゅ", "じぇ", "じょ" };
            String[] ty = { "ちゃ", "ちぃ", "ちゅ", "ちぇ", "ちょ" };
            String[] cy = { "ちゃ", "ちぃ", "ちゅ", "ちぇ", "ちょ" };
            String[] ch = { "ちゃ", "ち", "ちゅ", "ちぇ", "ちょ" };
            String[] ts = { "つぁ", "つぃ", "つ", "つぇ", "つぉ" };
            String[] th = { "てゃ", "てぃ", "てゅ", "てぇ", "てょ" };
            String[] tw = { "とぁ", "とぃ", "とぅ", "とぇ", "とぉ" };
            String[] dy = { "ぢゃ", "ぢぃ", "ぢゅ", "ぢぇ", "ぢょ" };
            String[] dh = { "でゃ", "でぃ", "でゅ", "でぇ", "でょ" };
            String[] dw = { "どぁ", "どぃ", "どぅ", "どぇ", "どぉ" };
            String[] ny = { "にゃ", "にぃ", "にゅ", "にぇ", "にょ" };
            String[] hy = { "ひゃ", "ひぃ", "ひゅ", "ひぇ", "ひょ" };
            String[] fw = { "ふぁ", "ふぃ", "ふぅ", "ふぇ", "ふぉ"};
            String[] fy = { "ふゃ", "ふぃ", "ふゅ", "ふぇ", "ふょ" };
            String[] by = { "びゃ", "びぃ", "びゅ", "びぇ", "びょ" };
            String[] vy = { "ヴゃ", "ヴぃ", "ヴゅ", "ヴぇ", "ヴょ" };
            String[] py = { "ぴゃ", "ぴぃ", "ぴゅ", "ぴぇ", "ぴょ" };
            String[] my = { "みゃ", "みぃ", "みゅ", "みぇ", "みょ" };
            String[] ry = { "りゃ", "りぃ", "りゅ", "りぇ", "りょ" };
            String[] xt = { "","","っ","",""};
            String[] lt = { "", "", "っ", "", "" };
            

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
                {"l", l},
                {"wh", wh},
                {"ly", ly},
                {"xy", xy},
                {"ky", ky},
                {"qy", qy},
                {"qw", qw},
                {"gy", gy},
                {"gw", gw},
                {"sh", sh},
                {"sy", sy},
                {"sw", sw},
                {"zy", zy},
                {"jy", jy},
                {"ty", ty},
                {"cy", cy},
                {"ch", ch},
                {"ts", ts},
                {"th", th},
                {"tw", tw},
                {"dy", dy},
                {"dh", dh},
                {"dw", dw},
                {"ny", ny},
                {"hy", hy},
                {"fw", fw},
                {"fy", fy},
                {"by", by},
                {"vy", vy},
                {"py", py},
                {"my", my},
                {"ry", ry},
                {"xt", xt},
                {"lt", lt}
            };

            String[] mojiretuSample = input.Split(',');
            List<String> mojiretu = new List<string>();

            foreach (String i in mojiretuSample)
            {
                if(i == "")
                {
                    continue;
                }

                if(i.Substring(0, 1) != "n")
                {
                    mojiretu.Add(i);
                }
                else
                {
                    if(i.Substring(1, 1) == "a" || i.Substring(1, 1) == "i" || i.Substring(1, 1) == "u" || i.Substring(1, 1) == "e" || i.Substring(1, 1) == "o")
                    {
                        mojiretu.Add(i);
                    }
                    else if(i == "nn")
                    {
                        mojiretu.Add(i);
                    }
                    else
                    {
                        mojiretu.Add(i.Substring(0, 1));
                        mojiretu.Add(i.Substring(1, 2));
                    }
                }
            }
            
            String returnMoji = "";
            String sample = "";
            String[] test;

            foreach (String moji in mojiretu)
            {
                switch(moji.Length)
                {
                    case 1:
                        if (moji == "a" || moji == "i" || moji == "u" || moji == "e" || moji == "o")
                        {
                            returnMoji += a[boinNum[moji]];
                        }
                        else if (moji == "n")
                        {
                            returnMoji += "ん";
                        }
                        else
                        {
                            returnMoji += moji;
                        }

                        
                        break;
                    case 2:
                        if(moji == "qq")
                        {
                            returnMoji += "\r\n";
                            break;
                        }

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
                            if(mojiGyou[sample] == null)
                            {
                                sample = moji.Substring(1, 1);
                                test = mojiGyou[sample];
                                returnMoji += moji.Substring(0, 1);
                                returnMoji += test[boinNum[moji.Substring(2, 1)]];
                            }
                            else
                            {
                                test = mojiGyou[sample];
                                returnMoji += test[boinNum[moji.Substring(2, 1)]];
                            }
                        }
                        break;
                    case 4:
                        if(moji.Substring(0, 1) == moji.Substring(1, 1))
                        {
                            returnMoji += "っ";
                        }
                        else
                        {
                            returnMoji += moji.Substring(0, 1);
                        }
                        
                        if (moji.Substring(1, 1) == moji.Substring(2, 1))
                        {
                            sample = moji.Substring(1, 1);
                            test = mojiGyou[sample];
                            returnMoji += "っ" + test[boinNum[moji.Substring(3, 1)]];
                        }
                        else
                        {
                            sample = moji.Substring(1, 2);
                            if(mojiGyou[sample] == null)
                            {
                                sample = moji.Substring(2, 1);
                                test = mojiGyou[sample];
                                returnMoji += moji.Substring(1, 1);
                                returnMoji += test[boinNum[moji.Substring(3, 1)]];
                            }
                            else
                            {
                                test = mojiGyou[sample];
                                returnMoji += test[boinNum[moji.Substring(3, 1)]];
                            }
                        }
                        break;
                    default:
                        //sample = moji.Substring(moji.Length, 1);
                        //if(sample == "a" || sample == "i" || sample == "u" || sample == "e" || sample == "o")
                        //{
                            
                        //}
                        //else
                        //{
                        //    returnMoji += moji;
                        //}
                        break;
                }
            }

            return returnMoji;
        }
    }
}
