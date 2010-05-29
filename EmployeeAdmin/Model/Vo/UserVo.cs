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
using System.Windows;
using System.ComponentModel; 
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo
{
	public class UserVo : INotifyPropertyChanged
	{

		private string username;
		private string fname;
		private string lname;
		private string email;
		private string password;
        private DeptEnum department = DeptEnum.NONE_SELECTED;

        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }

		public string Fname
        {
            get { return fname; }
            set { fname = value; OnPropertyChanged("Fname"); }
        }

		public string Lname
        {
            get { return lname; }
            set { lname = value; OnPropertyChanged("Lname"); }
        }

		public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

		public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }


		public DeptEnum Department
		{
            get{ return department; }
            set{ department = value; OnPropertyChanged("Department"); }
		}
 
		public bool isValid
		{
            get
            {
			    return Username != "" && Password != "" && Department != DeptEnum.NONE_SELECTED;
            }
		}
		
		public string givenName
		{
            get
            {
			    return Lname + ", " + Fname;
            }
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