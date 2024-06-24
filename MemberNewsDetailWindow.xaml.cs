using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using Microsoft.Win32;
using Niuniumama.Models;

namespace Niuniumama
{
    public partial class MemberNewsDetailWindow : Window
    {
        public MemberNews MemberNews { get; set; }
        public MemberNewsDetailWindow(MemberNews memberNews)
        {
            InitializeComponent();
            this.MemberNews = memberNews;
            this.DataContext = this;
        }
        
    }
}