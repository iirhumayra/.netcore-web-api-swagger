using elearningWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace elearningWebAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class SubjectController : ControllerBase

    {
        [HttpGet]
        public IEnumerable<Subject> Get()
        {
            using (var context = new elearningContext())
            {
                //get all Subject
                //return context.Subject.ToList();

                //add a subject
                /*
                Subject subject     = new Subject();
                subject.SubjectId   = 3;
                subject.SubjectName = "Sholat Akhlak";
                subject.IsActive    = true;
                context.Subject.Add(subject);
                context.SaveChanges();
                */

                

                //update subject 
                /*
                Subject subject = context.Subject.Where(Sub => Sub.SubjectId == 3).FirstOrDefault();
                subject.SubjectDesc = "ini dari update";
                context.SaveChanges();
                */

                //get 1 subject by id
                //return context.Subject.Where(Sub => Sub.SubjectId == 3).ToList();

                //delete data from subject
                Subject subject = context.Subject.Where(Sub => Sub.SubjectId == 3).FirstOrDefault();
                context.Subject.Remove(subject);
                context.SaveChanges();

                return context.Subject.ToList();

            }
        }
    }
}
