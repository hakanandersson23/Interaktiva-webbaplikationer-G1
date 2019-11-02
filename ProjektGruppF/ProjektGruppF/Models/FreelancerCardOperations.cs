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
        /*

        public List<FreelanceCardVM> fcList = new List<FreelanceCardVM>
                {
                    new FreelanceCardVM{Name="Erik", Lastname="Oberg", Age=40 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="C#",Rank=5},
                    new FreelanceCardVM{Name="Sabrina", Lastname="Thao", Age=21 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="html",Rank=2},
                    new FreelanceCardVM{Name="Eva", Lastname="Evva", Age=42 , Nationality="English", Language="English", Skill="Programming",Expertise="C#",Rank=3},
                    new FreelanceCardVM{Name="Joe", Lastname="Jooe", Age=23 , Nationality="Swedish", Language="Swedish", Skill="Programming",Expertise="C#",Rank=4},
                    new FreelanceCardVM{Name="Ida", Lastname="Idda", Age=34 , Nationality="Finnish", Language="Finnish", Skill="Programming",Expertise="C#",Rank=1},
                    new FreelanceCardVM{Name="Ola", Lastname="Olla", Age=51 , Nationality="Norwegian", Language="Norwegian", Skill="Programming",Expertise="C#",Rank=2}
                };*/
        /*
        public List<FreelanceCardVM> GetCards()
        {
            return fcList;
        }*/
        ProjektGruppFEntities pgfe = new ProjektGruppFEntities();
        public List<FreelanceCardVM> FreelancercardVMList() {
            ProjektGruppFEntities pgfe = new ProjektGruppFEntities();
            List<FreelanceCardVM> FreelancerCardList = new List<FreelanceCardVM>();
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

                FreelanceCardVM fcVM = new FreelanceCardVM();
                fcVM.Freelancer_id = item.freelancer_id;
                fcVM.Name = item.firstname;
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


        public List<SavedFreelancersVM> onefreelancer(int freelancer_id)
        {
            List<SavedFreelancersVM> ListofOne = new List<SavedFreelancersVM>();

            var savedFreelancersList = (from free in pgfe.freelancer
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
                                            c.cv_id
                                        }).ToList();

            foreach (var item in savedFreelancersList)
            {
                SavedFreelancersVM objcvm = new SavedFreelancersVM();
                objcvm.Freelancer_id = item.freelancer_id;
                objcvm.Firstname = item.firstname;
                objcvm.Lastname = item.lastname;
                objcvm.Adress = item.adress;
                objcvm.Phonenumber = item.phonenumber;
                objcvm.Email = item.email;
                objcvm.Cv_id = item.cv_id;
                ListofOne.Add(objcvm);
            }
            return ListofOne;
        }

       

    }
}