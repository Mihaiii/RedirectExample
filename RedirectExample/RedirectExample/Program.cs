using System;
using Starcounter;

namespace RedirectExample
{
    class Program
    {
        static void Main()
        {
            Application.Current.Use(new HtmlFromJsonProvider());
            Application.Current.Use(new PartialToStandaloneHtmlProvider());

            Handle.GET("/RedirectExample/test1", () =>
            {
                return new Test1Page();
            });

            Handle.GET("/RedirectExample/test2", () =>
            {
                var resp = new Response()
                {
                    StatusCode = 302
                };
                resp.Headers["Location"] = "/RedirectExample/test3";
                return resp;
            });

            Handle.GET("/RedirectExample/test3", () =>
            {
                return new Test3Page();
            });
        }
    }
}