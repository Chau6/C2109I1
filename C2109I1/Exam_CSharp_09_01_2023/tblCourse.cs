//------------------------------------------------------------------------------
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
    
    public partial class tblCourse
    {
        public byte couId { get; set; }
        public string couName { get; set; }
        public Nullable<byte> couSemester { get; set; }

        public override string ToString()
        {
            return $"{{{nameof(couId)}={couId.ToString()}, {nameof(couName)}={couName}, {nameof(couSemester)}={couSemester.ToString()}}}";
        }
    }
}