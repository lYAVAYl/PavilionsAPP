using System;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;
using System.Drawing;
using PavilionsAPP.Model;

namespace PavilionsAPP.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private IPageViewModel _currentPageViewModel;
        private List<IPageViewModel> _pageViewModels;

        public Visibility IsHeaderVisible { get; set; } = Visibility.Hidden;

        public BitmapImage UserPhoto { get; set; }
        public string UserLogin { get; set; }

        


        // Список страниц, доступных для отрисовки
        public List<IPageViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<IPageViewModel>();

                return _pageViewModels;
            }
        }

        // Своство, отвечающее за отображение нужно страницы
        public IPageViewModel CurrentPageViewModel
        {
            get
            {
                return _currentPageViewModel;
            }
            set
            {
                _currentPageViewModel = value;
                OnPropertyChanged("CurrentPageViewModel");
            }
        }

        // Изменить текущую страницу
        private void ChangeViewModel(IPageViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);
            

            CurrentPageViewModel = PageViewModels.FirstOrDefault(vm => vm == viewModel);
        }
        

        /// <summary>
        /// Загрузка страницы Входа
        /// </summary>
        /// <param name="obj"></param>
        private void LoadSignInPage(object obj)
        {
            PageViewModels[0] = new SignInVM();
            ChangeViewModel(PageViewModels[0]);
        }
        /// <summary>
        /// Загрузка страницы Регистранции
        /// </summary>
        /// <param name="obj"></param>
        private void LoadSignOnPage(object obj)
        {
            PageViewModels[1] = new SignOnVM();
            ChangeViewModel(PageViewModels[1]);
        }
        


        public MainWindowViewModel()
        {
            // Добавить доступные страницы и установить команды
            PageViewModels.Add(new SignInVM());              // 0 Вход
            PageViewModels.Add(new SignOnVM());              // 1 Регистрация
           

            // Загрузка первой страницы
            CurrentPageViewModel = PageViewModels[0];

            // Установка команд
            Mediator.Append("LoadSignOnPage", LoadSignOnPage);
            Mediator.Append("LoadSignInPage", LoadSignInPage);
        }

    }
}
