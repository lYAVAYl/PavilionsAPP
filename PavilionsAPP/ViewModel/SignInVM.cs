using PavilionsAPP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PavilionsAPP.ViewModel
{
    public class SignInVM : ValidateBaseViewModel, IPageViewModel
    {
        string login;
        public string Login { get; set; }
        public string Password { get; set; }
        public string Kapcha { get; set; }
        public string InpKapcha { get; set; }

        public SignInVM()
        {
            Kapcha = GenerateNewKapcha();
        }

        private ICommand _signIn;
        public ICommand TrySignIn
        {
            get
            {
                return _signIn ?? (_signIn = new RelayCommand(x =>
                {
                    SignIn(Login, Password);
                }));
            }
        }

        private ICommand _loadSignOn;
        public ICommand LoadSignOn
        {
            get
            {
                return _loadSignOn ?? (_loadSignOn = new RelayCommand(x =>
                {
                    SignOn();
                }));
            }
        }

        private ICommand _updateKapcha;
        public ICommand UpdateKapcha
        {
            get
            {
                return _updateKapcha ?? (_updateKapcha = new RelayCommand(x =>
                {
                    Kapcha = GenerateNewKapcha();
                    InpKapcha = "";
                }));
            }
        }

        



        void SignIn(string login = "", string password = "")
        {
            var res = FurnitureCommands.TryAutorize(login, password);
            if (res == null)
            {
                MessageBox.Show("Load Next Page...");
            }
            else
            {
                Error = (string)res;
            }
        }

        void SignOn()
        {
            Mediator.Inform("LoadSignOnPage", "");
        }

        string GenerateNewKapcha()
        {
            string kapcha = "";
            int code;
            for (int i = 0; i < 5; i++)
            {
                do
                {
                    code = Guid.NewGuid().GetHashCode() % 100;
                    code = code < 0 ? code * (-1) : code;
                } while (code < 48
                        || code > 57 && code < 65
                        || code > 90 && code < 97
                        || code > 122);

                kapcha += Convert.ToChar(code);
            }

            return kapcha;
        }



        public override string Validate(string columnName)
        {
            string error = null;

            switch (columnName)
            {
                case nameof(Login):
                    if (string.IsNullOrEmpty(Login))
                        error = "Логин не введён";
                    break;
                case nameof(Password):
                    if (string.IsNullOrEmpty(Password))
                        error = "Пароль не введён";
                    break;
                case nameof(InpKapcha):
                    if (string.IsNullOrEmpty(InpKapcha))
                        error = "Капча не введёна";
                    break;
            }

            if (!ErrorCollection.ContainsKey(columnName))
            {
                ErrorCollection.Add(columnName, error);
            }
            else ErrorCollection[columnName] = error;

            IsEnableBtn = ErrorCollection[nameof(Login)] == null
                          && ErrorCollection[nameof(Password)] == null
                          && ErrorCollection[nameof(InpKapcha)] == null;

            return error;
        }
    }
}
