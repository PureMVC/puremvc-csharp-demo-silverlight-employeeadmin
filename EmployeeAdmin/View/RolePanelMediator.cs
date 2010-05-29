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
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;
    using System.Collections.Generic;
using System.Collections.ObjectModel;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View
{
	public class RolePanelMediator : Mediator
	{
		private RoleProxy RoleProxy;		
		
		new public const string NAME = "RolePanelMediator";

		#region Constructors
		public RolePanelMediator( RolePanel viewComponent ) : base( NAME, viewComponent )
		{
			RolePanel.AddRole += onAddRole;
			RolePanel.RemoveRole += onRemoveRole;

			RoleProxy = (RoleProxy) Facade.RetrieveProxy( RoleProxy.NAME );

            ClearForm();
		}
		#endregion
		
		private RolePanel RolePanel
		{
            get
            {
			    return ViewComponent as RolePanel;
            }
		}
		
		override public IList<string> ListNotificationInterests()
		{
			return new List<string>
            {
					ApplicationFacade.NEW_USER,
					ApplicationFacade.USER_ADDED,
					ApplicationFacade.USER_UPDATED,
					ApplicationFacade.USER_DELETED,
					ApplicationFacade.CANCEL_SELECTED,
					ApplicationFacade.USER_SELECTED
		    };
		}
		
		override public void HandleNotification( INotification note )
		{
			switch ( note.Name )
			{
				case ApplicationFacade.NEW_USER:
					ClearForm();
				break;
					
				case ApplicationFacade.USER_ADDED:
					RolePanel.User = note.Body as UserVo;
					RoleVo roleVO = new RoleVo ( RolePanel.User.Username, new ObservableCollection<RoleEnum>() );
					RoleProxy.AddItem( roleVO );
					ClearForm();
				break;
					
				case ApplicationFacade.USER_UPDATED:
					ClearForm();
				break;
					
				case ApplicationFacade.USER_DELETED:
					ClearForm();
				break;
					
				case ApplicationFacade.CANCEL_SELECTED:
					ClearForm();
				break;
					
				case ApplicationFacade.USER_SELECTED:
					RolePanel.User = note.Body as UserVo;
					RolePanel.UserRoles = RoleProxy.GetUserRoles( RolePanel.User.Username );
					RolePanel.RoleCombo.SelectedItem = RoleEnum.NONE_SELECTED;
                    RolePanel.IsEnabled = true;
                	RolePanel.RemoveButton.IsEnabled = false;
			        RolePanel.AddButton.IsEnabled = false;
				break;					
			}
		}
		
		private void ClearForm()
		{		
			RolePanel.User = null;
			RolePanel.UserRoles = null;
			RolePanel.IsEnabled = false;
		}

        #region Events handler
		private void onAddRole( object sender )
		{
			RoleProxy.AddRoleToUser( RolePanel.User, RolePanel.SelectedRole );
		}
		
		private void onRemoveRole( object sender )
		{
			RoleProxy.RemoveRoleFromUser( RolePanel.User, RolePanel.SelectedRole );
		}
        #endregion
	}
}