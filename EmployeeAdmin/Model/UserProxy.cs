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

	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Vo;
	using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
using System.Collections.ObjectModel;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model
{
	public class UserProxy : Proxy
	{
		new public const string NAME = "UserProxy";

        #region Constructors
        public UserProxy() : base( NAME, new ObservableCollection<UserVo>() ){}
		#endregion

		/// <summary>
        /// Data property cast to proper type.
        /// </summary>
		public ObservableCollection<UserVo> Users
		{
            get
            {
                return Data as ObservableCollection<UserVo>;
            }
		}

		/// <summary>
		///  Add an item to the data
		/// </summary>
		/// <param name="item">The UserVo to add to the list</param>
        public void AddItem( UserVo item )
		{
			Users.Add( item );
		}
				
		/// <summary>
		/// Update an item in the data.
		/// </summary>
		/// <param name="item">The UserVo from the list to update</param>
        public void UpdateItem( UserVo item )
		{
			UserVo user = item as UserVo;
            for(int i=0; i<Users.Count; i++)
			{
                if( Users[i].Username == item.Username )
                {
                    Users[i] = item;
				}
			}
		}

		/// <summary>
		/// Delete an item in the data
		/// </summary>
		/// <param name="item">The UserVo to delete from the list</param>
		public void DeleteItem( UserVo item )
		{
			UserVo user = item as UserVo;
			for ( int i=0; i<Users.Count; i++ )
			{
				if ( Users[i].Username == item.Username )
                {
					Users.RemoveAt(i);
				}
			}
		}
	}
}