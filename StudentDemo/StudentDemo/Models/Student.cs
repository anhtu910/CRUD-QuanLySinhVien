using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace StudentDemo.Models
{
	public class Student
	{
		[Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ID { get; set; }
		public string StudentCode { get; set; }
		public string Name { get; set; }
		public string Gender { get; set; }
		public string Phone1 { get; set; }
		public string Phone2 { get; set; }
		public string Email { get; set; }
		public string Image { get; set; }
		public string Address { get; set; }
		public string ProvinceID { get; set; }
		public string WardID { get; set; }
		public string DistrictID { get; set; }
		public DateTime Birthday { get; set; }
		public string Note { get; set; }
		public string CreateBy { get; set; }
		public DateTime CreateDate { get; set; }
		public string IsDelete { get; set; }
		public string SearchText { get; set; }

	}
}
