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
    using PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum;
    using System;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum
{
	public class DeptEnum
	{
        #region Enum
        static public DeptEnum NONE_SELECTED  = new DeptEnum{ Value="--None Selected--",  Ordinal=-1 };
        static public DeptEnum ACCT           = new DeptEnum{ Value="Accounting",         Ordinal=0 };
        static public DeptEnum SALES          = new DeptEnum{ Value="Sales",              Ordinal=1 };
        static public DeptEnum PLANT          = new DeptEnum{ Value="Plant",              Ordinal=2 };
        static public DeptEnum SHIPPING       = new DeptEnum{ Value="Shipping",           Ordinal=3 };
        static public DeptEnum QC             = new DeptEnum{ Value="Quality Control",    Ordinal=4 };
        #endregion

        public static List<DeptEnum> List
		{
            get
            {
                return new List<DeptEnum>
                {
                    DeptEnum.ACCT, 
                    DeptEnum.SALES, 
                    DeptEnum.PLANT
                };
            }
		}

        public static List<DeptEnum> ComboList
		{
            get
            {
                List<DeptEnum> cList = DeptEnum.List;
                cList.Insert( 0, NONE_SELECTED );
			    return cList;
            }
		}
		
		public bool Equals( RoleEnum role )
		{
			return ( (int)Ordinal == (int)role.Ordinal && Value == role.Value );
		}

        public string Value{ get; set; }
        public int Ordinal{ get; set; }
	}
}