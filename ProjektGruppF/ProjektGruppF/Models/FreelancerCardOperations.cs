﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjektGruppF.Models;
using ProjektGruppF.ViewModels;

namespace ProjektGruppF.Models
{
    public class FreelancerCardOperations
    {
        public void UpdFreelancer(int freelancer_id,int cv)
        {
            var query =
              from sc in pgfe.freelancer
              where sc.freelancer_id == 10
              select sc;

            foreach (freelancer sc in query)
            {
                sc.cv_id = cv;
            }
            pgfe.SaveChanges();

        }

        public void UppdateSkill_cv(int id, List<string> name)
        {
            int skill_ID = GetSkillID(id);
            int nr = 0;
            List<string> L = new List<string>();
            
            L = name;
            foreach (var item in L)
            {
                if (item== "Programming")
                {
                    nr = 1;
                }
                else if (item == "Web developing")
                {
                    nr = 2;
                }
                else if (item == "Databases")
                {
                    nr = 3;
                }
                else if (item == "Mobile applications developing")
                {
                    nr = 4;
                }
            }
            
            var query =
               from sc in pgfe.skill_cv
               where sc.skill_id ==skill_ID  && sc.cv_id == id
               select sc;

            foreach (skill_cv sc in query)
            {
                if (sc.skill_id== nr)
                {
                    sc.skill_id = nr;
                }
                else
                {
                sc.skill_id = nr;

                }
            }
            pgfe.SaveChanges();
            //int nr = 2;
            //ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
            //var uppdateSkill_cv = from s_c in pgfe.skill_cv
            //                      join s in pgfe.skill on s_c.cv_id
            //                      equals s.skill_id
            //                      where s_c.cv_id == id
            //                      where s.skill_id == 1
            //                      select s_c;

            //foreach (var item in uppdateSkill_cv)
            //{

            //    item.cv_id = id;
            //    item.skill_id = nr;

            //}
            //pgfe.SaveChanges();
            //foreach (var skill in uppdateSkill_cv)
            //{
            //    foreach (var names in name)
            //    {
            //        skill.name = names;
            //    }
            //}
            //pgfe.SaveChanges();dsdsa



        }

