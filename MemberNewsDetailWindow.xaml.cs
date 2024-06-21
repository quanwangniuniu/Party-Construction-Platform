using System.Windows;
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