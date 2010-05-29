/*
 PureMVC C# Demo - Silverlight 4 Employee Admin
 Copyright (c) 2009-10 Frederic Saunier <frederic.saunier@puremvc.org>

 Parts originally from :

 PureMVC AS3 Demo - Flex Employee Admin 
 Copyright (c) 2007-10 Clifford Hall <clifford.hall@puremvc.org>
 Your reuse is governed by the Creative Commons Attribution 3.0 License
*/

#region Using
    using System;
    using System.Collections.Generic;
#endregion

namespace PureMVC.CSharp.Demos.Silverlight.EmployeeAdmin.Model.Enum
{
	public class RoleEnum
    {
        #region Enum
        static public RoleEnum NONE_SELECTED 	= new RoleEnum{ Value="--None Selected--",      Ordinal=-1 };
        static public RoleEnum ADMIN 			= new RoleEnum{ Value="Administrator",          Ordinal=0 };
        static public RoleEnum ACCT_PAY 		= new RoleEnum{ Value="Accounts Payable",       Ordinal=1 };
        static public RoleEnum ACCT_RCV 		= new RoleEnum{ Value="Accounts Receivable",    Ordinal=2 };
        static public RoleEnum EMP_BENEFITS 	= new RoleEnum{ Value="Employee Benefits",      Ordinal=3 };
        static public RoleEnum GEN_LEDGER       = new RoleEnum{ Value="General Ledger",         Ordinal=4 };
        static public RoleEnum PAYROLL          = new RoleEnum{ Value="Payroll",                Ordinal=5 };
        static public RoleEnum INVENTORY 		= new RoleEnum{ Value="Inventory",              Ordinal=6 };
        static public RoleEnum PRODUCTION       = new RoleEnum{ Value="Production",             Ordinal=7 };
        static public RoleEnum QUALITY_CTL      = new RoleEnum{ Value="Quality Control",        Ordinal=8 };
        static public RoleEnum SALES 			= new RoleEnum{ Value="Sales",                  Ordinal=9 };
        static public RoleEnum ORDERS           = new RoleEnum{ Value="Orders",                 Ordinal=10 };
        static public RoleEnum CUSTOMERS        = new RoleEnum{ Value="Customers",              Ordinal=11 };
        static public RoleEnum SHIPPING         = new RoleEnum{ Value="Shipping",               Ordinal=12 };
        static public RoleEnum RETURNS          = new RoleEnum{ Value="Returns",                Ordinal=13 };
        #endregion

        public static List<RoleEnum> List
		{
            get
            {
                return new List<RoleEnum>
                {
                    ADMIN, 
                    ACCT_PAY, 
                    ACCT_RCV, 
                    EMP_BENEFITS, 
                    GEN_LEDGER, 
                    PAYROLL,
                    INVENTORY,
                    PRODUCTION,
                    QUALITY_CTL,
                    SALES,
                    ORDERS,
                    CUSTOMERS,
                    SHIPPING,
                    RETURNS
                };
            }  
		}

		public static List<RoleEnum> ComboList
		{
            get
            {
    			List<RoleEnum> cList = RoleEnum.List;
    			cList.Insert( 0, NONE_SELECTED );
    			return cList;
            }
		}
		
		public bool equals( DeptEnum dept )
		{
			return ( (int)Ordinal == (int)dept.Ordinal && Value == dept.Value );
		}

        public string Value{ get; set; }
        public int Ordinal{ get; set; }
	}
}