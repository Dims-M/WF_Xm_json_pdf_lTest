﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WFXmlTest.JobXml
{
    /// <summary>
    /// Работа с  файлом XML
    /// </summary>
   public  class JobInXml
    {
        private string infa;

        public string ReadingXml()
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("test.xml");

            // получим корневой элемент
            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                // получаем атрибут name
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");
                    if (attr != null)
                        Console.WriteLine(attr.Value);
                }
                // обходим все дочерние узлы элемента user
                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    //ищем нужные данные
                    if (childnode.Name == "FileVersion ")
                    {
                        //   infa += $"Версия файла: {childnode.InnerText},"+ Environment.NewLine;
                        infa += $"{childnode.InnerText}," + Environment.NewLine;
                        //Console.WriteLine($"Компания: {childnode.InnerText}");
                    }


                    if (childnode.Name == "Name")
                    {
                        // infa += $"Имя: {childnode.InnerText},"+ Environment.NewLine;
                        infa += $"{childnode.InnerText}," + Environment.NewLine;
                        //Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }

                    if (childnode.Name == "DateTime")
                    {
                        //infa += $"Дата созднаия(изменения) файла:{childnode.InnerText},"+Environment.NewLine;
                        infa += $"{childnode.InnerText}," + Environment.NewLine;
                        //  Console.WriteLine($"Возраст: {childnode.InnerText}");
                    }
                }

            }
            return infa;
        }

        /// <summary>
        /// Чтение xml
        /// </summary>
        /// <param name="item"></param>
        public void XmlDoc(string item)
        {

            // загружаем файл
            var doc = new XmlDocument();
            doc.Load("test.xml");

            // меняем атрибут
            XmlNodeList adds = doc.GetElementsByTagName("Name");
            foreach (XmlNode add in adds) { 
                if (add.Attributes["key"].Value == "fileVersion")
                {
                    add.Attributes["value"].Value = item.ToString(); // новое значение
                    break;
                }
            if (add.Attributes["key"].Value == "Name")
            {
                add.Attributes["value"].Value = item.ToString(); // новое значение
                break;
            }
            
            }
            // сохраняем файл
            doc.Save("testМ.xml");
        }


        //запись в файл
        /// <summary>
        /// запись в текстовой файл. Журнал событий
        /// </summary>
        /// <param name="myText"></param>
        public void WrateText(string myText)
        {
          
            using (StreamWriter sw = new StreamWriter("LogJob.txt", true, System.Text.Encoding.Default))

            // using (StreamWriter sw = new StreamWriter(myPachDir + @"texLog.txt", true, System.Text.Encoding.Default))
            {
                sw.WriteLine(DateTime.Now + "\t\n" + myText); // запись
            }
        }

        /// <summary>
        /// Проверка коректности имени файла XML с помощью регулярки
        /// </summary>
        /// <param name="pathFile"></param>
        /// <returns></returns>
        public bool RegFileXml(string pathFile)
        {
            bool rezul = false;
            try
            {
                string pattern = @"^[а-я]{1,100}[_](\d{1}|\d{10}|\d{14,20})[_]\w{1,7}[\.]xml";
                
                if (Regex.IsMatch(pathFile, pattern, RegexOptions.IgnoreCase))
                {
                    rezul = true;
                }
                else
                {
                   
                    WrateText("Файл не прошел [проверку], Некорректный файл или имя файла ");
                    rezul = false;
                }
            }
            catch (Exception ex)
            {
                WrateText("Ошибка при проверке файла xml \n"+ex);
                WrateText(ex.ToString());
            }



            return rezul;
        }



    }
}
