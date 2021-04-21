using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1
{
    struct frame
    {
        public string word;
        public string type;
        public int row;
    }

    class Process
    {
        public static string[] r = new string[] { ":=", ";", "+", "-", "*", "/", ">", "<", ">=", "<=", "!=", "==", ":", "!", "=", "(", ")", "{", "}", "[", "]", "," };       
        static string[] l = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
        static string[] i = null;
        public static string[] kw = new string[] { "switch", "case", "default", "break", "void", "main", "int", "bool", "string", "Math.sin", "Console.WriteLine" };
        public static int[] countOfKW = new int[kw.Length];
        public static int enterCounter = 0;
        static List<frame> frameCollection = new List<frame>();
        public static List<string> rCollection = new List<string>();
        public static List<string> lCollection = new List<string>();
        public static List<string> iCollection = new List<string>();
        static List<string> scanResult = new List<string>();
        public static bool flag = false;

        public List<frame> sytaxisAnalysis(string text)
        {            
            int left = Convert.ToInt32('a');
            int right = Convert.ToInt32('z');
            i = new string[right - left + 1];
            for (int k = 0; k < i.Length; k++)
            {
                i[k] = Convert.ToChar(left + k).ToString();
            }

            int j = 0;
            while (j < text.Length)
            {
                if(text[j] == '\n')
                {
                    enterCounter++;
                }
                if (checkSimbolAllowed(text[j], r))
                {
                    sytaxisAnalysisR(text, ref j);
                }
                else
                {
                    if (checkSimbolAllowed(text[j], l))
                    {
                        sytaxisAnalysisL(text, ref j);
                    }
                    else
                    {
                        if (checkSimbolAllowed(text[j], i))
                        {
                            sytaxisAnalysisI(text, ref j);
                        }
                        else
                        {
                            if (text[j] == ' ' || text[j] == '\n' || text[j] == '\r')
                            {
                                j++;
                            }
                            else
                            {
                                sytaxisEror(text, ref j);
                                j++;
                            }
                        }
                    }
                }
            }
            return frameCollection;
        }

        public bool checkSimbolAllowed(char c, string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (c == s[i][0])
                {
                    return true;
                }
            }
            return false;
        }
        public bool checkSimbolAllowed(string c, string[] s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                if (c == s[i])
                {
                    return true;
                }
            }
            return false;
        }
        public void sytaxisAnalysisR(string text, ref int j)
        {
            if((text[j] == '!') || (text[j] == ':') || (text[j] == '>') || (text[j] == '<'))
            {
                string ss = string.Concat(text[j], text[j + 1]);
                checkSimbolAllowed(ss,r);
                frame addingItem;
                addingItem.word = ss;
                addingItem.type = " -- разделитель";
                addingItem.row = enterCounter;
                frameCollection.Add(addingItem);
                rCollection.Add(addingItem.word);
                j++;
            }
            else
            {
                frame addingItem;
                addingItem.word = text[j].ToString();
                addingItem.type = " -- разделитель";
                addingItem.row = enterCounter;
                frameCollection.Add(addingItem);
                rCollection.Add(addingItem.word);
            }
            j++;
        }
        public void sytaxisAnalysisL(string text, ref int j)
        {
            frame addingItem;
            string res = "";
            do
            {                
                if (!checkSimbolAllowed(text[j], l))
                {
                    if(j<=text.Length)
                    {
                        if(((Convert.ToInt32(text[j])>=65) && (Convert.ToInt32(text[j]) <= 90)) || ((Convert.ToInt32(text[j]) >= 97) && (Convert.ToInt32(text[j]) <= 122)))
                        {
                            MessageBox.Show("Имя переменной начитается с цыфры.");
                            res += text[j];
                            j++;
                            addingItem.word = res;
                            addingItem.type = " -- идентификатор(*ОШИБКА!*)";
                            addingItem.row = enterCounter;
                            frameCollection.Add(addingItem);
                            iCollection.Add(addingItem.word);
                            return;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                res += text[j];
                j++;
            } while (j < text.Length);
            addingItem.word = res;
            addingItem.type = " -- литерал";
            addingItem.row = enterCounter;
            frameCollection.Add(addingItem);
            lCollection.Add(addingItem.word);
        }

        public void sytaxisAnalysisI(string text, ref int j)
        {
            bool resIsKeyWord = false;
            string res = "";
            do
            {                
                if (!checkSimbolAllowed(text[j], i) && !checkSimbolAllowed(text[j], l))
                {
                    break;
                }
                res += text[j];
                j++;
            } while (j < text.Length);
            for (int i=0; i<kw.Length; i++)
            {
                if(res == kw[i])
                {
                    resIsKeyWord = true;
                    countOfKW[i]++;
                }
            }
            if (resIsKeyWord == true)
            {
                frame addingItem;
                addingItem.word = res;
                addingItem.type = " -- ключевое слово";
                addingItem.row = enterCounter;
                frameCollection.Add(addingItem);
            }
            else
            {
                frame addingItem;
                bool flag1 = true;
                if (res.Length>8)
                {
                    MessageBox.Show("Превышена допустимая длинна названия переменной");
                    addingItem.word = res;
                    addingItem.type = " -- идентификатор(*ОШИБКА!*)";
                    addingItem.row = enterCounter;
                    goto point;
                }
                addingItem.word = res;
                addingItem.type = " -- идентификатор";
                addingItem.row = enterCounter;
                point:
                foreach (frame checkingUnit in frameCollection)
                {
                    if (checkingUnit.word == addingItem.word)
                    {
                        flag1 = false;
                    }
                }
                if (flag1 == true)
                {
                    frameCollection.Add(addingItem);
                    iCollection.Add(addingItem.word);
                }
            }
        }
        public void sytaxisEror(string text, ref int j)
        {
            frame addingItem;
            addingItem.word = text[j].ToString();
            addingItem.type = " -- недопустимый символ(*ОШИБКА!*)";
            addingItem.row = enterCounter;
            frameCollection.Add(addingItem);
            MessageBox.Show("Введён недопустимый символ");
        }
        public static List<string> scaning()
        {
            foreach (frame elem in frameCollection)
            {
                if (elem.type == " -- идентификатор")
                {
                    for (int i = 0; i < iCollection.Count; i++)
                    {
                        if(iCollection[i]==elem.word)
                        {
                            scanResult.Add(elem.type + ") " + i.ToString() + " [строка " + elem.row.ToString() + "]");
                        }
                    }
                }
                if (elem.type == " -- литерал")
                {
                    for (int i = 0; i < lCollection.Count; i++)
                    {
                        if (lCollection[i] == elem.word)
                        {
                            scanResult.Add(elem.type + ") " + i.ToString() + " [строка " + elem.row.ToString() + "]");
                        }
                    }
                }
                if (elem.type == " -- разделитель")
                {
                    for (int i = 0; i < rCollection.Count; i++)
                    {
                        if (rCollection[i] == elem.word)
                        {
                            scanResult.Add(elem.type + ") " + i.ToString() + " [строка " + elem.row.ToString() + "]");
                        }
                    }
                }
                if (elem.type == " -- ключевое слово")
                {
                    for (int i = 0; i < kw.Length; i++)
                    {
                        if (kw[i] == elem.word)
                        {
                            scanResult.Add(elem.type + ") " + i.ToString() + " [строка " + elem.row.ToString() + "]");
                        }
                    }
                }
            }
            return scanResult;
        }
    }
}
