/*
 PureMVC C# Demo - Silverlight 4 Employee Admin
 Copyright (c) 2009-10 Frederic Saunier <frederic.saunier@puremvc.org>

 Parts originally from :

 PureMVC AS3 Demo - Flex Employee Admin 
 Copyright (c) 2007-10 Clifford Hall <clifford.hall@puremvc.org>
 Your reuse is governed by the Creative Commons Attribution 3.0 License
*/

#region Using
	using PureMVC.Patterns;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Controller
{

    public class StartupCommand : MacroCommand
	{
        /// <summary>
        /// Add the Subcommands to startup the PureMVC apparatus.
        /// Generally, it is best to prep the Model (mostly registering proxies)
        /// followed by preparation of the View (mostly registering 
        /// Mediators).
        /// </summary>
		override protected void InitializeMacroCommand()	
		{
			AddSubCommand( typeof(PrepModelCommand) );
			AddSubCommand( typeof(PrepViewCommand) );
		}
	}
}