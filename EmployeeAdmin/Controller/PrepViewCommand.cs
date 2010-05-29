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
	
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin;
    using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.View.Components;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller
{
 	///<summary>
	/// Prepare the View.
	///</summary>
    public class PrepViewCommand : SimpleCommand
	{
        /// <summary>
		/// Get the View Components for the Mediators from the app,
		/// a reference to which was passed on the original startup 
		/// notification.
        /// </summary>
        /// 
        /// <param name="note">A notification which transport a reference to the application</param>
		override public void Execute( INotification note )
		{
            EmployeeAdminApplication app = (EmployeeAdminApplication) note.Body;
			Facade.RegisterMediator( new UserFormMediator( app.UserForm ) );
			Facade.RegisterMediator( new UserListMediator( app.UserList ) );
			Facade.RegisterMediator( new RolePanelMediator( app.RolePanel ) );
		}
	}
}