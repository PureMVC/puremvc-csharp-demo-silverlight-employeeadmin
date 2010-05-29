/*
 PureMVC C# Demo - Silverlight 4 Employee Admin
 Copyright (c) 2009 Frederic Saunier <frederic.saunier@puremvc.org>

 Parts originally from :

 PureMVC AS3 Demo - Flex Employee Admin 
 Copyright (c) 2007-08 Clifford Hall <clifford.hall@puremvc.org>
 Your reuse is governed by the Creative Commons Attribution 3.0 License
*/

#region Using
	using PureMVC.Interfaces;
	using PureMVC.Patterns;

	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller
{
	///<summary>
	/// Delete an user from the users list.
	///</summary>
    public class DeleteUserCommand : PureMVC.Patterns.SimpleCommand, PureMVC.Interfaces.ICommand
	{
		///<summary
		/// Retrieve the user and role proxies and delete the user
		/// and his roles. then send the USER_DELETED notification
		///</summary>
		override public void Execute( INotification notification )
		{
			UserVo user = (UserVo) notification.Body;
			UserProxy userProxy = (UserProxy) Facade.RetrieveProxy( UserProxy.NAME );
			RoleProxy roleProxy = (RoleProxy) Facade.RetrieveProxy( RoleProxy.NAME );
			userProxy.DeleteItem( user );		
			roleProxy.DeleteItem( user );
			SendNotification( ApplicationFacade.USER_DELETED );
		}
	}
}