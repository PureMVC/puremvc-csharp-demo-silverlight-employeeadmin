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
    using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin
{
    public class ApplicationFacade : Facade
	{
        #region Constants

		// Notification name constants
		public const string STARTUP 		    = "startup";
		
		public const string NEW_USER 		    = "newUser";
		public const string DELETE_USER 		= "deleteUser";
		public const string CANCEL_SELECTED 	= "cancelSelected";
		
        public const string USER_SELECTED	    = "userSelected";
		public const string USER_ADDED		    = "userAdded";
		public const string USER_UPDATED		= "userUpdated";
		public const string USER_DELETED		= "userDeleted";

		public const string ADD_ROLE 		    = "addRole";
		public const string ADD_ROLE_RESULT 	= "addRoleResult";
		
        #endregion
		
		/// <summary>
		/// Singleton Factory Method
		/// </summary>
		/// <returns>The unique instance of the ApplicationFacade</returns>
		public static ApplicationFacade getInstance()
        {
            if (m_instance == null)
                m_instance = new ApplicationFacade();

            return (ApplicationFacade) m_instance;
		}
		
		/// <summary>
		/// Start the application
		/// </summary>
		/// <param name="app">The application instance</param>
		 public void Startup( object app )
		 {
		 	SendNotification( STARTUP, app );	
		 }

		/// <summary>
		/// Register Commands with the Controller 
		/// </summary>
		override protected void InitializeController() 
		{
			base.InitializeController();

            RegisterCommand( STARTUP, typeof(StartupCommand) );
            RegisterCommand( DELETE_USER, typeof(DeleteUserCommand) );
            RegisterCommand( ADD_ROLE_RESULT, typeof(AddRoleResultCommand) );
		}
	}
}