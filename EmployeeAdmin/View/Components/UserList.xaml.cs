using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components
{    
    public delegate void NewHandler( Object sender );
    public delegate void DeleteHandler( Object sender );
    public delegate void SelectHandler( Object sender );

    public partial class UserList : UserControl, INotifyPropertyChanged
    {
        #region Constants

        public const string NEW = "NEW";
        public const string DELETE = "DELETE";
        public const string SELECT = "SELECT";

        #endregion

        #region Events

        public event NewHandler New;
        public event DeleteHandler Delete;
        public event SelectHandler Select;

        #endregion

        private UserVo selectedUser;
        private ObservableCollection<UserVo> users;

        public UserList()
        {
            InitializeComponent();

            DeleteButton.IsEnabled = false;
        }

        public UserVo SelectedUser
        {
            get { return selectedUser; }
            set { selectedUser = value; OnPropertyChanged("SelectedUser"); }
        }

        public ObservableCollection<UserVo> Users
        {
            get { return users; }
            set { users = value; OnPropertyChanged("Users"); }
        }

        public void DeSelect()
        {
            Confirm.Visibility = Visibility.Collapsed;
            UserDataGrid.SelectedIndex = -1;
            DeleteButton.IsEnabled = false;
        }

        #region Events Handler

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm.Visibility = Visibility.Visible;
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            DeSelect();

            if( New != null )
                New( this );
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            if( Delete != null )
                Delete( this );

            DeSelect();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            Confirm.Visibility = Visibility.Collapsed;
        }

        private void SelectionChanged_Handler(object sender, SelectionChangedEventArgs e)
        {
            if( UserDataGrid.SelectedIndex == -1 )
                return;

            DeleteButton.IsEnabled = true;

            if (Select != null)
                Select( this );
        }
        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

    }
}