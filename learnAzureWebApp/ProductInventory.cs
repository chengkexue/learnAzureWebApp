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
    
    public partial class ProductInventory
    {
        public int ProductID { get; set; }
        public short LocationID { get; set; }
        public string Shelf { get; set; }
        public byte Bin { get; set; }
        public short Quantity { get; set; }
        public System.Guid rowguid { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Location Location { get; set; }
        public virtual Product Product { get; set; }
    }
}
