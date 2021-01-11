using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace ViewSample.Models.DB
{
    public partial class Employee
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "不可為空"), Display(Name="姓名"),StringLength(50,ErrorMessage ="不可超過50字"),MinLength(2,ErrorMessage ="最少需2字")]

        public string Name { get; set; }
        [Required(ErrorMessage = "不可為空"), Display(Name = "地址"), StringLength(100, ErrorMessage = "不可超過100字"), MinLength(2, ErrorMessage = "最少需2字")]
        public string Address { get; set; }
        [Required(ErrorMessage ="不可為空"),Display(Name="生日"),DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
    }
}
