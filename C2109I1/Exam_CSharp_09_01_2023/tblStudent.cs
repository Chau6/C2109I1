﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam_CSharp_09_01_2023
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblStudent
    {
        public byte stuId { get; set; }
        public string stuUsername { get; set; }
        public string stuPass { get; set; }
        public string stuName { get; set; }
        public Nullable<System.DateTime> stuDob { get; set; }
        public Nullable<bool> stuGender { get; set; }
        public string stuAddress { get; set; }
        public string stuPhone { get; set; }
        public string stuEmail { get; set; }
        public Nullable<byte> stuLevel { get; set; }
        public Nullable<byte> deptId { get; set; }
        public Nullable<System.DateTime> createAt { get; set; }
        public Nullable<System.DateTime> updateAt { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(stuId)}={stuId.ToString()}, {nameof(stuUsername)}={stuUsername}, {nameof(stuPass)}={stuPass}, {nameof(stuName)}={stuName}, {nameof(stuDob)}={stuDob.ToString()}, {nameof(stuGender)}={(stuGender == true ? "nam" : "nữ")}, {nameof(stuAddress)}={stuAddress}, {nameof(stuPhone)}={stuPhone}, {nameof(stuEmail)}={stuEmail}, {nameof(stuLevel)}={stuLevel.ToString()}, {nameof(deptId)}={deptId.ToString()}, {nameof(createAt)}={createAt.ToString()}, {nameof(updateAt)}={updateAt.ToString()}}}";
        }
    }
}