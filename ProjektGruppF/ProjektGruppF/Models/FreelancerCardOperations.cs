using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Models
{
    public class FreelancerCardOperations
    {
        ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
        public List<SavedFreelancersVM> FreelancercardVMList() {
            ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
            List<SavedFreelancersVM> FreelancerCardList = new List<SavedFreelancersVM>();
            var cardlist = (from fl_table in pgfe.freelancer
                            join cv_table in pgfe.cv on fl_table.cv_id equals
                            cv_table.cv_id
                            select new
                            {
                                fl_table.freelancer_id,
                                fl_table.firstname,
                                fl_table.lastname,
                                cv_table.birthday,
                                cv_table.nationality,   
                            }).ToList();
        foreach(var item in cardlist)
            {
                DateTime birthdate = item.birthday;
                int age = AgeConverter(birthdate);

                SavedFreelancersVM fcVM = new SavedFreelancersVM();
                fcVM.Freelancer_id = item.freelancer_id;
                fcVM.Firstname = item.firstname;
                fcVM.Lastname = item.lastname;
                fcVM.Age = age;
                fcVM.Nationality = item.nationality;
                FreelancerCardList.Add(fcVM);
            }

            return FreelancerCardList;
        }

        public int AgeConverter(DateTime birthday)
        {

            DateTime todaysdate = DateTime.Today;
            int age = Convert.ToInt32(todaysdate.Year) - Convert.ToInt32(birthday.Year);
            return age;
        }


        public Freelancer ViewFreelancer(int freelancer_id)
        {
            var freelancer = (from free in pgfe.freelancer
                              join c in pgfe.cv on free.cv_id equals c.cv_id
                              where free.freelancer_id == freelancer_id
                                        select new
                                        {
                                            free.freelancer_id,
                                            free.firstname,
                                            free.lastname,
                                            free.adress,
                                            free.phonenumber,
                                            free.email,
                                            free.PersonalLetter,
                                            c.drivers_license,
                                            c.cv_id,
                                            c.birthday,
                                            c.nationality,
                                        }).FirstOrDefault();
            var fwe = (from c in pgfe.cv
                       join we in pgfe.work_experience on c.cv_id equals we.cv_id
                       where c.cv_id == freelancer_id
                       select new
                       {
                           we.employer_name,
                           we.job_title,
                           we.role,
                           we.start_date,
                           we.end_date
                       }).ToList();
            List<work_experience> weL = new List<work_experience>();
            foreach(var item in fwe)
            {
                work_experience we2 = new work_experience();
                we2.employer_name = item.employer_name;
                we2.job_title = item.job_title;
                we2.role = item.role;
                we2.start_date = item.start_date;
                we2.end_date = item.end_date;
                weL.Add(we2);
            };
            Freelancer fl = new Freelancer()
            {
                Freelancer_id = freelancer.freelancer_id,
                Firstname = freelancer.firstname,
                Lastname = freelancer.lastname,
                Adress = freelancer.adress,
                Phonenumber = freelancer.phonenumber,
                Email = freelancer.email,
                CoverLetter = freelancer.PersonalLetter,
                Drivers_license = freelancer.drivers_license,
                Cv_id = freelancer.cv_id,
                Age = AgeConverter(freelancer.birthday),
                Nationality = freelancer.nationality,
                Work_Experience_List = weL
            };
            return fl;
        }
    }
}

/*


                Employername = freelancer.employer_name,
                Jobtitle = freelancer.job_title,
                Role = freelancer.role,
                Startdate = freelancer.start_date,
                Enddate = freelancer.end_date  */