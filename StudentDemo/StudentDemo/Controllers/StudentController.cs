using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using StudentDemo.Models;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace StudentDemo.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IWebHostEnvironment _env;
		public StudentController(IConfiguration configuration,IWebHostEnvironment env)
		{
			_configuration = configuration;
			_env = env;
		}

		
		[HttpGet]
		public JsonResult Get()
		{
			string query = @"Select * from dbo.Student";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("StudentCon");
			SqlDataReader myrender;
			using(SqlConnection mycon=new SqlConnection(sqlDataSource))
			{
				mycon.Open();
				using(SqlCommand mycom=new SqlCommand(query,mycon))
				{
					myrender = mycom.ExecuteReader();
					table.Load(myrender);
					mycon.Close();
				}
			}
			return new JsonResult(table);
		}
		[HttpPost]
		public JsonResult Post(Student student)
		{
			string query = @"insert into dbo.Student(
			StudentCode,Name,Gender,Phone1,Phone2,Email,Image,Address,ProvinceID,WardID,DistrictID,Birthday,Note,CreateBy,CreateDate,IsDelete,SearchText) values ('"
			+ student.StudentCode + "','"+student.Name + "','" + student.Gender + "','" + student.Phone1 + "','" + student.Phone2 + "','" + student.Email + "','" +
			student.Image + "','" + student.Address + "','" + student.ProvinceID + "','" + student.WardID + "','" + student.DistrictID + "','" + student.Birthday + "','" + 
			student.Note + "','" + student.CreateBy + "','" + student.CreateDate + "','" + student.IsDelete + "','" + student.SearchText + @"')";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("StudentCon");
			SqlDataReader myrender;
			using (SqlConnection mycon = new SqlConnection(sqlDataSource))
			{
				mycon.Open();
				using (SqlCommand mycom = new SqlCommand(query, mycon))
				{
					myrender = mycom.ExecuteReader();
					table.Load(myrender);
					mycon.Close();
				}
			}
			return new JsonResult("Successfuly");
		}
		[HttpPut]
		public JsonResult Put(Student student)
		{
			string query = @"update dbo.Student set StudentCode='" + student.StudentCode + "',Name='"+student.Name+"',Gender='"+student.Gender+"',Phone1='"+student.Phone1
				+"',Phone2='"+student.Phone2+"',Email='"+student.Email+"',Image='"+student.Image+"',Address='"+student.Address+"',ProvinceID='"+student.ProvinceID
				+"',WardID='"+student.WardID+"',DistrictID='"+student.DistrictID+"',Birthday='"+student.Birthday+"',Note='"+student.Note+"',CreateBy='"+student.CreateBy
				+"',CreateDate='"+student.CreateDate+"',IsDelete='"+student.IsDelete+"',SearchText='"+student.SearchText+"'where ID="+student.ID+@"";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("StudentCon");
			SqlDataReader myrender;
			using (SqlConnection mycon = new SqlConnection(sqlDataSource))
			{
				mycon.Open();
				using (SqlCommand mycom = new SqlCommand(query, mycon))
				{
					myrender = mycom.ExecuteReader();
					table.Load(myrender);
					mycon.Close();
				}
			}
			return new JsonResult("Successfuly");
		}
		[HttpDelete("{id}")]
		public JsonResult Delete(int id)
		{
			string query = @"delete from dbo.Student where ID=" + id + @"";
			DataTable table = new DataTable();
			string sqlDataSource = _configuration.GetConnectionString("StudentCon");
			SqlDataReader myrender;
			using (SqlConnection mycon = new SqlConnection(sqlDataSource))
			{
				mycon.Open();
				using (SqlCommand mycom = new SqlCommand(query, mycon))
				{
					myrender = mycom.ExecuteReader();
					table.Load(myrender);
					mycon.Close();
				}
			}
			return new JsonResult("Successfuly");
		}
		//[Route("SaveFile")]
		//[HttpPost]
		//public JsonResult SaveFile()
		//{
		//	try
		//	{
		//		var httpRequest = Request.Form;
		//		var imagefile = httpRequest.Files[0];
		//		string filename = imagefile.FileName;
		//		var phyPatch = _env.ContentRootPath + "/Photos" + filename;
		//		using(var stream=new FileStream(phyPatch,FileMode.Create))
		//		{
		//			imagefile.CopyTo(stream); 
		//		}
		//		return new JsonResult(filename);
		//	}
		//	catch(Exception)
		//	{
		//		return new JsonResult("Error");
		//	}
		//}
	}
}
