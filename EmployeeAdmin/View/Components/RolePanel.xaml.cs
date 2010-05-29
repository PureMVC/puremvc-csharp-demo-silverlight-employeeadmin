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
using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;
using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components
{
    public delegate void RemoveRoleHandler( Object sender );
    public delegate void AddRoleHandler( Object sender );

    public partial class RolePanel : UserControl, INotifyPropertyChanged
    {
        #region Constants

        public const string ADD = "ADD";
        public const string REMOVE = "REMOVE";

        #endregion

        #region Events

        public event RemoveRoleHandler RemoveRole;
        public event AddRoleHandler AddRole;

        #endregion

        private UserVo user;
        private RoleEnum selectedRole;
        private ObservableCollection<RoleEnum> userRoles;

        public RolePanel()
        {
            InitializeComponent();

             SelectedRole = RoleEnum.NONE_SELECTED;
        }

        public UserVo User
        {
            get { return user; }
            set
            { 
                user = value; 
                OnPropertyChanged("User");
                OnPropertyChanged("UserNameLabel");
            }
        }

        public String UserNameLabel
        {
            get 
            { 
                if( user == null )
                    return ""; 
                else
                    return user.Lname + ", " + user.Fname; 
            }
        }

        public RoleEnum SelectedRole
        {
            get { return selectedRole; }
            set { selectedRole = value; OnPropertyChanged("SelectedRole"); }
        }
        
        public ObservableCollection<RoleEnum> UserRoles
        {
            get { return userRoles; }
            set { userRoles = value; OnPropertyChanged("UserRoles"); }
        }
        
        // select role to remove
        private void SelectRoleToRemove()
        {
            AddButton.IsEnabled = false;
            RemoveButton.IsEnabled = true;
            RoleCombo.SelectedItem = RoleEnum.NONE_SELECTED;
            SelectedRole = RoleList.SelectedItem as RoleEnum;
        }
        
        // select role to add
        private void SelectRoleToAdd()
        {
            AddButton.IsEnabled = true;
            RemoveButton.IsEnabled = false;
            RoleList.SelectedIndex =-1;
            SelectedRole = RoleCombo.SelectedItem as RoleEnum;
        }

        #region Events Handler
        private void RemoveButton_Click( object sender, RoutedEventArgs e )
        {
            if (RemoveRole != null)
                RemoveRole( this );
        }

        private void AddButton_Click( object sender, RoutedEventArgs e )
        {
            if (AddRole != null)
                AddRole( this );
        }

        private void RoleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Silverlight List controls dispatch SelectionChanged event even
             * when the selection change by user code, we have to check that
             * the selection is not just changed to -1 by code.
             */
            if( RoleList.SelectedIndex >= 0 )
                SelectRoleToRemove();
        }

        private void RoleCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*
             * Silverlight List controls dispatch SelectionChanged event even
             * when the selection change by user code, we have to check that
             * the selection is not just changed to -1 or NONE_SELECTED by code.
             */
            if( RoleCombo.SelectedIndex > 0 )
                SelectRoleToAdd();
            else
                AddButton.IsEnabled = false;
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
