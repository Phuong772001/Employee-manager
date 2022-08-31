namespace Manage.Common
{
    public static class CreateCode
    {
        public static string UserCode(int id)
        {
            string code;
            if (id < 10)
                code = "UE00" + $"{id}";
            else if (id < 100)
                code = "UE0" + $"{id}";
            else code = "UE" + $"{id}";
            return code;
        }
        public static string BankCode(int id)
        {
            string code;
            if (id < 10)
                code = "BA00" + $"{id}";
            else if (id < 100)
                code = "BA0" + $"{id}";
            else code = "BA" + $"{id}";
            return code;
        }
        public static string BankBranchCode(int id)
        {
            string code;
            if (id < 10)
                code = "BAB00" + $"{id}";
            else if (id < 100)
                code = "BAB0" + $"{id}";
            else code = "BAB" + $"{id}";
            return code;
        }
        public static string AllowanceCode(int id)
        {
            string code;
            if (id < 10)
                code = "AL00" + $"{id}";
            else if (id < 100)
                code = "AL0" + $"{id}";
            else code = "AL" + $"{id}";
            return code;
        }
        public static string EmployeeCode(int id)
        {
            string code;
            if (id < 10)
                code = "EM00" + $"{id}";
            else if (id < 100)
                code = "EM0" + $"{id}";
            else code = "EM" + $"{id}";
            return code;
        }
        public static string HospitalCode(int id)
        {
            string code;
            if (id < 10)
                code = "HOS00" + $"{id}";
            else if (id < 100)
                code = "HOS0" + $"{id}";
            else code = "HOS" + $"{id}";
            return code;
        }
        public static string NationCode(int id)
        {
            string code;
            if (id < 10)
                code = "NA00" + $"{id}";
            else if (id < 100)
                code = "NA0" + $"{id}";
            else code = "NA" + $"{id}";
            return code;
        }
        public static string DistrictCode(int id)
        {
            string code;
            if (id < 10)
                code = "DIS00" + $"{id}";
            else if (id < 100)
                code = "DIS0" + $"{id}";
            else code = "DIS" + $"{id}";
            return code;
        }
        public static string TitleCode(int id)
        {
            string code;
            if (id < 10)
                code = "TIT00" + $"{id}";
            else if (id < 100)
                code = "TIT0" + $"{id}";
            else code = "TIT" + $"{id}";
            return code;
        }
        public static string ProvinceCode(int id)
        {
            string code;
            switch (id)
            {
                case < 10:
                    code = "PRO00" + $"{id}";
                    break;
                case < 100:
                    code = "PRO0" + $"{id}";
                    break;
                default:
                    code = "PRO" + $"{id}";
                    break;
            }
            if (id < 10)
                code = "PRO00" + $"{id}";
            else if (id < 100)
                code = "PRO0" + $"{id}";
            else code = "PRO" + $"{id}";
            return code;
        }
        public static string WardCode(int id)
        {
            string code;
            if (id < 10)
                code = "WA00" + $"{id}";
            else if (id < 100)
                code = "WA0" + $"{id}";
            else code = "WA" + $"{id}";
            return code;
        }
        public static string ContractCode(int id)
        {
            string code;
            if (id < 10)
                code = "CON00" + $"{id}";
            else if (id < 100)
                code = "CON0" + $"{id}";
            else code = "CON" + $"{id}";
            return code;
        }
        public static string OrgCode(int id)
        {
            string code;
            if (id < 10)
                code = "ORG00" + $"{id}";
            else if (id < 100)
                code = "ORG0" + $"{id}";
            else code = "ORG" + $"{id}";
            return code;
        }
        public static string WelfaceCode(int id)
        {
            string code;
            if (id < 10)
                code = "WE00" + $"{id}";
            else if (id < 100)
                code = "WE0" + $"{id}";
            else code = "WE" + $"{id}";
            return code;
        }
        public static string SalaryCode(int id)
        {
            string code;
            if (id < 10)
                code = "SA00" + $"{id}";
            else if (id < 100)
                code = "SA0" + $"{id}";
            else code = "SA" + $"{id}";
            return code;
        }
        public static string ContractAllowanceCode(int id)
        {
            string code;
            if (id < 10)
                code = "CA00" + $"{id}";
            else if (id < 100)
                code = "CA0" + $"{id}";
            else code = "CA" + $"{id}";
            return code;
        }
        public static string ContractWelfaceCode(int id)
        {
            string code;
            if (id < 10)
                code = "CW00" + $"{id}";
            else if (id < 100)
                code = "CW0" + $"{id}";
            else code = "CW" + $"{id}";
            return code;
        }
        public static string SchoolCode(int id)
        {
            string code;
            if (id < 10)
                code = "SCH00" + $"{id}";
            else if (id < 100)
                code = "SCH0" + $"{id}";
            else code = "SCH" + $"{id}";
            return code;
        }
        public static string OrgTitleCode(int id)
        {
            string code;
            if (id < 10)
                code = "ORT00" + $"{id}";
            else if (id < 100)
                code = "ORT0" + $"{id}";
            else code = "ORT" + $"{id}";
            return code;
        }
        public static string OtherListTypeCode(int id)
        {
            string code;
            if (id < 10)
                code = "OLT00" + $"{id}";
            else if (id < 100)
                code = "OLT0" + $"{id}";
            else code = "OLT" + $"{id}";
            return code;
        }
        public static string OtherListCode(int id)
        {
            string code;
            if (id < 10)
                code = "OL00" + $"{id}";
            else if (id < 100)
                code = "OL0" + $"{id}";
            else code = "OL" + $"{id}";
            return code;
        }
    }
}
