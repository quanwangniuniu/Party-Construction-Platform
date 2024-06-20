using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Niuniumama
{
    public partial class LearningAreaPage : Page
    {
        private List<string> items = new List<string>();
        private int currentPage = 1;
        private int itemsPerPage = 10;
        public LearningAreaPage()
        {
            InitializeComponent();
            
            // 添加示例数据
            for (int i = 1; i <= 50; i++)
            {
                items.Add($"Item {i}");
            }
            // 显示第一页数据
            DisplayPage(1);
        }

        private void DisplayPage(int pageNumber)
        {
            currentPage = pageNumber;
            lblCurrentPage.Content = $"Page {currentPage}";
            
            listView.Items.Clear();
            int startIndex = (currentPage - 1) * itemsPerPage;
            int endIndex = Math.Min(startIndex + itemsPerPage, items.Count);

            for (int i = startIndex; i < endIndex; i++)
            {
                listView.Items.Add(items[i]);
            }

            btnPrevPage.IsEnabled = currentPage > 1;
            btnNextPage.IsEnabled = endIndex < items.Count;
        }

        private void BtnPrevPage_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(currentPage-1);
        }
        
        private void BtnNextPage_Click(object sender, RoutedEventArgs e)
        {
            DisplayPage(currentPage+1);
        }
    }
}