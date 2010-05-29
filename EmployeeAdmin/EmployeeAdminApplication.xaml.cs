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

using PureMVC.Interfaces;
using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin
{
    public partial class EmployeeAdminApplication : UserControl
    {
        private ApplicationFacade Facade;

        public EmployeeAdminApplication()
        {
            InitializeComponent();

            Facade = ApplicationFacade.getInstance() as ApplicationFacade;
            Facade.Startup(this);
        }

        private void RolePanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void UserList_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
