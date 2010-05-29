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
    using System.Windows;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller
{
 	///<summary>
	/// Process the result of adding a role to an user.
	///</summary>
   public class AddRoleResultCommand : SimpleCommand
	{

     	///<summary>
    	/// If the role already exists, it displays an alert.
    	///</summary>
		override public void Execute( INotification notification )
		{
			bool result = (bool) notification.Body;
			if( result == false )
				MessageBox.Show("Role already exists for this user!");
		}
	}
}