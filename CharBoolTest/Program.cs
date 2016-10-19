using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharBoolTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestContext ctx = new TestContext())
            {
                var article = ctx.Artikel.FirstOrDefault(x=>x.cAktiv);
                if (article != null)
                {
                    article.cAktiv = false;
                    article.nAktivNull = null;
                }
                ctx.SaveChanges();

              //  ctx.Artikel.Remove(article);
              //  ctx.SaveChanges();

            }
        }
    }
}
