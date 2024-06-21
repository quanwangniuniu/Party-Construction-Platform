using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Niuniumama.Models;

namespace Niuniumama
{
    public partial class PartyMemberStylePage : Page,INotifyPropertyChanged
    {
        public ObservableCollection<MemberNews> NewsList { get; set; }
        public ObservableCollection<MemberNews> PageData { get; set; }
        public int PageSize { get; set; } = 20;
        public int TotalPages { get; set; }
        
        // public ObservableCollection<MemberNews> MemberNewsList { get; set; } = new ObservableCollection<MemberNews>();

        public PartyMemberStylePage()
        {
            InitializeComponent();
            // 添加党员风采数据
            // 使用数据库前，模拟添加数据
            NewsList = new ObservableCollection<MemberNews>(GetMockNewsData());
            TotalPages = (int)Math.Ceiling(NewsList.Count / (double)PageSize);
            LoadPageData();
            this.DataContext = this;
        }
        
        // 查看详情
        private void MemberNewsListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedMemberNews = MemberNewsListBox.SelectedItem as MemberNews;
            if (selectedMemberNews != null)
            {
                var memberNewsDetailWindow = new MemberNewsDetailWindow(selectedMemberNews);
                memberNewsDetailWindow.DataContext = selectedMemberNews;
                memberNewsDetailWindow.Show();
            }
        }
        
        private void LoadPageData()
        {
            PageData = new ObservableCollection<MemberNews>(
                NewsList.Skip((CurrentPage - 1) * PageSize).Take(PageSize));
            OnPropertyChanged(nameof(PageData));
        }

        private void FirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = 1;
            LoadPageData();
        }

        private void PreviousPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                LoadPageData();
            }
        }

        private void NextPageButton_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                LoadPageData();
            }
        }

        private void LastPageButton_Click(object sender, RoutedEventArgs e)
        {
            CurrentPage = TotalPages;
            LoadPageData();
        }

        // Mock数据方法，需要替换为实际的数据获取逻辑
        private IEnumerable<MemberNews> GetMockNewsData()
        {
            // 模拟数据生成逻辑，返回一个包含新闻数据的列表
            var newsList = new ObservableCollection<MemberNews>();
            int day = 1;
            int month = 1;
            int year = 2024;

            for (int i = 1; i <= 200; i++)
            {
                // 如果当前天数超过当前月份的最大天数，则增加月份
                if (day > 28)
                {
                    month++;
                    day = 1;
                    if (month > 12)
                    {
                        month = 1;
                        year++;
                    }
                }

                newsList.Add(new MemberNews
                {
                    Title = $"党员风采展示标题{i}",
                    PublishDate = new DateTime(year, month, day),
                    Source = $"来源{i}",
                    Content = $"这里是党员风采展示的具体内容{i}...",
                    Editor = $"编辑人{i}",
                    Reviewer = $"核审人{i}"
                });

                day++;
            }

            return newsList;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private int _currentPage;

        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
                LoadPageData();
            }
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}