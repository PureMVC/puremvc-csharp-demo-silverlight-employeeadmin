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
    using System.Collections.ObjectModel;

	using PureMVC.Interfaces;
	using PureMVC.Patterns;
	
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View
{

	public class UserFormMediator : Mediator
	{
		private UserProxy UserProxy;
	
		new public const string NAME = "UserFormMediator";

		#region Constructors
		public UserFormMediator( UserForm viewComponent ) : base( NAME, viewComponent )
		{
            UserForm.Add += OnAdd;
			UserForm.Update += OnUpdate;
			UserForm.Cancel += OnCancel;
            UserForm.IsEnabled = false;

			UserProxy = (UserProxy) Facade.RetrieveProxy( UserProxy.NAME );
		}
		#endregion
		
		private UserForm UserForm
		{
            get
            {
			    return ViewComponent as UserForm;
            }
		}
	
		override public IList<string> ListNotificationInterests()
		{
			return new List<string>
            {
					ApplicationFacade.NEW_USER,
					ApplicationFacade.USER_DELETED,
					ApplicationFacade.USER_SELECTED
		    };
		}
		
		override public void HandleNotification( INotification note )
		{
           UserVo User = note.Body as UserVo;

			switch( note.Name )
			{
				case ApplicationFacade.NEW_USER:
                    ClearForm();
                    UserForm.Username.IsEnabled = true;
					UserForm.User = User;
					UserForm.Mode = UserForm.MODE_ADD;
                    UserForm.SubmitButton.Content = "Add User";
                    UserForm.IsEnabled = true;
					UserForm.First.Focus();
                    UserForm.Username.IsEnabled = true;
				break;
					
				case ApplicationFacade.USER_DELETED:
					UserForm.User = null;
					ClearForm();
				break;
					
				case ApplicationFacade.USER_SELECTED:
                    ClearForm();
                    UserForm.IsEnabled = true;
                    UserForm.Username.IsEnabled = false;

					UserForm.User = User;
                    UserForm.Confirm.Password = User.Password;
					UserForm.Mode = UserForm.MODE_EDIT;
					UserForm.First.Focus();
                    UserForm.SubmitButton.Content = "Update User";
				break;
			}
		}
		
		private void ClearForm()
		{
			UserForm.User = null;
			UserForm.Username.Text = "";
			UserForm.First.Text = "";
			UserForm.Last.Text = "";
			UserForm.Email.Text = ""; 
			UserForm.Password.Password = "";
			UserForm.Confirm.Password = "";
			UserForm.Department.SelectedItem = DeptEnum.NONE_SELECTED.Value;
            UserForm.IsEnabled = false;
		}

        #region Events handler

        private void OnAdd( object sender )
        {
            UserVo user = UserForm.User;
            UserProxy.AddItem(user);
            SendNotification( ApplicationFacade.USER_ADDED, user );
            ClearForm();
        }

        private void OnUpdate( object sender )
        {
            UserVo user = UserForm.User;
            UserProxy.UpdateItem(user);
            SendNotification(ApplicationFacade.USER_UPDATED, user);
            ClearForm();
        }

        private void OnCancel( object sender )
        {
            SendNotification(ApplicationFacade.CANCEL_SELECTED);
            ClearForm();
        }

        #endregion
	}
}