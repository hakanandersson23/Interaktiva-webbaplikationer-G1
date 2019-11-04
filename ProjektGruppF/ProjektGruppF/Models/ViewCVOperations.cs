using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Models
{
    public class ViewCVOperations
    {
        ProjektGruppFEntities1 pg = new ProjektGruppFEntities1();

        public List<Freelancer> CVFreelancer(cv cvv)
        {
            List<Freelancer> cvfreelancer = new List<Freelancer>();

            var freelancersCV = (from c in pg.cv
                                 join f in pg.freelancer on c.cv_id equals f.cv_id
                                 join w in pg.work_experience on c.cv_id equals w.cv_id

                                        select new
                                        {
                                            f.freelancer_id,
                                            f.firstname,
                                            f.lastname,
                                            f.adress,
                                            f.phonenumber,
                                            f.email,
                                            c.birthday,
                                            c.nationality,
                                            //c.language,
                                            c.drivers_license,
                                            c.cv_id,
                                            w.employer_name,
                                            w.job_title,
                                            w.role,
                                            w.start_date,
                                            w.end_date,
                                        }).ToList();
            foreach (var item in freelancersCV)
            {
                Freelancer cv = new Freelancer();
                cv.Freelancer_id = item.freelancer_id;
                cv.Cv_id = item.cv_id;
                cv.Firstname = item.firstname;
                cv.Lastname = item.lastname;
                cv.Adress = item.adress;
                cv.Phonenumber = item.phonenumber;
                cv.Email = item.email;
                cv.Birthday = item.birthday;
                cv.Nationality = item.nationality;
                //cv.Language = item.language_cv.ToString();
                cv.Drivers_license = item.drivers_license;
                cv.Employername = item.employer_name;
                cv.Jobtitle = item.job_title;
                cv.Role = item.role;
                cv.Startdate = item.start_date;
                cv.Enddate = item.end_date;
      
                cvfreelancer.Add(cv);
            }
            return cvfreelancer;
        }
    }
}