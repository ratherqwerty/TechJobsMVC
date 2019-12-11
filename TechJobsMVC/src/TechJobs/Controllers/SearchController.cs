using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results


        public IActionResult Results(string searchType, string searchTerm) // search request and display results
        {
            ViewBag.columns = ListController.columnChoices;
            List<Dictionary<string, string>> items = new List<Dictionary<string, string>>();

            if (searchType == "all")
            {
                if (String.IsNullOrEmpty(searchTerm))
                {
                    ViewBag.jobs = JobData.FindByValue("");
                } 
                else 
                { 
                    ViewBag.jobs = JobData.FindByValue(searchTerm);
                        
                }

                  //items =  JobData.FindAll();
            } 
            /*else if (searchTerm == "")
            {
                jItems = JobData.FindAll(searchType);
                jVals = JobData.FindByValue("");
                items = JobData.FindByColumnAndValue(jItems, jVals);
            }*/
            
            else
            {
                ViewBag.jobs = JobData.FindByColumnAndValue(searchType, searchTerm);
                //items = JobData.FindByColumnAndValue(searchType, searchTerm);
            }

            
            //ViewBag.items = items;
           

            //List<Dictionary<String, String>> jobs = JobData.FindByColumnAndValue(column, value);
            //ViewBag.title = "Jobs with " + columnChoices[column] + ": " + value;
            //ViewBag.jobs = jobs;

            return View("Index");



        }

    }
}
