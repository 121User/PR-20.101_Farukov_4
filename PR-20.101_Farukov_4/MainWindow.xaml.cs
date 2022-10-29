﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_20._101_Farukov_4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static string Reverse(string text)
        {
            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        private void btn_Start_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string str = tb_Input.Text;

                int rus = Regex.Matches(str, @"[абвгдеёжзийклмнопрстуфхцчшщьыъэюя]", RegexOptions.IgnoreCase).Count;
                int eng = Regex.Matches(str, @"[abcdefghijklmnopqrstuvwxyz]", RegexOptions.IgnoreCase).Count;
                if (rus == 0 && eng != 0)
                {
                    TextInfo upp = new CultureInfo("en-US", false).TextInfo;

                    str = Reverse(str);
                    string result = upp.ToTitleCase(str);

                    result = result.Replace("  ", " «это_пробел»");

                    tb_Result.Text = result;
                }
                else
                {
                    throw new Exception("Invalid input");
                }
            }
            catch(Exception)
            {
                tb_Result.Text = "Введите строку на английском языке!";
            }
        }
    }
}
