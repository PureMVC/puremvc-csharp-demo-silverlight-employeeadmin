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
using System.Collections.ObjectModel;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller
{
    public class PrepModelCommand : SimpleCommand
	{
     	///<summary>
    	/// Prepare the Model.
    	///</summary>
		override public void Execute( INotification notification )
		{
            // Create User Proxy, 
			UserProxy userProxy = new UserProxy();
			
			//Populate it with dummy data 
			userProxy.AddItem( new UserVo{ Username="lstooge", Fname="Larry", Lname="Stooge", Email="larry@stooges.com", Password="ijk456", Department = DeptEnum.ACCT } );
			userProxy.AddItem( new UserVo{ Username="cstooge", Fname="Curly", Lname="Stooge", Email="curly@stooges.com", Password="xyz987", Department = DeptEnum.SALES } );
			userProxy.AddItem( new UserVo{ Username="mstooge", Fname="Moe", Lname="Stooge", Email="moe@stooges.com", Password="abc123", Department = DeptEnum.PLANT } );

			// register it
			Facade.RegisterProxy( userProxy );

			// Create Role Proxy
			RoleProxy roleProxy = new RoleProxy();
			
			//Populate it with dummy data 
            RoleEnum[] lstoogeRoles = { RoleEnum.PAYROLL, RoleEnum.EMP_BENEFITS };
			roleProxy.AddItem( new RoleVo("lstooge", new ObservableCollection<RoleEnum>( lstoogeRoles ) ) );

            RoleEnum[] cstoogeRoles = { RoleEnum.ACCT_PAY, RoleEnum.ACCT_RCV, RoleEnum.GEN_LEDGER };
			roleProxy.AddItem( new RoleVo("cstooge", new ObservableCollection<RoleEnum>( cstoogeRoles ) ) );

            RoleEnum[] mstoogeRoles = { RoleEnum.INVENTORY, RoleEnum.PRODUCTION, RoleEnum.SALES, RoleEnum.SHIPPING };
			roleProxy.AddItem( new RoleVo("mstooge", new ObservableCollection<RoleEnum>( mstoogeRoles ) ) );

			// register it
			Facade.RegisterProxy( roleProxy );
		}
	}
}