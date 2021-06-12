﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace EncuestasUSAM.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery-2.2.4.min.js",
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/jquery.bootstrap.wizard.js",
                      "~/Scripts/gsdk-bootstrap-wizard.js",
                      "~/Scripts/jquery.validate.min.js", 
                      "~/Scripts/sweetalert2.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/gsdk-bootstrap-wizard.css",
                      "~/Content/sweetalert2.css"));
        }
    }
}