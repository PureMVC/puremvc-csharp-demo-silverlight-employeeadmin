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
using System.ComponentModel;

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components
{
    public delegate void AddHandler( Object sender );
    public delegate void UpdateHandler( Object sender );
    public delegate void CancelHandler( Object sender );

    public partial class UserForm : UserControl, INotifyPropertyChanged
    {
        #region Constants

        public const string ADD         = "add";
        public const string UPDATE      = "update";
        public const string CANCEL      = "cancel";

        public const string MODE_ADD    = "modeAdd";
        public const string MODE_EDIT   = "modeEdit";

        #endregion

        #region Events

        public event AddHandler Add;
        public event UpdateHandler Update;
        public event CancelHandler Cancel;

        #endregion

        private UserVo user;
        private string mode;

        public UserVo User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }

        public string Mode
        {
            get { return mode; }
            set { mode = value; OnPropertyChanged("Mode"); }
        }

        public UserForm()
        {
            InitializeComponent();
        }

        private void EnableSubmit()
        {
            SubmitButton.IsEnabled =
            (
                Username.Text != ""
                && 
                First.Text != ""
                &&
                Password.Password == Confirm.Password
                &&
                Department.SelectedItem != DeptEnum.NONE_SELECTED
            );
        }

        #region Events Handler
        
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            user = new UserVo
            {
                Username = Username.Text,
                Fname =  First.Text,
                Lname = Last.Text, 
                Email = Email.Text, 
                Password = Password.Password,
                Department = Department.SelectedItem as DeptEnum
            };
            
            if ( !user.isValid )
                return;

            if ( mode == MODE_ADD )
            {
                if(Add != null)
                    Add( this );
            }
            else
            {
                if(Update != null)
                    Update( this );
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Cancel( this );
        }

        private void Password_Changed(object sender, RoutedEventArgs e)
        {
            EnableSubmit();
        }

        private void Form_TextChanged(object sender, TextChangedEventArgs e)
        {
            EnableSubmit();
        }

        private void Department_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           EnableSubmit();
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
