using System;
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
            // bootstrap.css y bootstrap.min.css
            bundles.Add(new StyleBundle("~/Content/CssBootstrap").Include(
                      "~/Content/bootstrap.*"));

            // css para estilo del wizard
            bundles.Add(new StyleBundle("~/Content/CssWizardBootstrap").Include(
                      "~/Content/gsdk-bootstrap-wizard.css"));

            // Sweetalert2 css
            bundles.Add(new ScriptBundle("~/Content/CssSweetalert2").Include(
                        "~/Content/sweetalert2.css"));

            // jquery-3.4.0.min.js
            bundles.Add(new ScriptBundle("~/Scripts/JQuery3.4.0").Include(
                      "~/Scripts/jquery-3.4.0.min.js"));

            // bootstrap.js y bootstrap.min.js
            bundles.Add(new ScriptBundle("~/Scripts/JsBootstrap").Include(
                      "~/Scripts/bootstrap.*"));

            // archivos js para el wizard
            bundles.Add(new ScriptBundle("~/Scripts/JsWizardBootstrap").Include(
                      "~/Scripts/jquery.bootstrap.wizard.js",
                      "~/Scripts/gsdk-bootstrap-wizard.js"));

            // jQuery validate
            bundles.Add(new ScriptBundle("~/Scripts/JQueryVal").Include(
                        "~/Scripts/jquery.validate.min.js"));

            // mascara jQuery
            bundles.Add(new ScriptBundle("~/Scripts/JQueryMaskedinput").Include(
                        "~/Scripts/jquery.maskedinput.js"));

            // Sweetalert2 jQuery
            bundles.Add(new ScriptBundle("~/Scripts/JsSweetalert2").Include(
                        "~/Scripts/jquery.sweetalert2.js"));

            //bundles.Add(new ScriptBundle("~/Scripts/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/Scripts/modernizr").Include(
            //            "~/Scripts/modernizr-*"));
        }
    }
}