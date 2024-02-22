using EmployeeProject.Models;
using EmployeeProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace EmployeeProject.Controllers
{
	public class EmployeeController : Controller
	{
		private readonly EmployeeDBContext context;

		public EmployeeController(EmployeeDBContext context) 
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var data=context.Employees.ToList();
			ViewBag.datasource=data;
			return View(data);
		}


	
		public IActionResult Create(int? id)
		{
            EmployeeVM EmployeeVM = GetDropdown();
			if(id==0 ||  id==null)
			{
				return View(EmployeeVM);
			}
			else
			{
				EmployeeVM.Employee=context.Employees.FirstOrDefault(x => x.Id==id);
			}
            return View(EmployeeVM);
           
		}


        public EmployeeVM GetDropdown()
		{
			EmployeeVM EmployeeVM = new ()
			{
				Employee=new(),
                DepartmentList = context.TblDepartments.ToList().Select(i => new SelectListItem
                {
					Text=i.Department,
                    Value = i.DId.ToString()
                })

			};
			return EmployeeVM;
        }

		
       
        [HttpPost]
        public IActionResult Create(EmployeeVM obj)
        {
			if (ModelState.IsValid)
			{
				if (obj.Employee.Id == 0)
				{
					context.Employees.Add(obj.Employee);
					context.SaveChanges();
					return RedirectToAction("Index");
				}

				else
				{
					context.Update(obj.Employee);
                    context.SaveChanges();
                    return RedirectToAction("Index");
				}
			}
			var Departmentd=GetDropdown();
			obj.DepartmentList = Departmentd.DepartmentList;
            return View(obj);
        }

       
        [HttpGet]
		public IActionResult DeleteEmp(int? id)
		{
			var obj=context.Employees.FirstOrDefault(x => x.Id==id);
			if (obj != null)
			{
				context.Employees.Remove(obj);
				context.SaveChanges();
				return RedirectToAction("Index");
                
            }
            return View(obj);
        }



    }
}
