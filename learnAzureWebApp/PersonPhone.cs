//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace learnAzureWebApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonPhone
    {
        public int BusinessEntityID { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual PhoneNumberType PhoneNumberType { get; set; }
    }
}
