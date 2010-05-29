/*
 PureMVC C# Demo - Silverlight 4 Employee Admin
 Copyright (c) 2009-10 Frederic Saunier <frederic.saunier@puremvc.org>

 Parts originally from :

 PureMVC AS3 Demo - Flex Employee Admin 
 Copyright (c) 2007-10 Clifford Hall <clifford.hall@puremvc.org>
 Your reuse is governed by the Creative Commons Attribution 3.0 License
*/

#region Using
	using PureMVC.Interfaces;
	using PureMVC.Patterns;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
    using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;
    using System.Collections.Generic;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View
{
	public class UserListMediator : Mediator
	{
		private UserProxy UserProxy;

		new public const string NAME = "UserListMediator";

		#region Constructors
		public UserListMediator( UserList viewComponent ) : base( NAME, viewComponent )
		{
			UserList.New += OnNew;
			UserList.Delete += OnDelete;
			UserList.Select += OnSelect;

			UserProxy = (UserProxy) Facade.RetrieveProxy( UserProxy.NAME );
			UserList.Users = UserProxy.Users;
		}
		#endregion
		
		private UserList UserList
		{
			get
            {
                return ViewComponent as UserList;
            }
		}

		override public IList<string> ListNotificationInterests()
		{
			return new List<string>
            {
					ApplicationFacade.CANCEL_SELECTED,
					ApplicationFacade.USER_UPDATED
		    };
		}
		
		override public void HandleNotification( INotification note )
		{
			switch ( note.Name )
			{
				case ApplicationFacade.CANCEL_SELECTED:
					UserList.DeSelect();
				break;
					
				case ApplicationFacade.USER_UPDATED:
					UserList.DeSelect();
				break;
			}
		}

        #region Events handler

		private void OnNew( object sender )
		{
			UserVo user = new UserVo();
			SendNotification( ApplicationFacade.NEW_USER, user );
		}
		
		private void OnDelete( object sender )
		{
			SendNotification( ApplicationFacade.DELETE_USER, UserList.SelectedUser );
		}
		
		private void OnSelect( object sender )
		{
			SendNotification( ApplicationFacade.USER_SELECTED, UserList.SelectedUser );
        }

        #endregion

    }
}