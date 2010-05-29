/*
 PureMVC C# Demo - Silverlight 4 Employee Admin
 Copyright (c) 2009-10 Frederic Saunier <frederic.saunier@puremvc.org>

 Parts originally from :

 PureMVC AS3 Demo - Flex Employee Admin 
 Copyright (c) 2007-10 Clifford Hall <clifford.hall@puremvc.org>
 Your reuse is governed by the Creative Commons Attribution 3.0 License
*/

#region Using
    using System.Collections.Generic;
    using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
using System.ComponentModel;
using System.Collections.ObjectModel;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo
{
	
	public class RoleVo : INotifyPropertyChanged
	{
		private string username = "";
		private ObservableCollection<RoleEnum> roles;

		#region Constructors
        public RoleVo ( string username=null, ObservableCollection<RoleEnum> roles=null )
		{
			if( username != null ) Username = username;
			if( roles != null ) Roles = roles;
		} 
		#endregion

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

        public ObservableCollection<RoleEnum> Roles
        {
            get { return roles; }
            set { roles = value; OnPropertyChanged("Roles"); }
        }
       
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