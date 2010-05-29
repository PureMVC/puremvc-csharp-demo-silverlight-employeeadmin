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

	using PureMVC.Interfaces;
	using PureMVC.Patterns;

	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin; 
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
using System.Collections.ObjectModel;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model
{

	public class RoleProxy : Proxy
	{
		new public const string NAME = "RoleProxy";

		#region Constructors
		public RoleProxy() : base( NAME, new ObservableCollection<RoleVo>() ){}
		#endregion

        /// <summary>
        /// Get the data property cast to the appropriate type;
        /// </summary>
		public ObservableCollection<RoleVo> Roles
		{
            get
            {
    			return Data as ObservableCollection<RoleVo>;
            }
		}

        /// <summary>
        /// add an item to the data
        /// </summary>
		/// <param name="item">The RoleVo item to add to the list</param>
		public void AddItem( RoleVo role )
		{
			Roles.Add( role );
		}

		/// <summary>
		/// Delete roles item attached to an user.
		/// </summary>
		/// <param name="item">The UserVo from who to delete roles</param>
		public void DeleteItem( UserVo item )
		{
			for( int i=0; i<Roles.Count; i++)
            { 
				if( Roles[i].Username == item.Username )
                {
					Roles.RemoveAt(i);
					break;
				}
			}	
		}

		/// <summary>
		/// Determine if the user has a given role.
		/// </summary>
		/// <param name="user">The user to search for roles</param>
		/// <param name="role">The role to search for</param>
		/// <returns></returns>
		public bool DoesUserHaveRole( UserVo user, RoleEnum role )
		{
			bool hasRole = false;
			for( int i=0; i<Roles.Count; i++ )
            { 
				if( Roles[i].Username == user.Username )
                {
					ObservableCollection<RoleEnum> userRoles = Roles[i].Roles as ObservableCollection<RoleEnum>;
					for( int j=0; j<userRoles.Count; j++ )
                    {
						if( userRoles[j].Equals(role) )
                        {
							hasRole = true;
							break;
						} 
					}
					break;
				}
			}
			return hasRole;
		}

		/// <summary>
		/// Add a role to this user
		/// </summary>
		/// <param name="user">The user to whom to add roles</param>
		/// <param name="role">The role to add</param>
		public void AddRoleToUser( UserVo user, RoleEnum role )
		{
			bool result = false;
			if( !DoesUserHaveRole( user, role ) )
            {
				for( int i=0; i<Roles.Count; i++ )
                { 
					if( Roles[i].Username == user.Username )
                    {
						ObservableCollection<RoleEnum> userRoles = Roles[i].Roles as ObservableCollection<RoleEnum>;
						userRoles.Add( role );
						result = true;
						break;
					}
				}
			}

			SendNotification( ApplicationFacade.ADD_ROLE_RESULT, result );
		}

		/// <summary>
		/// Remove a role from the user
		/// </summary>
		/// <param name="user">The user to whom to remove roles</param>
		/// <param name="role">The role to remove</param>
		public void RemoveRoleFromUser( UserVo user, RoleEnum role )
		{
			if( DoesUserHaveRole( user, role ) )
            {
				for( int i=0; i<Roles.Count; i++ )
                { 
					if( Roles[i].Username == user.Username )
                    {
						ObservableCollection<RoleEnum> userRoles = Roles[i].Roles as ObservableCollection<RoleEnum>;
						for( int j=0; j<userRoles.Count; j++ )
                        { 
							if( userRoles[j].Equals(role) )
                            {
								userRoles.RemoveAt(j);
								break;
							}
						}
						break;
					}
				}
			}
		}

		/// <summary>
		///  Get a user's roles
		/// </summary>
		/// <param name="username">The user name to get roles from</param>
		/// <returns></returns>
		public ObservableCollection<RoleEnum> GetUserRoles( string username )
		{
			ObservableCollection<RoleEnum> userRoles = new ObservableCollection<RoleEnum>();
			for( int i=0; i<Roles.Count; i++)
            { 
				if( Roles[i].Username == username )
                {
					userRoles = Roles[i].Roles as ObservableCollection<RoleEnum>;
					break;
				}
			}	
			return userRoles;
		}
	}
}