        public int GetSkillID(int cv_id)
        {
            int nr = 0;
            var query =
                     (from sc in pgfe.skill_cv
                      where sc.cv_id == cv_id
                      select new
                      {
                          sc.skill_id
                      }).FirstOrDefault();
            nr = query.skill_id;

            return nr;
           
        }
        public int? GetCvID(int freeID)
        {
            int? nr = 0;
            var query =
                     (from sc in pgfe.freelancer
                      where sc.freelancer_id == freeID
                      select new
                      {
                          sc.cv_id
                      }).FirstOrDefault();
            nr = query.cv_id;

            return nr;

        }

        ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
        public List<Freelancer> FreelancercardVMList() {
            ProjektGruppFEntities1 pgfe = new ProjektGruppFEntities1();
            List<Freelancer> FreelancerCardList = new List<Freelancer>();
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
                                cv_table.cv_id
                            }).ToList();
        foreach(var item in cardlist)
            {
                DateTime birthdate = item.birthday;
                int age = AgeConverter(birthdate);

                Freelancer fcVM = new Freelancer();
                fcVM.Freelancer_id = item.freelancer_id;
                fcVM.Firstname = item.firstname;
                fcVM.Lastname = item.lastname;
                fcVM.Age = age;
                fcVM.Nationality = item.nationality;
                fcVM.Cv_id = item.cv_id;
                fcVM.SkillList = GetSkills(item.cv_id);
                fcVM.ExpertiseList = GetExpertiseList(item.cv_id);
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
        //public Freelancer EditEducation(int cv_id)
        //{
        //    var query =
        //       from sc in pgfe.education
        //       where sc.skill_id == skill_ID && sc.cv_id == id
        //       select sc;








        //}


        public Freelancer ViewFreelancer(int freelancer_id, int cv_id)
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
                Birthday = freelancer.birthday,
                Nationality = freelancer.nationality,
                Work_Experience_List = GetWork_Experiences(cv_id),
                SkillList = GetSkills(cv_id),
                ExpertiseList = GetExpertiseList(cv_id),
                EducationList = GetEducations(cv_id),
                MainAbilitiesList = GetMain_Abilities(cv_id),
                FreelancerLanguageList = GetLanguages(cv_id)
            };
            return fl;
        }
        public Freelancer freeMainAbilities(int freelancer_id, int cv_id)
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
            Freelancer fl = new Freelancer()
            {
                MainAbilitiesList = GetMain_Abilities(cv_id)
            };
            return fl;

        }

        public List<work_experience> GetWork_Experiences(int cv_id)
        {
            var fwe = (from c in pgfe.cv
                       join we in pgfe.work_experience on c.cv_id equals we.cv_id
                       where c.cv_id == cv_id
                       select new
                       {
                           we.work_experience_id,
                           we.employer_name,
                           we.job_title,
                           we.role,
                           we.start_date,
                           we.end_date
                       }).ToList();
            List<work_experience> weL = new List<work_experience>();
            foreach (var item in fwe)
            {
                work_experience we2 = new work_experience();
                we2.employer_name = item.employer_name;
                we2.job_title = item.job_title;
                we2.role = item.role;
                we2.start_date = item.start_date;
                we2.end_date = item.end_date;
                we2.cv_id = cv_id;
                we2.work_experience_id = item.work_experience_id;
                weL.Add(we2);
            };
            return weL;
        }
        public List<skill> GetSkills(int cv_id)
        {
            var fskills = (from skill in pgfe.skill
                           join skillcv in pgfe.skill_cv on skill.skill_id equals skillcv.skill_id
                           where skillcv.cv_id == cv_id
                           select new
                           {
                               skill.skill_id,
                               skill.name
                           }).ToList();
            List<skill> skillL = new List<skill>();
            foreach (var item in fskills)
            {
                skill skill2 = new skill();
                skill2.skill_id = item.skill_id;
                skill2.name = item.name;
                skillL.Add(skill2);
            };
            return skillL;
        }
        public List<expertise> GetExpertiseList(int cv_id)
        {
            var fexpertise = (from ex in pgfe.expertise
                              join exCv in pgfe.expertise_cv on ex.expertise_id equals exCv.expertise_id
                              where exCv.cv_id == cv_id
                              select new
                           {
                                  ex.expertise_id,
                                  ex.name, 
                                  ex.rank_expertise_id
                           }).ToList();
            List<expertise> expertiseL = new List<expertise>();
            foreach (var item in fexpertise)
            {
                expertise expertise2 = new expertise();
                expertise2.expertise_id = item.expertise_id;
                expertise2.name = item.name;
                expertise2.rank_expertise_id = item.rank_expertise_id;
                expertiseL.Add(expertise2);
            };
            return expertiseL;
        }
        public List<education> GetEducations(int cv_id)
        {
            var feducation = (from ed in pgfe.education
                              join edCv in pgfe.education_cv on ed.education_id equals edCv.education_id
                              where edCv.cv_id == cv_id
                              select new
                              {
                                 ed.education_id,
                                 ed.education_name,
                                 ed.university_name,
                                 ed.study_years
                              }).ToList();
            List<education> educationL = new List<education>();
            foreach (var item in feducation)
            {
                education education2 = new education();
                education2.education_id = item.education_id;
                education2.education_name = item.education_name;
                education2.university_name = item.university_name;
                education2.study_years = item.study_years;
                educationL.Add(education2);
            };
            return educationL;
        }
        public List<Main_abilities> GetMain_Abilities(int cv_id)
        {
            var fma = (from ma in pgfe.Main_abilities
                              join maCv in pgfe.main_abilities_cv on ma.main_abilities_id equals maCv.main_abilities_id
                              where maCv.cv_id == cv_id
                              select new
                              {
                                  ma.main_abilities_id,
                                  ma.name,
                              }).ToList();
            List<Main_abilities> mainAbilitiesL = new List<Main_abilities>();
            foreach (var item in fma)
            {
                Main_abilities mainAbilities2 = new Main_abilities();
                mainAbilities2.main_abilities_id = item.main_abilities_id;
                mainAbilities2.name = item.name;
                mainAbilitiesL.Add(mainAbilities2);
            };
            return mainAbilitiesL;
        }
        public List<language> GetLanguages(int cv_id)
        {
            var flanguages = (from l in pgfe.language
                           join lcv in pgfe.language_cv on l.language_id equals lcv.language_id
                           where lcv.cv_id == cv_id
                           select new
                           {
                               l.language_id,
                               l.name
                           }).ToList();
            List<language> languageL = new List<language>();
            foreach (var item in flanguages)
            {
                language langauge2 = new language();
                langauge2.language_id = item.language_id;
                langauge2.name = item.name;
                languageL.Add(langauge2);
            };
            return languageL;
        }

        public void SavefreeToCus(int cusID, int freeID)
        {
            customer_freelancer cf = new customer_freelancer
            {
                freelancer_id = freeID,
                customer_id = cusID
            };
            pgfe.customer_freelancer.Add(cf);
            pgfe.SaveChanges();

        }
    }
}
   
