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
    
    public partial class DatabaseLog
    {
        public int DatabaseLogID { get; set; }
        public System.DateTime PostTime { get; set; }
        public string DatabaseUser { get; set; }
        public string Event { get; set; }
        public string Schema { get; set; }
        public string Object { get; set; }
        public string TSQL { get; set; }
        public string XmlEvent { get; set; }
    }
}